using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(ccFloatEventReflection))]
public class ccFloatEventReflectionEditor: Editor{
	
	List<string> vars;
	
	public override void OnInspectorGUI (){
		ccFloatEventReflection t = (ccFloatEventReflection)target;
		
		//get gameobject the holds all the mono behaviours
		t.eventName = EditorGUILayout.TextField ("Event Name",t.eventName);
		t.minValue = EditorGUILayout.FloatField ("Min Value", t.minValue);
		t.maxValue = EditorGUILayout.FloatField ("Max Value", t.maxValue);
		//get the efect, and find vars to fuck with
		Component o = (Component)EditorGUILayout.ObjectField ("Component",t.obj, typeof(Component), true);
		if (o != t.obj||vars==null) {
			t.obj = o;
			GetFields (o);
		}

		int j = Mathf.Max(0,vars.IndexOf(t.varName));
		j = EditorGUILayout.Popup("Var",j,vars.ToArray());
		if(j<vars.Count)
			t.varName = vars[j];
		t.round = EditorGUILayout.Toggle ("Round",t.round);
	}
	
	void GetFields(object o){
		vars = new List<string> ();
		if (o == null)
			return;
		FieldInfo[] fields = o.GetType ().GetFields ();
		foreach (FieldInfo f in fields) {
			if(f.FieldType == typeof(float)){
				vars.Add(f.Name);
			}
		}
	}
}


