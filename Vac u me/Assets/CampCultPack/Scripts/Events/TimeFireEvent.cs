using UnityEngine;
using System.Collections;

public class TimeFireEvent : MonoBehaviour {
	
	public string eventName;
	public float time;
	// Use this for initialization
	void Start () {
		Invoke ("Fire", time);
	}

	void Fire(){
		Messenger.Broadcast (eventName);
		Invoke ("Fire", time);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
