using UnityEngine;
using System.Collections;

public class InventoryItem : UIDragDropItem {
	private UISprite sprite;
	private int id;
	private UILabel   numlabel;
	void Awake(){
		sprite = this.gameObject.GetComponent <UISprite > ();
		numlabel = this.gameObject.GetComponentInChildren<UILabel > ();
	}
	public void SetId(int id){
		ObjectInfo info= ObjectsInfo._instance.GetObjectInfoById (id);
	
		sprite.spriteName = info.iconName;
			
		this.id = id;
	}
	protected override  void OnDragDropRelease (GameObject surface){
		base.OnDragDropRelease (surface);
		if (surface != null) {
		
			if (surface.tag == "item") {
				print ("item");
		//		numlabel.SetActive (true);
				InventoryGird oldGrid = this.transform.parent.GetComponent<InventoryGird> ();
				int id = oldGrid.id;
				int num = oldGrid.num;
				InventoryGird newGrid = surface.transform.parent.GetComponent <InventoryGird > ();
				oldGrid.SetId (newGrid.id, newGrid.num);
				newGrid.SetId (id, num);
				guiwei ();
			} else if (surface.tag == "gird") {
				print ("grid");
			
				if ((surface.transform == this.transform.parent)) {
					guiwei ();

				}else {

				//	numlabel.SetActive (true);
					//InventoryGird nowGrid = surface.GetComponent <InventoryGird > ();
					InventoryGird oldGrid = this.transform.parent.GetComponent<InventoryGird > ();
					this.transform.parent = surface.transform;
					InventoryGird nowGrid = this.transform.parent.GetComponent<InventoryGird > ();
					//nowGrid.SetId (oldGrid.id, oldGrid.num);
//					nowGrid.id = oldGrid.id;
//					nowGrid.num = oldGrid.num;
					nowGrid.SetId (oldGrid.id, oldGrid.num);

					guiwei ();
					oldGrid.Clear ();
				}
			} else if(surface.tag == "zhuangbeiGird"){
				//numlabel.SetActive (false );
			
				InventoryGird oldGrid = this.transform.parent.GetComponent<InventoryGird > ();
				this.transform.parent = surface.transform;
				InventoryGird nowGrid = this.transform.parent.GetComponent<InventoryGird > ();

				nowGrid.SetId (oldGrid.id, oldGrid.num);
				numlabel.text = " ";
				guiwei ();
				oldGrid.Clear ();
			}
			else {
				guiwei ();
			}
		} else {
			guiwei ();
		}

	}
	private void guiwei(){
		this.transform.localPosition = Vector3.zero;
	}

	public void ShowD(){
	
		//OnDetail._instance . ShowDetail (this.id, this.transform.position);
		ObjectsInfo._instance . showDetail (this.id);

	}
	public void Hide(){
		OnDetail._instance.hide ();
	}

}
