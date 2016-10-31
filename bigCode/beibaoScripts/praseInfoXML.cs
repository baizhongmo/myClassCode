using UnityEngine;
using System.Collections;
using System .Xml ;
public class praseInfoXML : MonoBehaviour {
	public static praseInfoXML instance;
	private string xmlFileName="/InfomationXML.xml";
	private  string xmlFilePath=string.Empty;
	public  int totalSprite=5; 
	void Awake(){
		instance = this;
		xmlFilePath = Application.streamingAssetsPath + xmlFileName;
	}
	// Use this for initialization
	void Start () {
		parseToMemory ();

	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void testSet(){
		setSpriteName ("wanjiawu");
	}
	public void testGet(){
		print (getSpriteName (3));

	}
	public void parseToMemory(){

		SpriteInfo.instance.money = getMoney ();


		for (int i = 0; i < totalSprite ; i++) {
			SpriteInfo.instance.spritenames [i] = getSpriteName (i);
			SpriteInfo.instance.num [i] = int.Parse (getSpriteNum (i));
		}
		print (SpriteInfo.instance.money);
	}
	public void testGetNum(){
		print (getSpriteNum (0));
	}
	public string  getMoney(){
	
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);
		XmlNode root = doc.SelectSingleNode ("Sprites");
		foreach (XmlElement child in root) {
			if (child.Name == "Money") {

				return child.InnerText;
			}
		}
		return "0";
	}
	public void setMoney(string money){
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);
		XmlNode root = doc.SelectSingleNode ("Sprites");
		foreach (XmlElement child in root) {
			if (child.Name == "Money") {
				child.InnerText = money;
				doc.Save (xmlFilePath);
				return;
			}
		}
	
	}
	public void SetXMLInfo(){
//		for (int i = 0; i < totalSprite; i++) {
//			print (SpriteInfo.instance.spritenames [i]);
//		}
		setMoney (SpriteInfo.instance.money);
		for (int i = 0; i < totalSprite; i++) {
			XmlDocument doc = new XmlDocument ();
			doc.Load (xmlFilePath);
			XmlNode root = doc.SelectSingleNode ("Sprites");
			foreach (XmlElement  child in root) {
				if (child.Name == "Sprite"){
					foreach (XmlElement pro in child) {
						if (pro.Name == "ID" && pro.InnerText == i.ToString ()) {
							XmlNode node = pro.NextSibling;
							node.InnerText = SpriteInfo.instance.spritenames [i];
							node = node.NextSibling;
							node.InnerText = SpriteInfo.instance.num [i].ToString ();
						}
					}
				}

			}

			doc.Save (xmlFilePath);
		}
	}
	public void ClearAll(){
		setMoney ("1000");
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);
		XmlNode root = doc.SelectSingleNode ("Sprites");
		foreach (XmlElement  child in root) {
			if (child.Name == "Sprite") {
				foreach (XmlElement pro in child) {
					if (pro.Name == "SpriteName") {
						pro.InnerText = "nullSprite";
						XmlNode node = pro.NextSibling;
						node.InnerText = "0";
					}
				
				}
			}
		}
		for (int i = 0; i < totalSprite ; i++) {
			SpriteInfo.instance.spritenames [i] = getSpriteName (i);
			SpriteInfo.instance.num [i] = int.Parse (getSpriteNum (i));
		}
		doc.Save (xmlFilePath);

	}

	public void setSpriteName(string sname){
	
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);
		XmlNode root = doc.SelectSingleNode ("Sprites");
		foreach (XmlElement  child in root) {
			foreach (XmlElement pro in child) {
				if (pro.Name == "SpriteName" && pro.InnerText == sname) {
					XmlNode node = pro.NextSibling;
					node.InnerText = (int.Parse (node.InnerText) + 1).ToString ();
					doc.Save (xmlFilePath);
					return;
				}
				if (pro.Name == "SpriteName" && pro.InnerText == "") {
			
					pro.InnerText = sname;
					XmlNode node = pro.NextSibling;
					node.InnerText = (int.Parse (node.InnerText) + 1).ToString ();
					doc.Save (xmlFilePath);
					return;
				}
			}

		}

	}
	public string getSpriteName(int index){
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);
		XmlNode root = doc.SelectSingleNode ("Sprites");
		foreach (XmlElement  child in root) {

			foreach (XmlElement pro in child) {
			
				if (pro.Name =="ID"&&pro.InnerText == index.ToString ()) {

					XmlNode node = pro.NextSibling;
				
					return node.InnerText;
				}
			}
		}

		return "nullSprite";
	}
	public string  getSpriteNum(int index){
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);
		XmlNode root = doc.SelectSingleNode ("Sprites");
		foreach (XmlElement  child in root) {

			foreach (XmlElement pro in child) {

				if (pro.Name =="ID"&&pro.InnerText == index.ToString ()) {

					XmlNode node = pro.NextSibling;
					node = node.NextSibling;
					return  node.InnerText;
				}
			}
		}

		return "0";
	
	}
}
