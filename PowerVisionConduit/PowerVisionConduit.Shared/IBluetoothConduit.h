#pragma once

/* C Interface */
#ifdef __cplusplus
extern "C" {
#endif
	typedef struct
	{
		char* Name;
		char* ProtocolString;
		char* Address;
	} EnovationBluetoothDeviceStruct;

	EnovationBluetoothDeviceStruct* EnovationBluetoothGetDeviceList(int* count);
#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
// C++ Platform Abstraction
namespace Enovation
{
	namespace PowerVisionConduit
	{
		class IBluetoothConduit
		{
		public:
			IBluetoothConduit() : deviceList(0), deviceListCount(0)
			{
			}

			virtual ~IBluetoothConduit()
			{
				for (int i = 0; i < deviceListCount; i++)
				{
					delete[] deviceList[i].Name;
					delete[] deviceList[i].Address;
					delete[] deviceList[i].ProtocolString;
				}
				if (deviceList)
					delete[] deviceList;
			}

			EnovationBluetoothDeviceStruct* GetDeviceList(int* count)
			{
				*count = deviceListCount;
				return deviceList;
			}

		protected:
			EnovationBluetoothDeviceStruct* deviceList;
			int deviceListCount;
		};
	}
}
#endif
