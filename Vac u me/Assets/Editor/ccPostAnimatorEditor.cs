using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(ccPostAnimator))]
public class ccPostAnimatorEditor: Editor{

	List<string> vars;

	public override void OnInspectorGUI (){
		ccPostAnimator post = (ccPostAnimator)target;

		//get gameobject the holds all the mono behaviours
		post.effectHolder = (GameObject)EditorGUILayout.ObjectField ("script holder",post.effectHolder, typeof(GameObject));

		//get the efect, and find vars to fuck with
		ImageEffectBase o = (ImageEffectBase)EditorGUILayout.ObjectField ("Image Effect",post.effect, typeof(ImageEffectBase), true);
		if (o != post.effect||vars==null) {
			post.effect = o;
			GetFields (o);
		}

		GUILayout.BeginHorizontal ();
		//add a new animfloat
		if (GUILayout.Button ("Add new")) {
			post.animations.Add (post.effectHolder.AddComponent<ccAnimFloat>());
		}
		//clean up holder, 
		//looks for ccAnimFloats targeting the same object and if it isn't tied to this animator then destroy it
		//ensures all components are attached to the right holder
		if (GUILayout.Button ("cleanup object")) {
			ccAnimFloat[] all = post.effectHolder.GetComponents<ccAnimFloat> ();
			foreach (ccAnimFloat a in all) {
				if (a.obj == post.effect && post.animations.IndexOf (a) == -1)
					DestroyImmediate (a);
				else if (a.gameObject != post.effectHolder)
					Utils.MoveComponent (a, post.effectHolder);
			}
		}
		GUILayout.EndHorizontal ();

		//show vars for each animfloat
		ccAnimFloat remove = null;
		for (int i = 0; i<post.animations.Count; i++) {
			EditorGUILayout.Space();
			ccAnimFloat a = post.animations[i];
			a.obj = post.effect;
			int j = Mathf.Max(0,vars.IndexOf(a.varName));
			j = EditorGUILayout.Popup("Var",j,vars.ToArray());
			if(j<vars.Count)
				a.varName = vars[j];
			a.animation = EditorGUILayout.CurveField("Animation",a.animation);
			a.minValue = EditorGUILayout.FloatField("Min Value", a.minValue);
			a.maxValue = EditorGUILayout.FloatField("Max Value", a.maxValue);
			a.animationTime = EditorGUILayout.FloatField("Anim Time", a.animationTime);
			GUILayout.BeginHorizontal();
			if(GUILayout.Button("play"))a.Play();
			GUI.color = Color.red;
			if(GUILayout.Button("delete")){
				if(EditorUtility.DisplayDialog("Really delete?","Are you sure you want to delete this animation? (can NOT undo)","delete","nvm"))
					remove = a;
			}
			GUI.color = Color.white;
			GUILayout.EndHorizontal();
		}
		if (remove != null) {
			post.animations.Remove(remove);
			DestroyImmediate(remove);
		}
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


