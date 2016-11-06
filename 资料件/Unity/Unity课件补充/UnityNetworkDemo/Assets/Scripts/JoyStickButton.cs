using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
public class JoyStickButton : MonoBehaviour {

	private ConnectSocket mySocket;
	void Start()
	{
		if (mySocket == null)
		{
			mySocket = ConnectSocket.getSocketInstance();
		}
	}
	void OnEnable()  
	{  
		EasyJoystick.On_JoystickMove += OnJoystickMove;
	}
	
	void OnDisable()
	{
		EasyJoystick.On_JoystickMove -= OnJoystickMove;
	}
	
	void OnDestroy()
	{
		EasyJoystick.On_JoystickMove -= OnJoystickMove;
	}

	//移动摇杆中  
	void OnJoystickMove(MovingJoystick move)
	{
		Debug.Log ("moe");
		float joyPositionX = move.joystickAxis.x/10;
		float joyPositionY = move.joystickAxis.y/10;
		byte[] x = ByteUtil.float2ByteArray(joyPositionX);
		byte[] y = ByteUtil.float2ByteArray(joyPositionY);
		byte[] sendMSG ={ 
			x[0],x[1],x[2],x[3],
			y[0],y[1],y[2],y[3]
		};

		mySocket.sendMSG (sendMSG);
	}

}
