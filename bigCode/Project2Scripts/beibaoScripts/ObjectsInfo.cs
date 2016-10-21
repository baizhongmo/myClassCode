using UnityEngine;
using System.Collections;
using System .Collections .Generic ;

public class ObjectsInfo : MonoBehaviour {
	public static ObjectsInfo _instance;
	public TextAsset objectsInfoList;
	private Dictionary <int ,ObjectInfo > objectDic = new Dictionary<int ,ObjectInfo> ();
	public UILabel label;
	// Use this for initialization
	void Awake(){
		_instance = this;
		ReadInfo ();
//		foreach (var item in objectDic) {
//			print (item);
//		}
//		print (objectDic [1001].iconName);
	}
	public ObjectInfo GetObjectInfoById(int key){
		ObjectInfo obj = new ObjectInfo ();
		objectDic.TryGetValue (key, out obj );
		return obj;
	}
	private void ReadInfo(){
		string text = objectsInfoList.text;
		string[] Arrstr = text.Split ('\n');
		foreach (string str in Arrstr) {
			string[] prostr = str.Split (',');
			ObjectInfo objectinfo = new ObjectInfo ();
			objectinfo.id =int.Parse ( prostr [0]);
			objectinfo.name = prostr [1];
			objectinfo.iconName = prostr [2];
		//	objectinfo.type = (ObjectType)prostr [3];
			if (prostr [3] == "Drug") {
				objectinfo.type = ObjectType.Drug;
			} else if (prostr [3] == "Equip") {
				objectinfo.type = ObjectType.Equip;
			}
			objectinfo.mp = int.Parse (prostr [4]);
			objectinfo.hp = int.Parse (prostr [5]);
			objectinfo.priceSell = int.Parse (prostr [6]);
			objectinfo.priceBuy = int.Parse (prostr [7]);

			objectDic.Add (objectinfo.id, objectinfo);

		}
	}
	private ObjectInfo info;
	public   void showDetail(int id){



		info = ObjectsInfo._instance.GetObjectInfoById (id);
		label.text = "id:" + info.id.ToString () + "\niconname:" + 
			info.iconName .ToString ()+"\nName:"+info.name  .ToString ()+
			"\nhp:"+info.hp+"\nmp:"+info.mp ;

	}

}
