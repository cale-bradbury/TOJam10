using UnityEngine;
using System.Collections;
using System.Reflection;

public class ccEventSetTexture : ccEventBase {

	public Component obj;
	public string varName;
	public Texture tex;
	public FieldInfo field;

	protected override void OnEnable ()
	{
		field = obj.GetType ().GetField (varName);
		base.OnEnable ();
	}

	protected override void OnEvent (){
		field.SetValue (obj, tex);
	}
}
