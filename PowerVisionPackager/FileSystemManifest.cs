using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerVision.Core.NextGenPackage.FileSystem
{
    public class ManifestFile
    {
        public string DestPath { get; set; }
        public string MD5 { get; set; }
        public string Permissions { get; set; } = "777";
    }

    public class ManifestFolder
    {
        public string Name { get; set; }
    }

    public class Manifest
    {
        public List<ManifestFile> Files = new List<ManifestFile>();
        public List<ManifestFolder> ProtectedFolders = new List<ManifestFolder>();
    }
}
