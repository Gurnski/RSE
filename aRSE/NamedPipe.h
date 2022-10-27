#pragma once
#include <Windows.h>
#include <exception>

DWORD WINAPI LuaPipe(PVOID lvpParameter)
{
	HANDLE luaPipe;
	char buffer[999999];
	DWORD dwRead;
	luaPipe = CreateNamedPipe(TEXT("\\\\.\\pipe\\LuaPipe"),PIPE_ACCESS_DUPLEX,PIPE_TYPE_MESSAGE | PIPE_READMODE_MESSAGE | PIPE_WAIT,PIPE_UNLIMITED_INSTANCES,999999,999999,NMPWAIT_USE_DEFAULT_WAIT,NULL);
	while (luaPipe != INVALID_HANDLE_VALUE)
	{
		if (ConnectNamedPipe(luaPipe, NULL) != FALSE)
		{
			while (ReadFile(luaPipe, buffer, sizeof(buffer) - 1, &dwRead, NULL) != FALSE)
			{
				buffer[dwRead] = '\0';
				try {
					if (strlen(buffer) != NULL) {
						// execute script function.. execute(buffer)
					}
				}
				catch (std::exception e) {
					//TODO: Log to exploit console
				}
				catch (...) {
					//TODO: Log to exploit console
				}
			}
		}
		DisconnectNamedPipe(luaPipe);
	}
}