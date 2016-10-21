using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnZhizhu : MonoBehaviour {
	public GameObject huangzi;
	public CharacterController c;
	private Vector3 moveDirection = Vector3.zero;
	private Animator anim;
	public Slider slider;
	public GameObject ugui;
	public UIProgressBar huangziHP;
	public float Fangyu = 1.0f;
	public Text Dengji;
	public UISlider jingyan;
	public GameObject xueping;
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		jiexiXML.jiexi ();
		Dengji .text  = (MyClass.zhizhudengji).ToString ();
		Fangyu = MyClass.zhizhufangyu;
	}
	
	// Update is called once per frame
	void Update () {
		ugui.transform.LookAt (Camera.main.transform);
		if (slider.value == 0) {

			Invoke ("InstantiateAnimor", 0.5f);
		}
		else if(huangziHP.value ==0){
			anim.SetTrigger ("TriggerToIdle");
		}

		else if (Vector3.Distance (transform.position, huangzi.transform.position) < 15 &&
		    Vector3.Distance (transform.position, huangzi.transform.position) > 2) {
			moveDirection = transform.TransformDirection (Vector3.forward);
			moveDirection = moveDirection * 3.0f * Time.deltaTime;
			moveDirection.y -= 9.8f * Time.deltaTime;
			c.Move (moveDirection);
			transform.LookAt (huangzi.transform);
			anim.SetTrigger ("TriggerToRun");
		} else if (Vector3.Distance (transform.position, huangzi.transform.position) < 2) {
			anim.SetTrigger ("TriggerToAttack");
			transform.LookAt (huangzi.transform);
		} else {
			anim.SetTrigger ("TriggerToIdle");
		}
	
	}
	void InstantiateAnimor(){

		slider.value = 1;
		Dengji.text = (int.Parse (Dengji.text) + 1).ToString ();
		Fangyu += 0.6f;
		jiexiXML. setXml ("ZhizhuDengji",Dengji.text  );
		jiexiXML.setXml ("ZhizhuFangyu", Fangyu.ToString ());
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
			slider.value -= 0.03f*Time .deltaTime /Fangyu ;
			jingyan .value +=(0.08f*Time.deltaTime  / Fangyu)/2;
		}else if (coll.gameObject.tag.Equals ("jnn")) {
			slider.value -= 0.08f*Time.deltaTime  / Fangyu;
			jingyan .value +=(0.08f*Time.deltaTime  / Fangyu)/2;

		}
	}
}
