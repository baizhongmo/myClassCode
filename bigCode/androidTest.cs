using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;
using System.IO;
using System;
using System.Collections.Generic;


public class androidTest : MonoBehaviour {
    Text datapath;
    string path;
	// Use this for initialization
	void Start () {
        datapath = GameObject.Find("Text").GetComponent<Text>();
        prasexml();
	}

    private void prasexml()
    {
   
        if (Application.platform == RuntimePlatform.Android)
        {
            path = Application.streamingAssetsPath + "/testxml.xml";
        }
        else {
            path = "file://" + Application.streamingAssetsPath + "/testxml.xml";
        }
        StartCoroutine(xiazai(path));

    }
   IEnumerator  xiazai(string str) {
       WWW www = new WWW(str);
       yield return www;
       datapath.text = www.text;
       //print(www.text);
       jiexixml(www  );
    }

   private void jiexixml(WWW w)
   {
       StreamWriter sw;
       FileInfo t = new FileInfo(Application.persistentDataPath + "//" + "FileName.txt");
       if (!t.Exists)
       {
           //如果此文件不存zai
           DeleteFile(Application.persistentDataPath, "FileName.txt");
           CreateFile(Application.persistentDataPath, "FileName.txt", w.text);
       }
      
     
    
    
       XmlDocument doc = new XmlDocument();
       doc.Load(Application.persistentDataPath + "/FileName.txt");
       var x = doc.SelectSingleNode("root").FirstChild.FirstChild.InnerText;
       var y = doc.SelectSingleNode("root").FirstChild.FirstChild.NextSibling.InnerText;
       datapath.text = x + y;
       print(doc.SelectSingleNode("root").FirstChild.FirstChild.InnerText);
       //doc.SelectSingleNode("root").FirstChild.FirstChild.InnerText = "300";
       doc.Save(Application.persistentDataPath + "/FileName.txt");
       
       //string ss = w.text;
       //XmlDocument doc = new XmlDocument();
       //doc.LoadXml(ss);
       //var x = doc.SelectSingleNode("root").FirstChild.FirstChild.InnerText;
       //var y = doc.SelectSingleNode("root").FirstChild.FirstChild.NextSibling.InnerText;
       //datapath.text = x + y;
       
   }
   public void jia3() {
       XmlDocument doc = new XmlDocument();
       doc.Load(Application.persistentDataPath + "/FileName.txt");
       var x = doc.SelectSingleNode("root").FirstChild.FirstChild.InnerText;
       var y = doc.SelectSingleNode("root").FirstChild.FirstChild.NextSibling.InnerText;
       datapath.text = x + y;
       print(doc.SelectSingleNode("root").FirstChild.FirstChild.InnerText);
       //doc.SelectSingleNode("root").FirstChild.FirstChild.InnerText = "300";
       doc.SelectSingleNode("root").FirstChild.FirstChild.InnerText =
           (int.Parse(doc.SelectSingleNode("root").FirstChild.FirstChild.InnerText) + 3).ToString();
       doc.Save(Application.persistentDataPath + "/FileName.txt");
   }
   void DeleteFile(string path, string name)
   {
       File.Delete(path + "//" + name);

   }
   void CreateFile(string path, string name, string info)
   {
       //文件流信息
       StreamWriter sw;
       FileInfo t = new FileInfo(path + "//" + name);
       if (!t.Exists)
       {
           //如果此文件不存在则创建
           sw = t.CreateText();
       }
       else
       {
           //如果此文件存在则打开
           sw = t.AppendText();
       }
       //以行的形式写入信息
       sw.WriteLine(info);
       //关闭流
       sw.Close();
       //销毁流
       sw.Dispose();
   }  
	// Update is called once per frame
	void Update () {
	
	}
}
