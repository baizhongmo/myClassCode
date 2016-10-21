using UnityEngine;
using System.Collections;

public class OnSelectHerocamera : MonoBehaviour {
	public GameObject go;
	public GameObject ruiwen;
	public GameObject monkey;
	public GameObject ruiwenLabel;
	public GameObject monkeyLabel;
	public GameObject Right;
	public GameObject Left;
	public GameObject jieshaotankuang;
	// Use this for initialization
	void Start () {
		iTween.MoveTo (this.gameObject, iTween.Hash ("time", 20, "looktarget", go.transform, "path",
					iTweenPath.GetPath ("New Path 1")));
		Invoke ("showtankuang",9);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void monkeybut(){
		iTween.MoveTo (this.gameObject, iTween.Hash ("time", 20, "looktarget", go.transform, "path",
			iTweenPath.GetPath ("New Path 1")));
		jieshaotankuang.SetActive (false);
		Invoke ("showtankuang", 9);
		ruiwen.SetActive (true);
		ruiwenLabel.SetActive (true);
		Left.SetActive (true);
		monkey.SetActive (false);
		monkeyLabel.SetActive (false);
		Right.SetActive (false);

	}
	public void ruiwenbut(){
		iTween.MoveTo (this.gameObject, iTween.Hash ("time", 20, "looktarget", go.transform, "path",
			iTweenPath.GetPath ("New Path 1")));
		jieshaotankuang.SetActive (false);
		Invoke ("showtankuang", 9);
		ruiwen.SetActive (false);
		ruiwenLabel.SetActive (false);
		Left.SetActive (false);
		monkey.SetActive (true);
		monkeyLabel.SetActive (true);
		Right.SetActive (true);
	}
	public void showtankuang(){
		jieshaotankuang.SetActive (true);
	}
	public void ChangeScene(){
		Application.LoadLevel (4);
	}
	public void ReSetXML(){
		jiexiXML.ReSetXml ();
		Application.LoadLevel (4);
	}
}
