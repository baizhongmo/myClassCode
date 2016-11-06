using UnityEngine;
using System.Collections;
using System.Threading;
public class XianShi : MonoBehaviour {
	Object n=new Object();
	long shu=0;
	long xian=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lock (n) {
			xian=shu;
		}
	}

	void OnGUI(){
		GUI.Label (new Rect(200,200,200,50),xian.ToString());
		if (GUI.Button (new Rect (100, 100, 100, 50), "Thread")) {
			Thread a=new Thread(run);
			a.Start();
		}
		if (GUI.Button (new Rect (250, 100, 100, 50), "Main")) {
			run ();
		}

		if (GUI.Button (new Rect (400, 100, 100, 50), "Zero")) {
			lock(n){
				shu=0;
			}
		}
	}

	void run(){
		long te = 0;
		for (long i=0; i<10000000; i++) {
			te+=1;
		}
		lock (n) {
			shu=te;
		}
	}
}
