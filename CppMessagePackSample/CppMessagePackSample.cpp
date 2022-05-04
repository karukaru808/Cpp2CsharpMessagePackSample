#pragma once
#include "MsgPackArraySample.h"
#include "MsgPackMapSample.h"
#include <iostream>
#include <iomanip>
#include <WS2tcpip.h>


#define IP_ADDR "127.0.0.1"
#define PORT 1234


bool SendData(const char*, size_t);

int main()
{
	std::cout << "0: Array Format, 1: Map Format" << std::endl;
	int format;
	std::cin >> format;

	IMsgPackSample* sample_data;
	if (format)
	{
		sample_data = new MsgPackMapSample(true, 0);
	}
	else
	{
		sample_data = new MsgPackArraySample(true, 0);
	}

	char* binary_data;
	const size_t size = sample_data->Serialize(&binary_data);
	if (size > 0)
	{
		SendData(binary_data, size);
	}

	return 0;
}


bool SendData(const char* data, const size_t size)
{
	WSAData wsaData;
	auto result = WSAStartup(WINSOCK_VERSION, &wsaData);
	if (result != NO_ERROR)
	{
		return false;
	}

	int sock = socket(AF_INET, SOCK_DGRAM, 0);
	sockaddr_in sock_addr{ AF_INET, htons(PORT) };
	inet_pton(AF_INET, IP_ADDR, &sock_addr.sin_addr.s_addr);

	std::cout << "Destination IP: " << IP_ADDR << ", Port: " << PORT << std::endl;

	for (auto i = 0; i < 1000; i++)
	{
		std::cout << "Sending. SendCount: " << std::setw(3) << i + 1 << std::endl;
		sendto(sock, data, size, 0, (sockaddr*)&sock_addr, sizeof(sock_addr));

		Sleep(50);
	}

	closesocket(sock);
	WSACleanup();

	return true;
}
