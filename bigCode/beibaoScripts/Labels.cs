using UnityEngine;
using System.Collections;

public class Labels : MonoBehaviour {
	public static Labels instance;
//	public UILabel id;
	public UILabel name;
	public UILabel price;
	public UILabel role;
	public UILabel introduction;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	

}
