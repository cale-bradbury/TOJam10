using UnityEngine;
using System.Collections;

public class EventEnableAudio : MonoBehaviour {
	
	public string eventName;
	public AudioSource[] behaviours;
	public bool enable = true;
	
	// Use this for initialization
	void Start () {
		Messenger.AddListener(eventName,Fire);
	}
	
	// Update is called once per frame
	void Fire () {
		foreach(AudioSource m in behaviours){
			m.enabled = enable;
			m.Play();
		}
	}
}
