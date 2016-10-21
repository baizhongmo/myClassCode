using UnityEngine;
using System.Collections;
using System .Xml ;

public class jiexiXML  {
	public static  string xmlFileName = "/xmlwenjian.xml";
	private static  string xmlFilePath=Application.streamingAssetsPath + xmlFileName;
	public jiexiXML _instance;
	// Use this for initialization
	private jiexiXML(){
		xmlFilePath = Application.streamingAssetsPath + xmlFileName;
		//jiexi ();
	}
		
	
	public   jiexiXML createInstance(){
		if (_instance == null) {
			_instance = new jiexiXML ();
		}
		return _instance;
	}
	

	public static 	void jiexi(){
	
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);
		XmlNode root = doc.SelectSingleNode ("Datas");
		foreach (XmlElement child in root) {
			if (child.Name == "HuangziDengji") {
				MyClass.huangzidengji =float .Parse (child.InnerText);

			} else if (child.Name == "ZhizhuDengji") {
				MyClass.zhizhudengji = float.Parse (child.InnerText);
			}else if (child.Name == "XiniuDengji") {

				MyClass.xiniudengji = float.Parse (child.InnerText);
			}else if (child.Name == "ZhaoxingDengji") {
				MyClass.zhaoxingdengji = float.Parse (child.InnerText);
			}else if (child.Name == "ZhizhuFangyu") {
				MyClass.zhizhufangyu = float.Parse (child.InnerText);
			}else if (child.Name == "XiniuFangyu") {
				MyClass.xiniufangyu = float.Parse (child.InnerText);

			}else if (child.Name == "ZhaoxingFangyu") {
				MyClass.zhaoxingfangyu = float.Parse (child.InnerText);
	
			}
		}
		doc.Save (xmlFilePath );

	}
	public static  void setXml(string setname,string  setdata){
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);
		XmlNode root = doc.SelectSingleNode ("Datas");
		foreach (XmlElement child in root) {
			if (child.Name == setname) {
				child.InnerText = setdata;
			}
		}
		doc.Save (xmlFilePath );
	}
	public static void ReSetXml(){
		XmlDocument doc = new XmlDocument ();
		doc.Load (xmlFilePath);
		XmlNode root = doc.SelectSingleNode ("Datas");
		foreach (XmlElement child in root) {
			child.InnerText = "1";
		}
		doc.Save (xmlFilePath);
	}

}
