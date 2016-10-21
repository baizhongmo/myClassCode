using UnityEngine;
using System.Collections;

public class OnHuangZi : MonoBehaviour {
	private CharacterController c;
	private Animator anim;
	private Vector3 moveDirection = Vector3.zero;
	public float moveSpeed = 5.0f;
	public float pushPower = 2.0f;
	// Use this for initialization
	private bool iswork=false;
	private bool isfight=false;
	public GameObject effect2;
	public GameObject effect1;
	public GameObject effect3;
	public UIProgressBar mp;
	public UIProgressBar hp;
	private bool isDie = false;
	public float Fangyu = 1.0f;
	public UILabel huangzidengji;
	public UISlider jingyan;
	private   Vector3 vecMouse;
	private bool isRayWork=false;
	public GameObject RayPointEffect;
	private bool isRayPointEffectWork = false;
	void OnAwake(){

	}
	void Start () {

		c = this.GetComponent <CharacterController> ();
		anim = this.GetComponent <Animator> ();
		vecMouse = this.transform.position;

		jiexiXML.jiexi ();

		huangzidengji.text  = (MyClass.huangzidengji).ToString ();


	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButton (1)&&MyClass.dikong == false) {
			isRayPointEffectWork = false ;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					vecMouse = hit.point;
				}
			} else if (Vector3.Distance (vecMouse, this.transform.position) <= 0.5F) {
				if (isRayWork == true) {
					anim.SetTrigger ("TriggerToIdle");
					isRayWork = false;

				}
				vecMouse = this.transform.position;
			}
			if (Vector3.Distance (vecMouse, this.transform.position) > 0.5F && hp.value > 0.05f) {
				Vector3 step = Vector3.ClampMagnitude (vecMouse - this.transform.position, 0.2f);
			if (isRayPointEffectWork == false) {
				GameObject object1 = Instantiate (RayPointEffect, vecMouse, 
					                    anim.transform.rotation)as GameObject;
				Destroy (object1, 0.5f);
				isRayPointEffectWork = true;
			}
		
				if (isRayWork == false) {
					anim.SetTrigger ("TriggerToRun");
					isRayWork = true;
				}
				this.transform.LookAt (vecMouse);
				c.Move (step);
			}

		



		if (jingyan.value > 0.99f) {
			huangzidengji.text = (int.Parse (huangzidengji.text)+1).ToString ();

			jiexiXML. setXml ("HuangziDengji", huangzidengji.text);
			jingyan.value = 0;
		}

	
		//void FixedUpdate(){

		if (mp.value < 1) {
			mp.value += 0.008f*Time.deltaTime ;
		}
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		if (hp.value == 0) {
			if (isDie == false ) {
			
				anim.SetTrigger ("TriggerToDie");
				isDie = true;
			
			}
		}
		else if ((x != 0 || z != 0)) {
	
			//if (MyClass.dikong == true) {
				//transform .LookAt (new Vector3 (transform .position .x+x1,transform .position .y,transform .position .z));
				if (isRayWork == false) {
					transform.Rotate (new Vector3 (0, x * 3, 0), Space.Self);
					moveDirection = transform.TransformDirection (new Vector3 (0, 0, z));
					moveDirection = moveDirection * 5.0f * Time.deltaTime;
					moveDirection.y -= 9.8f * Time.deltaTime;
					c.Move (moveDirection);
					if (iswork == false || isfight == true) {
						if (isfight = true) {
							Invoke ("Run", 0.2f);
						}
						anim.SetTrigger ("TriggerToRun");
						iswork = true;

						isfight = false;

					}
				}
			} else {
				if (iswork == true) {
					anim.SetTrigger ("TriggerToIdle");
					iswork = false;

				}
		//	}
	}
//}
	}
	void Run(){
		anim.SetTrigger ("TriggerToRun");
	}
	public void ToSkill1(){
		if (mp.value > 0.1f&&hp.value >0) {
			anim.SetTrigger ("TriggerToSkill1");
			GameObject obj1 = Instantiate (effect1, anim.transform.position + Vector3.forward, 
				                 anim.transform.rotation)as GameObject;
			Destroy (obj1, 2.5f);
			iswork = true;
			isfight = true;
			mp.value -= 0.1f;
		}
	}

	public void ToSkill2(){
		if (mp.value > 0.1f&&hp.value >0) {
			anim.SetTrigger ("TriggerToSkill2");
			GameObject obj1 = Instantiate (effect2, anim.transform.position + Vector3.forward, 
				                 anim.transform.rotation)as GameObject;
			Destroy (obj1, 2.5f);
			iswork = true;
			mp.value -= 0.1f;
		}
	}

	public void ToSkill3(){
		if (mp.value > 0.1f&&hp.value >0) {
			anim.SetTrigger ("TriggerToSkill3");
			GameObject obj1 = Instantiate (effect3, anim.transform.position + Vector3.forward, 
				                 anim.transform.rotation)as GameObject;
			Destroy (obj1, 2.5f);
			iswork = true;
			mp.value -= 0.1f;
		}
	}

	public void Baoji(){
		if (hp.value > 0) {
			anim.SetTrigger ("TriggerToBaoji");
			iswork = true;
		}
	}
	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag.Equals ("direnbingqi")) {
			hp.value -= 0.01f/Fangyu;
		}
	}
	private bool gaibianshijiao=true;
	public void ChangeView(){
		if (gaibianshijiao == true) {
			MyClass.dikong = false;
			gaibianshijiao = false;
		}else if(gaibianshijiao==false ){
			MyClass.dikong = true;
			gaibianshijiao = true;
		}
	}


}
