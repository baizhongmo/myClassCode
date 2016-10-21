using UnityEngine;
using System.Collections;

public enum ObjectType{
	Drug,
	Equip,
	Mat
}
public class ObjectInfo  {
	public int id;
	public string name;
	public string iconName;
	public ObjectType type;
	public int hp;
	public int mp;
	public int priceSell;
	public int priceBuy;

}
