﻿using UnityEngine;
using System.Collections;

public class ccFloatEventBase : MonoBehaviour {

	public string eventName;
	public float minValue = 0;
	public float maxValue = 1;
	
	virtual protected void OnEnable () {
		Messenger.AddListener<float> (eventName, PreEvent);
	}
	virtual protected void OnDisable () {
		Messenger.RemoveListener<float> (eventName, PreEvent);
	}

	void PreEvent(float f){
		OnEvent (Mathf.Lerp (minValue, maxValue, f));
	}
	
	virtual protected void OnEvent (float f) {
		
	}
}
