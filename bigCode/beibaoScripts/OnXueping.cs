using UnityEngine;
using System.Collections;

public class OnXueping : MonoBehaviour {
//	public GameObject label;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick(){
//		label.SetActive (true);


		SpriteInfo.instance.shopspritename = this.GetComponent <UISprite > ().spriteName;

		for (int i = 0; i < praseDragXML.instance.storeList.Count; i++) {
			if (SpriteInfo.instance.shopspritename ==praseDragXML.instance.storeList [i].ID.ToString ()) {
//				Labels.instance .id.text = praseDragXML.instance.storeList [i].ID.ToString ();
				Labels.instance .name.text = praseDragXML.instance.storeList [i].itemName;
				Labels.instance .price.text = praseDragXML.instance.storeList [i].price.ToString ();
				Labels.instance .role.text = praseDragXML.instance.storeList [i].role.ToString ();
				Labels.instance .introduction.text = praseDragXML.instance.storeList [i].introduction;
				return;
				print (praseDragXML.instance.storeList [i].itemName);


			}
		}
	
	}
	public void LabelEvent(){
		print (SpriteInfo.instance.money);
		if (int.Parse ( SpriteInfo.instance.money) <= 0) {
			print ("lack of money");
			return;
		}
		SpriteInfo.instance.setSpriteName (SpriteInfo.instance.shopspritename);
		SpriteInfo.instance.money = (int.Parse (SpriteInfo.instance.money) -100).ToString ();

	
	}
}
