using UnityEngine;
using System.Collections;

public class OnBGSelectLabelFrame : MonoBehaviour {
	public GameObject tankuang;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ShowTankuang(){
		tankuang.SetActive (true);
	}
	public void ChangeScene(){
		Application.LoadLevel (2);
	}
}
