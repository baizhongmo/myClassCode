using UnityEngine;
using System.Collections;

public class OnMenuBeibao : MonoBehaviour {
	public GameObject beibaoFrame;
	// Use this for initialization
	void Start () {
		beibaoFrame.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void showBeibaoFrame(){
		beibaoFrame.SetActive (true);
	}
	public void hideBeibaoFrame(){
		beibaoFrame.SetActive (false);
	}
}
