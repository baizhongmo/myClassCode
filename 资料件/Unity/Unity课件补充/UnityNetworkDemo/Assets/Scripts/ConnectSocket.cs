using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
public class ConnectSocket {
	public static Socket mySocket;

	private static ConnectSocket instance;
	public static System.Object o=new System.Object();

	public static ConnectSocket getSocketInstance(){
		if (instance == null) {
			instance = new ConnectSocket ();
		}
		return instance;
	}

	private ConnectSocket()
	{
		mySocket = new Socket (AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
		IPAddress ip = IPAddress.Parse ("127.0.0.1");
		IPEndPoint ipe = new IPEndPoint (ip,2001);
		IAsyncResult result = mySocket.BeginConnect (ipe,new AsyncCallback(connnectCallback),mySocket);
		result.AsyncWaitHandle.WaitOne (5000,true);

		if (mySocket.Connected) {
			Thread thread=new Thread(new ThreadStart(getMSG));
			thread.IsBackground=true;
			thread.Start();
		}

	}

	private void connnectCallback(IAsyncResult ast){
		Debug.Log ("Connnect Success");

	}

	private void getMSG()
	{
		while (true) {
			try{
				byte[] bytesLen=new byte[4];
				mySocket.Receive(bytesLen);
				int length=ByteUtil.byteArray2Int(bytesLen,0);

				byte[] bytes=new byte[length];
				int count=0;
				while(count<length){
					int tempLength=mySocket.Receive(bytes);
					count+=tempLength;
				}
				splitBytes(bytes);

			}catch(Exception e){
				Debug.Log(e.Message);
				break;
			}
		}
	}

	public void sendMSG(byte[] bytes){
		try{
			int length=bytes.Length;
			byte[] blength=ByteUtil.int2ByteArray(length);

			mySocket.Send(blength,SocketFlags.None);
			mySocket.Send(bytes,SocketFlags.None);

		}catch(Exception e){
			Debug.Log(e.Message);
		}
	}

	private void splitBytes(byte[] bytes)//接受数据后拆包
	{
		int length = bytes.Length;//获取包长
		if (length == 8)//是4位格式代表xOry
		{
			byte[] xb = { bytes[0], bytes[1], bytes[2], bytes[3] };
			byte[] yb = { bytes[4], bytes[5], bytes[6], bytes[7] };
			float tex = ByteUtil.byteArray2Float(xb, 0);
			float tey = ByteUtil.byteArray2Float(yb, 0);
			lock (o)
			{
				GameData.x = tex;
				GameData.y = tey;
			}
		}
	}

}
