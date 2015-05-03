using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

	public static void ZeroChildPosition (Transform transform){
		for(int i = 0; i<transform.childCount;i++){
			ZeroChildPosition(transform.GetChild(i));
		}
	}

	public static List<T> RandomizeList<T> (List<T> list){
		List<T> a = new List<T>();
		while (list.Count!=0) {
			int i = Mathf.FloorToInt(Random.value*list.Count);
			a.Add(list[i]);
			list.RemoveAt(i);
		}
		list = null;
		return a;
	}
}
