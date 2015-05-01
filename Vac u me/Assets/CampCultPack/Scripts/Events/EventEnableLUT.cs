using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class EventEnableLUT : MonoBehaviour {

	public string enableEvent;
	public string disableEvent;
	public ColorCorrectionLUT lut;
	public Vector4 endValue = Vector3.one;
	public float time = 1;

	// Use this for initialization
	void Start () {
		Messenger.AddListener(enableEvent,On);
		Messenger.AddListener(disableEvent,Off);
	}
	
	// Update is called once per frame
	void On () {
		lut.enabled = true;
		HOTween.Kill(lut);
		HOTween.To(lut,time,"offset",endValue);
	}
	void Off () {
		HOTween.To(lut,time,new TweenParms().Prop("offset",Vector4.zero).OnComplete(Complete));
	}
	void Complete(){
		lut.enabled = false;
	}
}
