using UnityEngine;
using System.Collections;
using System.Reflection;

public class ccEventFieldBase : ccEventBase {
	public MonoBehaviour obj;
	public string varName;

	FieldInfo field;

	override protected void OnEnable () {
		base.OnEnable ();
		field = obj.GetType().GetField(varName);
	}
	
	// Update is called once per frame
	override protected void OnEvent () {
		base.OnEvent ();
		if (field == null)
			return;
		field.SetValue (obj, GetValue ());
	}
	
	virtual protected object GetValue(){
		return null;
	}
	virtual protected void SetValue(object o){
		field.SetValue (obj, o);
	}
}
