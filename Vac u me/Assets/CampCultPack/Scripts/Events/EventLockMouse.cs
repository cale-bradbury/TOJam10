using UnityEngine;
using System.Collections;

public class EventLockMouse : MonoBehaviour {

	public string lockEvent;
	public string unlockEvent;

	// Use this for initialization
	void OnEnable () {
		Messenger.AddListener(lockEvent,Lock);
		Messenger.AddListener(unlockEvent,Unlock);
	}
	void OnDisable () {
		Messenger.RemoveListener(lockEvent,Lock);
		Messenger.RemoveListener(unlockEvent,Unlock);
	}
	
	// Update is called once per frame
	void Lock () {
		if(lockEvent==unlockEvent)Screen.lockCursor = !Screen.lockCursor;
		else Screen.lockCursor = true;
	}

	void Unlock(){
		if(lockEvent==unlockEvent)Screen.lockCursor = !Screen.lockCursor;
		else Screen.lockCursor = false;
	}
}
