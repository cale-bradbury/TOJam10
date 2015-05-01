using UnityEngine;
using System.Collections;
using System.Reflection;

public class SineVector4 : MonoBehaviour {
	public MonoBehaviour obj;
	public string varName;
	
	public Vector4 phase;
	public Vector4 phasePerSecond;
	public Vector4 amplitude;
	public Vector4 amplitudeOffset;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(varName=="")return;
		FieldInfo field = obj.GetType().GetField(varName);
		if(field == null)return;
		phase+= phasePerSecond*Time.deltaTime;
		Vector4 result = new Vector4();
		result.x = Mathf.Sin(phase.x)*amplitude.x+amplitudeOffset.x;
		result.y = Mathf.Sin(phase.y)*amplitude.y+amplitudeOffset.y;
		result.z = Mathf.Sin(phase.z)*amplitude.z+amplitudeOffset.z;
		result.w = Mathf.Sin(phase.w)*amplitude.w+amplitudeOffset.w;
		field.SetValue(obj,result);
	}
}
