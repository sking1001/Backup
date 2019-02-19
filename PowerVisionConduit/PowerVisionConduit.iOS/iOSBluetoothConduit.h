#pragma once

#include "IBluetoothConduit.h"
#include <string>

namespace Enovation
{
	namespace PowerVisionConduit
	{
		class iOSBluetoothConduit : public IBluetoothConduit
		{
		public:
			iOSBluetoothConduit()
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

				// Capture Protocol Strings
				// TODO (Xamarin Example below):
				// Capture Protocol Strings
				//var protocolArray = (NSArray)NSBundle.MainBundle.InfoDictionary["UISupportedExternalAccessoryProtocols"];

				//// Get List for Conduit
				//var list = new List<string>();
				//for (nuint i = 0; i < protocolArray.Count; i++)
				//	list.Add(protocolArray.GetItem<NSString>(i).ToString());

				// TEST
				deviceList = new EnovationBluetoothDeviceStruct[2];

				deviceList[0].Name = new char[10];
				deviceList[0].Address = new char[10];
				deviceList[0].ProtocolString = new char[10];
				strcpy(deviceList[0].Name, "Device 1");
				strcpy(deviceList[0].Address, "12345");
				strcpy(deviceList[0].ProtocolString, "fee");
				++deviceListCount;

				deviceList[0].Name = new char[10];
				deviceList[0].Address = new char[10];
				deviceList[0].ProtocolString = new char[10];
				strcpy(deviceList[0].Name, "Device 2");
				strcpy(deviceList[0].Address, "67890");
				strcpy(deviceList[0].ProtocolString, "fum");
				++deviceListCount;
			}

		private:
			static void OnAccessoryDidConnect()
			{

			}
		};
	}
}
