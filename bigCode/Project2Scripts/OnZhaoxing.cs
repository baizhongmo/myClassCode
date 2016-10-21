using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnZhaoxing : MonoBehaviour {
	public GameObject huangzi;
	private CharacterController c;
	private Vector3 moveDirection = Vector3.zero;
	public Animator anim;
	public int ThinkTime = 4;
	private float currentTT;
	public int workTime=6;
	private float currentWT;
	public GameObject Ugui;
	public Slider slider;
	private bool isDeath = false;
	public UIProgressBar huangziHP;
	public float Fangyu = 1.0f;
	public Text Dengji;
	public UISlider jingyan;
	public GameObject xueping;
	// Use this for initialization
	void Start () {
		c = GetComponent <CharacterController> ();
		jiexiXML.jiexi ();
		Dengji .text  = (MyClass.zhaoxingdengji).ToString ();
		Fangyu = MyClass.zhaoxingfangyu;
	}
	void destorythis(){
		slider.value = 1;
		Dengji.text = (int.Parse (Dengji.text) + 1).ToString ();
		Fangyu += 0.5f;
		jiexiXML. setXml ("ZhaoxingDengji",Dengji.text  );
		jiexiXML.setXml ("ZhaoxingFangyu", Fangyu.ToString ());
		for (int i = 0; i < 2; i++) {
			float x = Random.Range (50, 400);
			float z = Random.Range (50, 400);
			Instantiate (this.gameObject, new Vector3 (x, 1, z), this.transform.rotation);
		}
		Instantiate (xueping.gameObject, this.transform.position+new Vector3 (0,1,0), this.transform.rotation);
		Destroy (this.gameObject);
	}
	// Update is called once per frame
	void Update () {
		Ugui.transform.LookAt (Camera.main.transform);
		if (slider.value == 0) {
			if (isDeath == false) {
				anim.SetTrigger ("TriggerToDie");
				Invoke ("destorythis", 6);
				isDeath = true;
			}
		} else if (huangziHP.value == 0) {
			anim.SetTrigger ("TriggerToIdle");
		}
		else if (Vector3.Distance (transform.position, huangzi.transform.position) < 15 &&
		    Vector3.Distance (transform.position, huangzi.transform.position) > 3) {
			transform.LookAt (huangzi.transform);
			anim.SetTrigger ("TriggerToRun");
			moveDirection = transform.TransformDirection (Vector3.forward);
			moveDirection = moveDirection * 2.5f * Time.deltaTime;
			moveDirection.y -= 9.8f * Time.deltaTime;
			c.Move (moveDirection);
		} else if (Vector3.Distance (transform.position, huangzi.transform.position) < 3) {
			transform.LookAt (huangzi.transform);
			anim.SetTrigger ("TriggerToBaoji");
		} else {


		
			currentWT += Time.deltaTime;
			if (currentWT > (workTime+ThinkTime)) {
				int x = (int)Random.Range (-2, 2);
				int z = (int)Random.Range (-2, 2);
				transform.LookAt (transform.position + new Vector3 (x, 0, z));
				currentWT = 0;
			}
			if (currentWT < workTime) {
				moveDirection = transform.TransformDirection (Vector3.forward);
				moveDirection = moveDirection * 1f * Time.deltaTime;
				moveDirection.y -= 9.8f * Time.deltaTime;
				c.Move (moveDirection);
				anim.SetTrigger ("TriggerToRun");
			} else {
				anim.SetTrigger ("TriggerToIdle");
			}

			//anim.SetTrigger ("TriggerToIdle");
		}
	
	}
	void OnTriggerStay(Collider coll){
		if (coll.gameObject .tag.Equals ("huangzibingqi")) {
			slider.value -= 0.11f*Time .deltaTime /Fangyu ;
			jingyan .value +=(0.08f*Time.deltaTime  / Fangyu)/2;
		}
		else if (coll.gameObject.tag.Equals ("jnn")) {
			slider.value -= 0.08f*Time.deltaTime  / Fangyu;
			jingyan .value +=(0.08f*Time.deltaTime  / Fangyu)/2;

		}
	}
}
