using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class EventReturnToStart : MonoBehaviour
{

	public string eventName;
	public float time;
	public EaseType ease;
	Vector3 start;
	Vector3 rot;

	// Use this for initialization
	void Start ()
	{
		start = transform.position;
		rot = transform.eulerAngles;
		Messenger.AddListener(eventName,Return);
	}

	void Return(){
		GetComponent<Rigidbody>().isKinematic = true;
		HOTween.To (transform,time, new TweenParms().Prop("position", start).Ease(ease));
		HOTween.To (transform,time, new TweenParms().Prop("eulerAngles", rot).Ease(ease));
	}

}

