using UnityEngine;
using System.Collections;
using System.Reflection;

public class ccEventReflection : ccEventBase {

	public string varName;
	public Component obj;
	public FieldInfo field;
	float v = 0;
	float t = 0;

	protected override void OnEnable(){
		field = obj.GetType ().GetField (varName);
		base.OnEnable ();
	}

	protected override void OnEvent (){
		field.SetValue (obj, GetValue());
	}

	protected virtual object GetValue(){
		return null;
	}
}
