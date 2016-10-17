using UnityEngine;
using System.Collections;
using System.Threading;
public class ThreadTest : MonoBehaviour {
	bool flag=true;
	// Use this for initialization
	void Start () {
		Thread thread = new Thread (Run);
		thread.Start ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Run(){
		while(flag){
			Debug.Log("run");
			Thread.Sleep(1000);
		}
	}

	void OnApplicationQuit(){
		print ("quit");
		flag = false;
	}
}
