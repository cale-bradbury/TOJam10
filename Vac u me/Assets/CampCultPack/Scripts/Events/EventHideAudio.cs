using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class EventHideAudio : MonoBehaviour {
	
	public string eventName;
	public AudioSource[] behaviours;
	public float time = 3;
	public string postEvent;
	
	// Use this for initialization
	void Start () {
		Messenger.AddListener(eventName,Fire);
	}
	
	// Update is called once per frame
	void Fire () {
		foreach(AudioSource m in behaviours){
			HOTween.To(m, time,"volume",0);
		}
		Invoke("Foo",time);
	}

	public void Foo(){
		Messenger.Broadcast(postEvent);
	}
}
