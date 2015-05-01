using UnityEngine;
using System.Collections;
using System.Reflection;

public class Utils : MonoBehaviour {

	static public void DestroyAllChildrenIn(GameObject obj,bool recurse){
		for(int i = obj.transform.childCount-1;i>=0;i--){
			if(recurse)DestroyAllChildrenIn(obj.transform.GetChild(i).gameObject,true);
			GameObject.Destroy(obj.transform.GetChild(i).gameObject);
		}
	}

	static public void MoveComponent(Component c, GameObject moveTo){
		Component b = moveTo.AddComponent(c.GetType());
		foreach (FieldInfo f in c.GetType().GetFields()){
			f.SetValue(b, f.GetValue(c));
		}
		DestroyImmediate (c);
	}
}
