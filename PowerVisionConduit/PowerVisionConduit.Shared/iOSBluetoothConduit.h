#pragma once

#include "IBluetoothConduit.h"

namespace Enovation
{
	namespace PowerVisionConduit
	{
		class iOSBluetoothConduit : public IBluetoothConduit
		{
		public:
			iOSBluetoothConduit(const std::list<std::string>& protocolStrings) : protocolStrings(protocolStrings)
			{
			}

			virtual void Init()
			{
				// TODO: call objective C library that interfaces with EA Framework...

				//EAAccessoryManager.Notifications.ObserveDidConnect(OnAccessoryDidConnect);
				//EAAccessoryManager.Notifications.ObserveDidDisconnect(OnAccessoryDidDisconnect);

				// register for local notifications from accessory manager
				//EAAccessoryManager.SharedAccessoryManager.RegisterForLocalNotifications();

				//var connectedAccessories = EAAccessoryManager.SharedAccessoryManager.ConnectedAccessories;

				//foreach(EAAccessory accessory in connectedAccessories)
				//{
				//	if (protocols.Contains(accessory.ProtocolStrings[0]))
				//		listOfDevices.Add(new BluetoothDeviceInfo(){ Name = accessory.Name, ProtocolString = accessory.ProtocolStrings[0] });
				//}

				// TEST
				BluetoothDeviceInfo testInfo;
				testInfo.Name = "Device 1";
				testInfo.Address = "12345";
				testInfo.ProtocolString = "fee";
				listOfDevices.push_back(testInfo);

				testInfo.Name = "Device 2";
				testInfo.Address = "67890";
				testInfo.ProtocolString = "fum";
				listOfDevices.push_back(testInfo);
			}

		private:
			std::list<std::string> protocolStrings;

			static void OnAccessoryDidConnect()
			{

			}
		};

		class SharedConduit
		{
		private:
			static IBluetoothConduit* conduit;

		public:
			static IBluetoothConduit* GetBluetoothConduit()
			{
				if (conduit == 0)
				{
					// Capture Protocol Strings
					// TODO (Xamarin Example below):
					// Capture Protocol Strings
					//var protocolArray = (NSArray)NSBundle.MainBundle.InfoDictionary["UISupportedExternalAccessoryProtocols"];

					//// Get List for Conduit
					//var list = new List<string>();
					//for (nuint i = 0; i < protocolArray.Count; i++)
					//	list.Add(protocolArray.GetItem<NSString>(i).ToString());

					std::list<std::string> protocolStrings;
					protocolStrings.push_back("fee");
					protocolStrings.push_back("fi");
					protocolStrings.push_back("fo");
					protocolStrings.push_back("fum");

					conduit = new iOSBluetoothConduit(protocolStrings);
					conduit->Init();
				}

				return conduit;
			}
		};
	}
}
