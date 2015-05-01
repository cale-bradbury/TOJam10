using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class EventTweenProp : MonoBehaviour {

	public string eventName;
	public MonoBehaviour obj;
	public string varName;
	public float endValue;
	public float time;
	public EaseType ease;

	// Use this for initialization
	void Start () {
		Messenger.AddListener(eventName,Fire);
	}
	
	// Update is called once per frame
	void Fire () {
		HOTween.To (obj,time,new TweenParms().Prop(varName,endValue).Ease(ease));
	}
}
