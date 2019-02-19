#include "iOSBluetoothConduit.h"

EnovationBluetoothDeviceStruct* EnovationBluetoothGetDeviceList(int* count)
{
	static Enovation::PowerVisionConduit::iOSBluetoothConduit conduit;
	return conduit.GetDeviceList(count);
}
