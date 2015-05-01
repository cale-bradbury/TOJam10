using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class EventSetMaterialColor : MonoBehaviour {
	public Material mat;
	public string colorName = "_Color";
	public Color color;
	[HideInInspector]
	public Color toColor;
	public string eventName;
	public float tweenTime = 1;
	// Use this for initialization
	void OnEnable () {
		Messenger.AddListener(eventName,OnFire);
	}
	void OnDisable(){
		Messenger.RemoveListener(eventName,OnFire);
	}
	
	// Update is called once per frame
	void OnFire () {
		if(tweenTime<=0)
			mat.SetColor(colorName,color);
		else{
			toColor = mat.GetColor(colorName);
			HOTween.To(this, tweenTime,new TweenParms().Prop("toColor",color).OnUpdate(UpdateColor).OnComplete(UpdateColor));
		}
	}

	void UpdateColor(){
		mat.SetColor(colorName,toColor);
	}
}
