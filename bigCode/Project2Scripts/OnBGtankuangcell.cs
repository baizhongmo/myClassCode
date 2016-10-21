using UnityEngine;
using System.Collections;

public class OnBGtankuangcell : MonoBehaviour {
	public UILabel label;
	private UILabel cellLabel;
	private GameObject tankuang;
	// Use this for initialization
	void Start () {
		cellLabel = GetComponentInChildren<UILabel > ();
		tankuang = GameObject.Find ("tankuang");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ChangeLabel(){
		label.text = cellLabel.text;
		tankuang.SetActive (false);
	}
}
