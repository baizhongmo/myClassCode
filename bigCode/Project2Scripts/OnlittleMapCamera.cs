using UnityEngine;
using System.Collections;

public class OnlittleMapCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void jia(){
	
		this.GetComponent <Camera > ().fieldOfView += 5;

	}
	public void jian(){
		this.GetComponent <Camera > ().fieldOfView -= 5;
	}
}
