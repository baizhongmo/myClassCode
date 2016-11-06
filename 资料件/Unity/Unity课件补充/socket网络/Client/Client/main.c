//
//  main.cpp
//  Client
//
//  Created by zyuq on 15-2-4.
//  Copyright (c) 2015年 a. All rights reserved.
//


#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>
#include <netdb.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <unistd.h>
#define SERVPORT 3333
#define MAXDATASIZE 100
int main(int argc, const char * argv[])
{

    int sockfd,sendbytes;
    char buf[MAXDATASIZE];
    struct sockaddr_in serv_addr;
    if((sockfd=socket(AF_INET,SOCK_STREAM,0))== -1){
	    perror("socket");
	    exit(1);
    }
    
    serv_addr.sin_family=AF_INET;
    serv_addr.sin_port=htons(SERVPORT);
serv_addr.sin_addr.s_addr=inet_addr("127.0.0.1");
    bzero(&(serv_addr.sin_zero),8);
    
    if(connect(sockfd,(struct sockaddr *)&serv_addr,
               sizeof(struct sockaddr))== -1){
	    perror("connect");
	    exit(1);
    }
  
    if((sendbytes=send(sockfd,"testa",6,0))== -1){
	    perror("send");
	    exit(1);
    }
    printf("send\n");
   int recvBytes=recv(sockfd,buf,MAXDATASIZE,0);
    printf("buf=%s",buf);
    printf("recev=%d",recvBytes);
   // memset(buf, '\0', 64);
    printf("\n");
    sleep(5);
    recv(sockfd,buf,MAXDATASIZE,0);
    printf("buf=%s",buf);
    close(sockfd);

    return 0;
}

