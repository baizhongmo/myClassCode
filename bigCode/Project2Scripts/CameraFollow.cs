using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject hero;
	public float height;
	public float distance;
	private float wantedRotation = 0;
	private bool isClick=false;
	private bool isFirstEye=false ;
	public void heightUp(){
		height += 2;
	}
	public void heightDown(){
		height -= 2;
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		distance += Input.GetAxis ("Mouse ScrollWheel") * 10;
		if (!hero) {
			return;
		}
		if (MyClass.dikong == true) {
			wantedRotation = hero.transform.eulerAngles.y;
			if (isClick == false) {
				height = 2;
				distance = 6;
			}
				
			isClick = true;
		} else if (MyClass.dikong == false) {
			if (isClick == true) {
				height = 20;
				distance = 10;
			}
			isClick = false;
		}
		float wantedHeight = hero.transform.position.y + height;

		var currentRotation = Quaternion.Euler (0, wantedRotation, 0);

		transform.position = hero.transform.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		transform.position = new Vector3 (transform.position.x, wantedHeight, transform.position.z);
		if (isFirstEye == false ) {
			this.transform.LookAt (hero.transform);
		} else {
			this.transform.LookAt (hero.transform.position + new Vector3 (0, 0, 5));
		
		}

	}


	public void ChangeRencheng(){
		if (isFirstEye == true) {
			isFirstEye = false;
			height = 2;
			distance = 6;
		} else if (isFirstEye == false) {
			isFirstEye = true;
			height = 1;
			distance = -2f;
		}
	}

//	public Transform target;
//	public float zDistance = 5f;
//	public float yHeight = 2f;
//
//	public float zDamping = 2f;
//	public float yDamping = 4f;
//
//	private float oulajiao;
//	private float temp=0;
//	private float z;
//	// Use this for initialization
//	void Start () {
//
//	}
//
//	// Update is called once per frame
//	void LateUpdate () {
//
//		float currentY = transform.position.y;
//		float targetY = target.position.y + yHeight;
//		float y = Mathf.Lerp (currentY,targetY,yDamping*Time.deltaTime);
//
//		float currentRotationY = transform.eulerAngles.y;
//		float targetRotationY = target.eulerAngles.y;
//		float yAngel = Mathf.LerpAngle (currentRotationY,targetRotationY,3f*Time.deltaTime);
//
//		transform.position = target.position;//(x,0,z)
//
//		//四元数*向量(向量长度就是半径)  能够表示一个圆弧上的坐标位置
//		transform.position -= Quaternion.Euler (0,yAngel,0) * Vector3.forward * zDistance;
//
//		transform.position = new Vector3(transform.position.x,y,transform.position.z);
//		//LookAt能够改变相机旋转角度达到一直观看着某个坐标位置不变
//		//		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y +
//		//			5, target.position.z - 10);
//
//
//		//		 oulajiao =target.transform.eulerAngles.y  ;
//		//
//		//			transform.RotateAround (target.transform.position, new Vector3 (0, 1, 0),-(temp - oulajiao));
//		//
//		//		temp = oulajiao;
//		//		z = Input.GetAxis ("Vertical");
//		//		this.transform.Translate (new Vector3(0,0,z*0.3f), Space.Self);
//
//
//
//		transform.LookAt(target);
//	}





}
