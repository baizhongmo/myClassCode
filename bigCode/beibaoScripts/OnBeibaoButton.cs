using UnityEngine;
using System.Collections;

public class OnBeibaoButton : MonoBehaviour {
	public GameObject beibao;
	public UISprite[] zhuangbei;
	public UILabel [] Num;
	public static OnBeibaoButton instance;
	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public 	void OnClick(){

		beibao.SetActive (true);
	
		for (int i = 0; i < SpriteInfo.instance.spritenames.Length; i++) {
			Num [i].text = SpriteInfo.instance.num [i].ToString ();
			if (SpriteInfo.instance.spritenames [i] == null) {
				zhuangbei [i].spriteName = "nullSprite";
				zhuangbei [i].GetComponent <UIButton > ().normalSprite = "nullSprite";
								continue;
			}
			zhuangbei [i].spriteName = SpriteInfo.instance.spritenames [i];
			zhuangbei [i].GetComponent <UIButton > ().normalSprite=SpriteInfo.instance.spritenames [i];
		}
//		for (int i = 0; i < zhuangbei.Length ; i++) {
//			Num [i].text = praseInfoXML.instance.getSpriteNum (i);
//			if (praseInfoXML.instance.getSpriteName (i) == "") {
//				zhuangbei [i].spriteName = "nullSprite";
//				zhuangbei [i].GetComponent <UIButton > ().normalSprite = "nullSprite";
//				continue;
//			}
//
//			string spritename=praseInfoXML.instance.getSpriteName (i);
//			zhuangbei [i].spriteName =spritename;
//			zhuangbei [i].GetComponent <UIButton > ().normalSprite = spritename;
//
//
//
//
//		}

	}

}
