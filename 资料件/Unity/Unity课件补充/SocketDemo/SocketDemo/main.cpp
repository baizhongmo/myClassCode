//
//  main.cpp
//  SocketDemo
//
//  Created by zyuq on 15-3-22.
//  Copyright (c) 2015年 a. All rights reserved.
//
#include <iostream>
#include <string>
#include "stdio.h"
#include <sys/socket.h>
#include <netinet/in.h>
#include <netdb.h>
#include <fcntl.h>
#include <unistd.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <arpa/inet.h>
typedef int		SOCKET;
#define sendLen 100
void shortToByte(short i,char *bytes,int size = 2);
void shortToByte(short i,char *bytes,int size)
{
    memset(bytes,0,sizeof(char)*size);
    bytes[1] = (char)(0x00ff & i);
    bytes[0] = (char)((0xff00 & i) >> 8);
    return ;
}
short bytesToShort(char* src, int offset) {
    int value;
    value = (short)(((src[offset] & 0xFF)<<8)
                    |(src[offset+1] & 0xFF));
    return value;
}
//1。void *memset(void *s,int c,size_t n)
//　总的作用：将已开辟内存空间 s 的首 n 个字节的值设为值 c。
//2、memcpy 函数用于 把资源内存（src所指向的内存区域） 拷贝到目标内存（dest所指向的内存区域）；拷贝多少个？有一个size变量控制
int main(int argc, const char * argv[]) {
    short int x;
    char x0,x1;
    x=0x1122;
    x0=((char*)&x)[0]; //低地址单元
    x1=((char*)&x)[1]; //高地址单元
    if (x0==0x11) {
        printf("big");
    }else
    {
        printf("small");
    }
    
//
    //创建socket
    SOCKET sclient=socket(AF_INET,SOCK_STREAM,IPPROTO_TCP);
    //连接服务器
    struct sockaddr_in servaddr;
    servaddr.sin_family=AF_INET;
servaddr.sin_addr.s_addr=inet_addr("127.0.0.1"); //指定服务器
servaddr.sin_port=htons(20101);             //指定端口
    connect(sclient,(struct sockaddr*)&servaddr,sizeof(servaddr)); //通过套接字连接主机
    //发送数据
    char buf[sendLen];
    std::cout<<"输入发送内容：";
    while(std::cin.getline(buf,sendLen))
    {
        //通过套接字给主机发送字符串,前两个字节卫type，三4为长度，后面为内容
        short len = strlen(buf);
        char* buffer = new char[len+4];
        shortToByte(20,buffer);//假设20表示一种id
        shortToByte(len,buffer+2);
        memcpy(buffer+4,buf,len);
        send(sclient,buffer,len+4,0);  //字符串还有个结束标志，
        char recvBuf[100];
        recv(sclient,recvBuf,100,0);
        short a=bytesToShort(recvBuf, 0);
        short b=bytesToShort(recvBuf, 2);
        short c=bytesToShort(recvBuf, 4);
        printf("a=%hd,b=%hd,c=%hd\n",a,b,c);
        printf("%s",recvBuf+6);
       // 接收时候，前两个为总长度，后两个为type，最后为长度
    }
    return 0;
}
