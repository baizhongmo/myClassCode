//
//  main.cpp
//  Server
//
//  Created by zyuq on 15-2-4.
//  Copyright (c) 2015年 a. All rights reserved.
//


#include <sys/types.h>
#include <sys/socket.h>
#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>
#include <unistd.h>
#include <netinet/in.h>

#define SERVPORT 3333
#define BACKLOG 10
#define MAX_CONNECTED_NO 10
#define MAXDATASIZE 5
int main(int argc, const char * argv[])
{
    ssize_t sendBytes;
   //socket地址描述信息
    struct sockaddr_in server_sockaddr,client_sockaddr;
    int sin_size,recvbytes;
    int sockfd,client_fd;
    char buf[MAXDATASIZE];
    //创建socket，返回socket描述浮，－1表示失败
    if((sockfd = socket(AF_INET,SOCK_STREAM,0))== -1){
	    perror("socket");
	    exit(1);
    }
    printf("socket success!,sockfd=%d\n",sockfd);
    //指定协议家族
    server_sockaddr.sin_family=AF_INET;
    //指定端口号
    server_sockaddr.sin_port=htons(SERVPORT);
    //服务器IP信息
    server_sockaddr.sin_addr.s_addr=INADDR_ANY;
    bzero(&(server_sockaddr.sin_zero),8);
   //
   //绑定
    if(bind(sockfd,(struct sockaddr *)&server_sockaddr,sizeof(struct sockaddr))== -1){
	    perror("bind");
	    exit(1);
    }
    printf("bind success!\n");
    //监听
    if(listen(sockfd,BACKLOG)== -1){
	    perror("listen");
	    exit(1);
    }
    printf("listening....\n");
    //accept阻塞函数，等待客户端链接
    if((client_fd=accept(sockfd,(struct sockaddr *)&client_sockaddr,&sin_size))== -1){
	    perror("accept");
	    exit(1);
    }
    printf("accept finished");
    //接受客户端发送的数据
    if((recvbytes=recv(client_fd,buf,MAXDATASIZE,0))== -1){
	    perror("recv");
	    exit(1);
    }
    
    send(client_fd, "yy", 3, 0);
    send(client_fd, "xx", 3, 0);
    //给客户端发送数据
    if((sendBytes=send(client_fd,"testa",6,0))== -1){
	    perror("send");
	    exit(1);
    }
    sleep(5);
    printf("send=%zd",sendBytes);
   int m= send(client_fd, "xx", 3, 0);
    printf("sendm=%zd",m);
    close(sockfd);

    return 0;
}

