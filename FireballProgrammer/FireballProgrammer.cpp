#include "SLABCP2114.h"
#include <iostream>
#include <sstream>

const DWORD DEVICE_NUM = 0;
const WORD DEVICE_VID = 0x10C4;
const WORD DEVICE_PID = 0xEAB0;
const BYTE EXPECTED_API_VERSION = 6;
const BYTE EXPECTED_FW_VERSION = 8;
const BYTE EXPECTED_CONFIG_VERSION = 2;
const BYTE MAX_SLOTS = 32;

static BYTE excpectedPemConfig[RAM_CONFIG_SIZE_B02] =
{
	0x02, 0x00, 0x00, 0x40, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x70, 0x77, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x1C, 0x01,
	0x03, 0x02, 0x06, 0x00, 0x00
};

bool ValidateChipVersion(HID_UART_DEVICE& device)
{
	BYTE apiVersion, fwVersion, configVersion;
	if (CP2114_GetVersions(device, &apiVersion, &fwVersion, &configVersion) != HID_UART_SUCCESS)
		throw std::exception("Error getting versions");

	if (apiVersion != EXPECTED_API_VERSION || fwVersion != EXPECTED_FW_VERSION || configVersion != EXPECTED_CONFIG_VERSION)
		return false;

	return true;
}

// Singleton Implementation
CP2114_CAPS_STRUCT GetCapsStruct(HID_UART_DEVICE& device)
{
	static CP2114_CAPS_STRUCT capsStruct;
	static bool initialized = false;

	if (!initialized)
	{
		if (CP2114_GetDeviceCaps(device, &capsStruct) != HID_UART_SUCCESS)
			throw std::exception("Error getting device capabilities");
		initialized = true;
	}

	return capsStruct;
}

bool ValidateProgramming(HID_UART_DEVICE& device, BYTE slot)
{
	CP2114_OTP_CONFIG_GET otpConfig;
	if (CP2114_GetOtpConfig(device, slot, &otpConfig) != HID_UART_SUCCESS)
		throw std::exception("Error reading OTP");

	if (memcmp(otpConfig.OtpConfig.CP2114_B02.PemConfig, excpectedPemConfig, RAM_CONFIG_SIZE_B02) != 0)
		return false;

	return true;
}

BYTE GetProgramSlot(HID_UART_DEVICE& device)
{
	BYTE slot = MAX_SLOTS - GetCapsStruct(device).availableOtpConfigs;
	if (slot == MAX_SLOTS)
		throw std::exception("No more slots available to program");

	return slot;
}

void Program(HID_UART_DEVICE& device)
{
	BYTE slot = GetProgramSlot(device);

	if (CP2114_CreateOtpConfig(device, RAM_CONFIG_SIZE_B02, excpectedPemConfig) != HID_UART_SUCCESS)
		throw std::exception("Error creating OTP");

	if (ValidateProgramming(device, slot))
	{
		if (CP2114_SetBootConfig(device, slot) != HID_UART_SUCCESS)
			throw std::exception("Error setting boot config");
	}
	else
		throw std::exception("Failed OTP compare");
}

int main(int argc, char* argv[])
{
	HID_UART_DEVICE device = 0;
	int retCode = 0;

	try
	{
		if (HidUart_Open(&device, DEVICE_NUM, DEVICE_VID, DEVICE_PID) != HID_UART_SUCCESS)
		{
			std::stringstream ss;
			ss << "Error opening device number " << DEVICE_NUM <<
				" (VID = 0x" << std::hex << std::uppercase << DEVICE_VID <<
				", PID = 0x" << DEVICE_PID << ")";
			throw std::exception(ss.str().c_str());
		}

		if (!ValidateChipVersion(device))
			throw std::exception("Wrong CP2114 version");

		if (ValidateProgramming(device, GetCapsStruct(device).currentBootConfig))
		{
			std::cout << "Device already programmed" << std::endl;
			retCode = 0;
		}
		else
		{
			Program(device);
			retCode = 1;
		}
	}
	catch (std::exception& e)
	{
		std::cout << e.what() << std::endl;
		retCode = -1;
	}

	if (device)
		HidUart_Close(device);

	return retCode;
}
