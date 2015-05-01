﻿using UnityEngine;
using System.Collections;

public class ccEventBase : MonoBehaviour {

	public string eventName;

	virtual protected void OnEnable () {
		Messenger.AddListener (eventName, OnEvent);
	}
	virtual protected void OnDisable () {
		Messenger.RemoveListener (eventName, OnEvent);
	}

	virtual protected void OnEvent () {
		
	}
}
