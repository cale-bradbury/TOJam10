using UnityEngine;
using System.Collections;

public class EventPlaySound : MonoBehaviour {
	public string eventName;
	public AudioSource audio;
	// Use this for initialization
	void Start () {
		Messenger.AddListener(eventName,Play);
	}
	
	// Update is called once per frame
	void Play () {
		audio.Play();
	}
}
