using UnityEngine;
using System.Collections;
using UnityEngine.UI ;

public class OnXiniu : MonoBehaviour {
	private  Animation anim;
	public GameObject huangzi;
	public CharacterController c;
	private Vector3 MoveDirection = Vector3.zero;
	public GameObject ugui;
	public Slider slider;
	private bool isDeath=false ;
	public UIProgressBar huangziHP;
	public float Fangyu = 1.0f;
	public Text dengji;
	public UISlider jingyan;
	public GameObject xueping;
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animation> ();

		anim.Play  ("Idle_01");
		jiexiXML.jiexi ();
		dengji .text  = (MyClass.xiniudengji).ToString ();
		Fangyu = MyClass.xiniufangyu;

	}
	
	// Update is called once per frame
	void Update () {
		ugui.transform.LookAt (Camera.main.transform);
		if (slider.value == 0) {
			if (isDeath == false) {
				anim.CrossFade ("Death", 0.5f);
				Invoke ("destorythis", 5);
				isDeath = true;
			}

		} else if (huangziHP.value == 0) {
			anim.CrossFade ("Idle_02");
		}
		else if (Vector3.Distance (transform.position, huangzi.transform.position) < 15&&
			Vector3.Distance (transform.position, huangzi.transform.position)>3.5f) {
			transform.LookAt (huangzi.transform);
			MoveDirection = transform.TransformDirection (Vector3.forward);
			MoveDirection = MoveDirection * 2 * Time.deltaTime;
			MoveDirection.y -= 9.8f * Time.deltaTime;
			c.Move (MoveDirection);
			anim.CrossFade ("Run");
		} else if(Vector3.Distance (transform.position, huangzi.transform.position)<3.5f){
			transform.LookAt (huangzi.transform);
			anim.CrossFade ("Attack");
		}
		else {
			anim.CrossFade ("Idle_02");
		}

	}

	void destorythis(){

		slider.value = 1;
		dengji.text = (int.Parse (dengji.text) + 1).ToString ();
		Fangyu += 0.8f;
		jiexiXML. setXml ("XiniuDengji",dengji.text  );
		jiexiXML.setXml ("XiniuFangyu", Fangyu.ToString ());
		for (int i = 0; i < 2; i++) {
		
			float x = Random.Range (50, 400);
			float z = Random.Range (50, 400);
			Instantiate (this.gameObject, new Vector3 (x, 1, z), this.transform.rotation);
		}
		Instantiate (xueping.gameObject, this.transform.position+new Vector3 (0,1,0), this.transform.rotation);
		Destroy (this.gameObject);
	}
	void OnTriggerStay(Collider coll){

		if (coll.transform.tag.Equals ("huangzibingqi")) {
			slider.value -= 0.08f*Time.deltaTime  / Fangyu;
			jingyan .value +=(0.08f*Time.deltaTime  / Fangyu)/2;

		} else if (coll.gameObject.tag.Equals ("jnn")) {
			slider.value -= 0.08f*Time.deltaTime  / Fangyu;
			jingyan .value +=(0.08f*Time.deltaTime  / Fangyu)/2;
		}
	}
}
