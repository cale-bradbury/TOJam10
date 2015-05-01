using UnityEngine;
using System.Collections;
using System.Reflection;

public class SineValue : MonoBehaviour {

	public MonoBehaviour obj;
	public string varName;

	public float phase;
	public float phasePerSecond;
	public float amplitude;
	public float amplitudeOffset;
	public FieldInfo field;

	// Use this for initialization
	void OnEnable () {
		field = obj.GetType().GetField(varName);
	}
	
	// Update is called once per frame
	void Update () {
		if(varName==""||field==null)return;

		phase+= phasePerSecond*Time.deltaTime;
		float val = Mathf.Sin(phase)*amplitude+amplitudeOffset;
		field.SetValue(obj,val);
	}
}
