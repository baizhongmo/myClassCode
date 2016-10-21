using UnityEngine;
using System.Collections;

public class OnUIHuangzi : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnDrag(Vector2 vec){
		float y = vec.x  ;
		this.transform.Rotate (0,-y, 0);
	}
}
