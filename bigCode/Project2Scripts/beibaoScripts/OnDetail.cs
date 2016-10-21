using UnityEngine;
using System.Collections;

public class OnDetail : MonoBehaviour {
	private UILabel label;
	public static OnDetail _instance;
	private ObjectInfo info;
	void Awake(){
		//_instance = this;
		_instance = this;
		label = this.gameObject.GetComponentInChildren<UILabel > ();
	}
	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public   void ShowDetail(int id,Vector3 v3){
	
		this.gameObject.SetActive (true);
		this.transform.position = v3 + new Vector3 (0, 0.5f, 0);
		info = ObjectsInfo._instance.GetObjectInfoById (id);
		label.text = "id:" + info.id.ToString () + "\niconname:" + 
			info.iconName .ToString ()+"\nType:"+info.type .ToString ()+
			"\nhp:"+info.hp+"\nmp:"+info.mp ;

	}
	public void hide(){
		this.gameObject.SetActive (false);
	}
}
