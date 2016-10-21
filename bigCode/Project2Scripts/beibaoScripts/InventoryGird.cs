using UnityEngine;
using System.Collections;

public class InventoryGird : MonoBehaviour {
	public int id = 0;
	public int num = 0;
	private ObjectInfo info = null;
	private UILabel numlabel;
	// Use this for initialization
	void Start () {
		numlabel = this.GetComponentInChildren<UILabel > ();
		SetId (id, num);
	}
	
	public void SetId(int id,int num){
		numlabel = this.GetComponentInChildren<UILabel > ();
		if (id == 0) {
			print ("id is not exist");
			return;
		}
		info = ObjectsInfo._instance.GetObjectInfoById (id);
		InventoryItem item = this.GetComponentInChildren<InventoryItem> ();
		this.id = id;
		this.num = num;
		numlabel.text = this.num.ToString ();
		numlabel.enabled = true;
		item.SetId (id);
	}
	public void ClearInfo(){
		id = 0;
		num = 0;
		info = null;
		numlabel.enabled = false;
	}
	public void Clear(){
		id = 0;
		num = 0;
	}
}
