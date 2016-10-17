//
//  ODSocket.h
//  ServerDemo
//
//  Created by zyuq on 15-2-4.
//  Copyright (c) 2015年 a. All rights reserved.
//

#ifndef __ServerDemo__ODSocket__
#define __ServerDemo__ODSocket__
#include <sys/socket.h>
#include <netinet/in.h>
#include <netdb.h>
#include <fcntl.h>
#include <unistd.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <arpa/inet.h>
typedef int		SOCKET;

//#pragma region define win32 const variable in linux
#define INVALID_SOCKET	-1
#define SOCKET_ERROR	-1
#include <iostream>

class ODSocket {
public:
    ODSocket(SOCKET sock = INVALID_SOCKET);
    ~ODSocket();
    // Create socket object for snd/recv data
    bool Create(int af,int type,int protocol=0);
    
    bool Connect(const char* ip, unsigned short port);
    // Bind socket
    bool Bind(unsigned short port);
    // Listen socket
    bool Listen(int backlog=5);
    
    int Send(const char* buf, int len, int flags = 0);
    
    // Recv socket
	int Recv(char* buf, int len, int flags = 0);
    
    // Close socket
	int Close();
    
    // Get errno
	int GetError();
    
    bool Accept(ODSocket& s, char* fromip);
    
    //#pragma region just for win32
	// Init winsock DLL
	static int Init();
	// Clean winsock DLL
	static int Clean();
	//#pragma endregion
    
    // Domain parse
	static bool DnsParse(const char* domain, char* ip);
    
    ODSocket& operator=(SOCKET s);
    operator SOCKET();
    
protected:
    SOCKET m_sock;
};










#endif /* defined(__ServerDemo__ODSocket__) */
