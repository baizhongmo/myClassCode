using UnityEngine;
using System.Collections;
using System .Xml ;
using System .Collections .Generic ;

public class praseDragXML : MonoBehaviour {

	public static praseDragXML instance;
	private string xmlFileName1="/WeaponXml.xml";
	private  string xmlFilePath=string.Empty;
//	public string name;
//	public int price;
//	public int addHP;
//	private  string xmlFileName="/DragXML.xml";
//	private string xmlFileName2="/EquipXML.xml";
	public List <storeInfo > storeList = new List <storeInfo> ();
	void Awake(){
		instance = this;
		xmlFilePath = Application.streamingAssetsPath+ xmlFileName1;

	}
	void Start(){
		setToList ();
//		for(int i=0;i<storeList .Count ;i++){
//			print (storeList [i].itemName);
//			print (storeList [i].ID);
//			print (storeList [i].role);
//				}
	}
//	public void showInfo(){
//		getInfoById (1);
//		print (name);
//		print (price);
//		print (addHP);
//		tee ();
//	}
	public void setToList(){
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);
		XmlNode root = doc.SelectSingleNode ("Weapons");
		foreach (XmlElement child in root) {
			storeInfo storeinfo = new storeInfo ();
			foreach (XmlElement pro in child) {
				if (pro.Name == "ID") {
					storeinfo.ID = int.Parse (pro.InnerText);
				} else if (pro.Name == "name") {
					storeinfo.itemName = pro.InnerText;
				} else if (pro.Name == "price") {
					storeinfo.price = int.Parse (pro.InnerText);
				} else if (pro.Name == "introduction") {
					storeinfo.introduction = pro.InnerText;
				}else  {
					storeinfo.role = int.Parse (pro.InnerText);
				} 
			}
			storeList.Add (storeinfo);
		}
	}
//	public void tee(){
//		XmlDocument doc = new XmlDocument ();
//		doc.Load (xmlFilePath);
//		XmlNode root = doc.SelectSingleNode ("Weapons");
//		foreach (XmlElement child in root) {
//			foreach (XmlElement pro in child) {
//				print (pro.InnerText);
//			}
//		}
//	}
//	public void getInfoById(int id){
//		XmlDocument doc = new XmlDocument ();
//		doc.Load (xmlFilePath);
//		XmlNode root = doc.SelectSingleNode ("Drags");
//		foreach (XmlElement child in root) {
//			foreach (XmlElement pro in child ) {
//				if (pro.Name == "ID") {
//					if (pro.InnerText == id.ToString ()) {
//						foreach (XmlElement pro1 in child ){
//							if (pro1.Name =="name") {
//								name = pro1.InnerText;
//							}
//							if (pro1.Name == "price") {
//								price = int.Parse (pro1.InnerText);
//							}
//							if (pro1.Name == "addHP") {
//								addHP = int.Parse (pro1.InnerText);
//							}
//						}
//					}
//				
//				}
//			}
//		}
//		doc.Save (xmlFilePath);
//	}
}
