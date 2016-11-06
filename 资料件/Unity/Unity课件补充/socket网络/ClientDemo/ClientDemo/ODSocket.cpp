//
//  ODSocket.cpp
//  ServerDemo
//
//  Created by zyuq on 15-2-4.
//  Copyright (c) 2015年 a. All rights reserved.
//

#include "ODSocket.h"
ODSocket::ODSocket(SOCKET sock)
{
    m_sock=sock;
}
ODSocket::~ODSocket()
{
}
ODSocket& ODSocket::operator = (SOCKET s)
{
	m_sock = s;
	return (*this);
}
int ODSocket::Init()
{
    return 0;
}

int ODSocket::Clean()
{
    return 0;
}

ODSocket::operator SOCKET ()
{
    return m_sock;
}

bool ODSocket::Create(int af,int type,int protocol)
{
    m_sock=socket(af, type, protocol);
    if (m_sock==INVALID_SOCKET) {
        return false;
    }
    return true;
}

bool ODSocket::Connect(const char* ip, unsigned short port)
{
    struct sockaddr_in svraddr;
    svraddr.sin_family=AF_INET;
    svraddr.sin_addr.s_addr=inet_addr(ip);
    svraddr.sin_port=htons(port);
    int ret=connect(m_sock, (struct sockaddr*)&svraddr, sizeof(svraddr));
    if (ret==SOCKET_ERROR) {
        return false;
    }
    return true;
}

bool ODSocket::Bind(unsigned short port)
{
    struct sockaddr_in svraddr;
    svraddr.sin_family=AF_INET;
    svraddr.sin_addr.s_addr=INADDR_ANY;
    svraddr.sin_port=htons(port);
    int opt=1;
  /*  if (setsockopt(m_sock, SOL_SOCKET, SO_REUSEADDR,  (char*)&opt, sizeof(opt))<0) {
        return false;
    }*/
    
    int ret=bind(m_sock, (struct sockaddr*)&svraddr, sizeof(svraddr));
    if (ret==SOCKET_ERROR) {
        return false;
    }
    return true;
}

bool ODSocket::Listen(int backlog)
{
    int ret=listen(m_sock, backlog);
    if (ret==SOCKET_ERROR) {
        return false;
    }
    return true;
}

bool ODSocket::Accept(ODSocket& s, char* fromip)
{
    struct sockaddr_in cliaddr;
	socklen_t addrlen = sizeof(cliaddr);
	SOCKET sock = accept(m_sock, (struct sockaddr*)&cliaddr, &addrlen);
	if ( sock == SOCKET_ERROR ) {
		return false;
	}
    
	s = sock;
	if ( fromip != NULL )
		sprintf(fromip, "%s", inet_ntoa(cliaddr.sin_addr));
    
	return true;
}

int ODSocket::Send(const char* buf, int len, int flags)
{
    int bytes;
    int count=0;
    while (count<len) {
        bytes=send(m_sock, buf+count, len-count, flags);
        if (bytes==-1) {
            return -1;
        }
        count=count+bytes;
    }
    printf("count=%d",count);
    return count;
}

int ODSocket::Recv(char* buf, int len, int flags)
{
    return (recv(m_sock, buf, len, flags));
}


int ODSocket::Close()
{
#ifdef WIN32
	return (closesocket(m_sock));
#else
	return (close(m_sock));
#endif
}

int ODSocket::GetError()
{
#ifdef WIN32
	return (WSAGetLastError());
#else
	return (errno);
#endif
}

bool ODSocket::DnsParse(const char* domain, char* ip)
{
	struct hostent* p;
	if ( (p = gethostbyname(domain)) == NULL )
		return false;
    
	sprintf(ip,
            "%u.%u.%u.%u",
            (unsigned char)p->h_addr_list[0][0],
            (unsigned char)p->h_addr_list[0][1],
            (unsigned char)p->h_addr_list[0][2],
            (unsigned char)p->h_addr_list[0][3]);
	
	return true;
}


