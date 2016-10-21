using UnityEngine;
using System.Collections;

public class Onbg : MonoBehaviour {
	public  static Onbg _instance;
	private TweenPosition tweenposition;
	private bool isshow = true;
	// Use this for initialization
	void Start () {
		_instance = this;
		tweenposition = GetComponent <TweenPosition > ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Show(){
		if (isshow == true) {
			tweenposition.PlayForward ();
			isshow = false;
		}else {
			tweenposition.PlayReverse ();


			isshow = true;
		}
	}

}
