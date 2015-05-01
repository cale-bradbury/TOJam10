using UnityEngine;
using System.Collections;
using System.Reflection;

public class SineVector3 : MonoBehaviour {
	public MonoBehaviour obj;
	public string varName;
	
	public Vector3 phase;
	public Vector3 phasePerSecond;
	public Vector3 amplitude;
	public Vector3 amplitudeOffset;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(varName=="")return;
		FieldInfo field = obj.GetType().GetField(varName);
		if(field == null)return;
		phase+= phasePerSecond*Time.deltaTime;
		Vector3 result = new Vector3();
		result.x = Mathf.Sin(phase.x)*amplitude.x+amplitudeOffset.x;
		result.y = Mathf.Sin(phase.y)*amplitude.y+amplitudeOffset.y;
		result.z = Mathf.Sin(phase.z)*amplitude.z+amplitudeOffset.z;
		field.SetValue(obj,result);
	}
}
