using UnityEngine;
using System.Collections;

public class Sell : MonoBehaviour {
//	private UISprite zhangbei;
	public  GameObject sellButton;
	// Use this for initialization
	void Start () {

//		zhangbei = this.GetComponent <UISprite > ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick(){
		SpriteInfo.instance.sellspritename = this.GetComponent <UISprite> ().spriteName;
		print (SpriteInfo.instance.sellspritename);
		if (SpriteInfo.instance.sellspritename!= "nullSprite") {
			sellButton.SetActive (true);
			for (int i = 0; i < praseDragXML.instance.storeList.Count; i++) {
				if (SpriteInfo.instance.sellspritename==praseDragXML.instance.storeList [i].ID.ToString ()) {
//					Labels.instance .id.text = praseDragXML.instance.storeList [i].ID.ToString ();
					Labels.instance .name.text = praseDragXML.instance.storeList [i].itemName;
					Labels.instance .price.text = praseDragXML.instance.storeList [i].price.ToString ();
					Labels.instance .role.text = praseDragXML.instance.storeList [i].role.ToString ();
					Labels.instance .introduction.text = praseDragXML.instance.storeList [i].introduction;
					return;
					print (praseDragXML.instance.storeList [i].itemName);


				}
			}
		}
	}
	public void sellButtonEvent(){

		SpriteInfo.instance.SellSprite (SpriteInfo.instance.sellspritename);
		OnBeibaoButton.instance.OnClick ();
		SpriteInfo.instance.money = (int.Parse (SpriteInfo.instance.money) +100).ToString ();
	}
}
