using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using Newtonsoft.Json;
using PowerVision.Core.NextGenPackage.FileSystem;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PowerVisionPackager
{
    class Program
    {
        private const string ProgramName = "PowerVisionPackager";
        private const string TargetDirectory = @"..\PowerVisionPackages\";

        static void RecurseAddDirToPackage(string rootDir, string subDir, Manifest manifest, MD5 md5Hash, TarOutputStream tarOutputStream)
        {
            DirectoryInfo di = new DirectoryInfo(Path.Combine(rootDir, subDir));

            foreach (System.IO.FileInfo fi in di.GetFiles())
            {
                string packagePath = Path.Combine(subDir, fi.Name).Replace('\\', '/');
                byte[] fileContents = File.ReadAllBytes(fi.FullName);

                // Add to tarOutputStream
                TarEntry tarEntry = TarEntry.CreateTarEntry(packagePath);
                tarEntry.Size = fileContents.Length;
                tarOutputStream.PutNextEntry(tarEntry);
                tarOutputStream.Write(fileContents, 0, fileContents.Length);
                tarOutputStream.CloseEntry();

                // Compute MD5 hash
                byte[] data = md5Hash.ComputeHash(fileContents);
                StringBuilder hashBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                    hashBuilder.Append(data[i].ToString("x2"));

                // Add manifest
                manifest.Files.Add(new ManifestFile()
                {
                    DestPath = packagePath,
                    MD5 = hashBuilder.ToString(),
                });
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
                RecurseAddDirToPackage(rootDir, Path.Combine(subDir, dir.Name), manifest, md5Hash, tarOutputStream);
        }

        static void PackageDir(string embeddedBinaryPackageDir)
        {
            // The target package directory is actually 2 directories above embeddedBinaryPackageDir
            // i.e ..\..\PowerVisionPackages\
            string packageDir = Path.Combine(embeddedBinaryPackageDir, $@"..\{TargetDirectory}");

            // The base name of the manifest and the tarball package is named after the embeddedBinaryPackageDir
            string packageName = Path.Combine(packageDir, $"{Path.GetFileNameWithoutExtension(embeddedBinaryPackageDir)}");

            Manifest manifest = new Manifest();
            MD5 md5Hash = MD5.Create();

            using (FileStream tarBall = new FileStream(Path.Combine(packageDir, packageName + ".tar.gz"), FileMode.Create))
            using (GZipOutputStream GzipStream = new GZipOutputStream(tarBall))
            using (TarOutputStream tarOutputStream = new TarOutputStream(GzipStream))
                RecurseAddDirToPackage(embeddedBinaryPackageDir, subDir: "", manifest, md5Hash, tarOutputStream);

            File.WriteAllText(Path.Combine(packageDir, packageName + ".manifest.json"), JsonConvert.SerializeObject(manifest, Formatting.Indented));
        }

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine($"Usage: \n{ProgramName} <path to embedded binaries directory>");
                return;
            }

            try
            {
                // Create the directory for PowerVision packages
                // It will be a sibling of the embedded binaries directory
                Directory.CreateDirectory(Path.Combine(args[0], TargetDirectory));

                // Now create a PowerVision package for each subdirectory in the embedded binaries directory
                foreach (DirectoryInfo subDir in new DirectoryInfo(args[0]).GetDirectories())
                {
                    Console.Write($"Packaging {subDir.FullName}...");
                    PackageDir(subDir.FullName);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
