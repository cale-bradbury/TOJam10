using UnityEngine;
using System.Collections;
using System.Reflection;

public class EventVector4 : MonoBehaviour {
	public MonoBehaviour obj;
	public string varName;
	public string eventName;

	public bool xOn;
	public bool yOn;
	public bool zOn;
	public bool wOn;
	public Vector4 minValue;
	public Vector4 maxValue;

	
	// Use this for initialization
	void OnEnable () {
		Messenger.AddListener<float>(eventName,Eve);
	}
	void OnDisable () {
		Messenger.RemoveListener<float>(eventName,Eve);
	}

	void Eve(float v){
		if(varName=="")return;
		FieldInfo field = obj.GetType().GetField(varName);
		if(field == null)return;
		Vector4 vector = (Vector4)field.GetValue(obj);
		if(xOn){
			vector.x = (maxValue.x - minValue.x)*v+minValue.x;
		}
		if(yOn){
			vector.y = (maxValue.y - minValue.y)*v+minValue.y;
		}
		if(zOn){
			vector.z = (maxValue.z - minValue.z)*v+minValue.z;
		}
		if(wOn){
			vector.w = (maxValue.w - minValue.w)*v+minValue.w;
		}
		Debug.Log(vector);
		field.SetValue(obj,vector);
	}
}
