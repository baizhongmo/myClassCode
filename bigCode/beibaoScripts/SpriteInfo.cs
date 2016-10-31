using UnityEngine;
using System.Collections;

public class SpriteInfo : MonoBehaviour {
	public  int[] id=new int[5];
	public  string[] spritenames = new string[5];
	public  int[] num = new int[5]; 
	public  string shopspritename;
	public  string sellspritename;
	public  string money;
	public static SpriteInfo instance;
	// Use this for initialization
	void Awake(){

		instance = this;

	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public  void setSpriteName(string spname){
//		print (spname);
		for (int i = 0; i < spritenames.Length; i++) {
			if (spritenames [i] == spname) {

				num [i] += 1;
				return;
			}
//			if (string.IsNullOrEmpty( spritenames [i])) {
			if(spritenames[i]=="nullSprite"||spritenames [i]=="" ){

				spritenames [i] = spname;
				num [i] += 1;
				return;
			} 
		}
	}
	public  void SellSprite(string spname){
		if (spname == "nullSprite") {
			print ("没有装备可以售卖");
			return;
		}
		for (int i = 0; i < spritenames.Length; i++) {
			if (spritenames [i] == spname) {
				num [i] -= 1;
				if (num [i] == 0) {
					sellspritename = "nullSprite";
					for (int j = i; j < spritenames.Length - 1; j++) {
						spritenames [j] = spritenames [j + 1];
						num [j] = num [j + 1];
					}
				}
			}
		
		}
	}
}
