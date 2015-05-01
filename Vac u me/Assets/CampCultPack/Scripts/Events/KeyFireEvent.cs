using UnityEngine;
using System.Collections;

public class KeyFireEvent : MonoBehaviour {

	public KeyCode key;
	public string[] eventName;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key)){
			foreach(string e in eventName)Messenger.Broadcast(e);
		}
	}
}
