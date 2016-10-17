//
//  main.cpp
//  ServerDemo
//
//  Created by zyuq on 15-2-4.
//  Copyright (c) 2015年 a. All rights reserved.
//

#include <iostream>
#include "ODSocket.h"
int main(int argc, const char * argv[])
{
    ODSocket mysocket,clientsocket;
	mysocket.Init();
	mysocket.Create(AF_INET,SOCK_STREAM,0);
	mysocket.Bind(7880);
	mysocket.Listen();
	char ipClient[64];
	char recvBuf[64] = "\0";
	while(1)
	{
		mysocket.Accept(clientsocket,ipClient);
		printf("%s was log in!\n",ipClient);
		clientsocket.Recv(recvBuf,64,0);
		printf("%s was recived from Client:%s!\n",recvBuf,ipClient);
		recvBuf[0] = '\0';
		clientsocket.Send("aaa",strlen("aaa")+1,0);
	}
	mysocket.Close();
	mysocket.Clean();
	system("Pause");

}

