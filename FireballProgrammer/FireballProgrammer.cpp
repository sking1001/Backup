#include <stdio.h>
#include "SLABCP2114.h"

#define MAX_SLOTS 32
#define EXPECTED_API_VERSION 6
#define EXPECTED_FW_VERSION 8
#define EXPECTED_CONFIG_VERSION 2

static BYTE pemConfig[RAM_CONFIG_SIZE_B02] =
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

static bool Validate(HID_UART_DEVICE& device)
{
	CP2114_CAPS_STRUCT capsStruct;
	CP2114_OTP_CONFIG_GET otpConfig;

	HID_UART_STATUS status = CP2114_GetDeviceCaps(device, &capsStruct);
	
	if (status == HID_UART_SUCCESS)
	{
		status = CP2114_GetOtpConfig(device, capsStruct.currentBootConfig, &otpConfig);
	}
	if (status == HID_UART_SUCCESS)
	{
		if (memcmp(otpConfig.OtpConfig.CP2114_B02.PemConfig, pemConfig, RAM_CONFIG_SIZE_B02) == 0)
		{
			return true;
		}
	}

	return false;
}

int main(int argc, char* argv[])
{
	HID_UART_DEVICE device = 0;
	BYTE apiVersion, fwVersion, configVersion;
	CP2114_CAPS_STRUCT capsStruct;
	CP2114_OTP_CONFIG_GET otpConfig;
	BYTE slotIndex = 255;

	HID_UART_STATUS status = HidUart_Open(&device, 0, 0x10C4, 0xEAB0);

	if (status == HID_UART_SUCCESS)
	{
		status = CP2114_GetVersions(device, &apiVersion, &fwVersion, &configVersion);
	}

	if (status == HID_UART_SUCCESS)
	{
		if (apiVersion != EXPECTED_API_VERSION || fwVersion != EXPECTED_FW_VERSION || configVersion != EXPECTED_CONFIG_VERSION)
		{
			printf("Wrong CP2114 Version\n");

			status = HidUart_Close(device);
			return -1;
		}
	}

	if (status == HID_UART_SUCCESS)
	{
		if (Validate(device))
		{
			status = HidUart_Close(device);

			printf("Device already programmed.\n");
			return 0;
		}
	}

	if (status == HID_UART_SUCCESS)
	{
		status = CP2114_GetDeviceCaps(device, &capsStruct);
		slotIndex = MAX_SLOTS - capsStruct.availableOtpConfigs;
	}
	if (status == HID_UART_SUCCESS)
	{
		status = CP2114_CreateOtpConfig(device, RAM_CONFIG_SIZE_B02, pemConfig);
	}
	if (status == HID_UART_SUCCESS)
	{
		status = CP2114_GetOtpConfig(device, slotIndex, &otpConfig);
	}
	if (status == HID_UART_SUCCESS)
	{
		if (memcmp(otpConfig.OtpConfig.CP2114_B02.PemConfig, pemConfig, RAM_CONFIG_SIZE_B02) == 0)
		{
			status = CP2114_SetBootConfig(device, slotIndex);
		}
		else
		{
			status = HidUart_Close(device);
			printf("Failed OTP Compare\n");
			return -1;
		}
	}

	if (device)
		status = HidUart_Close(device);

	if (status != HID_UART_SUCCESS)
	{
		printf("Critical Programming Error\n");
		return -1;
	}

	printf("Device successfully programmed.\n");
	return 1;
}
