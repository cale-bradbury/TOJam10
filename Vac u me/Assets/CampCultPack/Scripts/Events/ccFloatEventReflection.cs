using UnityEngine;
using System.Collections;
using System.Reflection;

public class ccFloatEventReflection : ccFloatEventBase {

	public string varName;
	public Component obj;
	public FieldInfo field;
	public bool round = false;
	float v = 0;
	float t = 0;

	protected override void OnEnable(){
		field = obj.GetType ().GetField (varName);
		v = t = (float) field.GetValue (obj);
		base.OnEnable ();
	}

	void Update(){
		if (round) {
			if (v != t) {
				v = Mathf.Lerp(v,t,.2f);
				field.SetValue (obj, v);
			}
		}
	}

	protected override void OnEvent (float f){
		if (round) {
			t = Mathf.Round(f);
		} else {
			field.SetValue (obj, f);
		}
	}

}
