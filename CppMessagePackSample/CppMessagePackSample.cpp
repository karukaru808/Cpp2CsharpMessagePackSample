#include <iostream>
#include <ws2tcpip.h>
#include "mpack-amalgamation-1.1/src/mpack/mpack.h"

#define IP_ADDR "127.0.0.1"
#define PORT 1234

bool Serialize(char**, size_t*);
bool SendData(const char*, size_t);

int main()
{
	char* data;
	size_t size;

	auto result = Serialize(&data, &size);
	if (result)
	{
		result = SendData(data, size);
	}

	printf("Result: %d", result);
}

bool Serialize(char** data, size_t* size)
{
	mpack_writer_t writer;
	mpack_writer_init_growable(&writer, data, size);

	mpack_build_array(&writer);
	mpack_write_bool(&writer, true);
	mpack_write_uint(&writer, 0);
	mpack_complete_array(&writer);

	if (mpack_writer_destroy(&writer) != mpack_ok) {
		printf("An error occurred encoding the data!\n");
		return false;
	}

	printf("Serialized.\r\n");

	return true;
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

	printf("Destination IP: %s, Port: %d\r\n", IP_ADDR, PORT);

	for (auto i = 0; i < 1000; i++)
	{
		printf("Sending. SendCount: %3d\r\n", i);
		sendto(sock, data, size, 0, (sockaddr*)&sock_addr, sizeof(sock_addr));

		Sleep(50);
	}

	closesocket(sock);
	WSACleanup();

	return true;
}
