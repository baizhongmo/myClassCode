//
//  main.cpp
//  ClientDemo
//
//  Created by zyuq on 15-2-4.
//  Copyright (c) 2015年 a. All rights reserved.
//

#include <iostream>
#include "ODSocket.h"
int main(int argc, const char * argv[])
{

    ODSocket cSocket;
	cSocket.Init();
	cSocket.Create(AF_INET,SOCK_STREAM,0);
	if(cSocket.Connect("127.0.0.1",20000))
    {
        printf("true");
    }else
    {
        printf("false");
    }
    //cSocket.Send("zhuyuqiangzyuq123456",24,0);
   // char recvBuf[64] = "\0";
   // cSocket.Recv(recvBuf,64,0);
   // printf("%s was recived from server!\n",recvBuf);
	/*char recvBuf[64] = "\0";
    cSocket.Send("aaaaaaaaaaaaaabkuaaaajajajaajakkajkajajkajajajkajajajkajkajkajajkjajajajajkajajaaajaaaa",88,0);
	cSocket.Recv(recvBuf,64,0);
	printf("%s was recived from server!\n",recvBuf);
	cSocket.Close();
	cSocket.Clean();
    
	system("Pause");*/
    return 0;
}

