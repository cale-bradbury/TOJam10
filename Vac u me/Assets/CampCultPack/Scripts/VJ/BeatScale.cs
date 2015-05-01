using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class BeatScale : MonoBehaviour {

	public string eventName;
	public float fadeSpeed = .5f;
	public Vector3 minScale = Vector3.zero;
	public Vector3 maxScale = Vector3.one;
	public bool useValue = true;
	Tweener t;
	
	// Use this for initialization
	void OnEnable () {
		Messenger.AddListener<float>(eventName,Beat);
	}

	void OnDisable(){
		Messenger.RemoveListener<float>(eventName,Beat);
	}

	void Beat(float v){
		transform.localScale = maxScale*(useValue?v:1);
		if(t!=null)t.Kill();
		t = HOTween.To(transform,fadeSpeed,"localScale",minScale);
	}
}
