using UnityEngine;
using System.Collections;

public class OnXueping : MonoBehaviour {
	public UISlider huangziHP;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider coll){
		if(coll.gameObject .tag .Equals ("Player")){
		
		huangziHP.value +=0.2f;
		Destroy (this.gameObject);
		}
	}
}
