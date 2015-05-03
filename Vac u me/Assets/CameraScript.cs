using UnityEngine;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour {

	public List<string> events;
	public List<Vector3> rotations;
	public float lerp = .1f;
	Vector3 target;

	// Use this for initialization
	void Start () {
		target = transform.localEulerAngles;
		foreach (string s in events) {
			Messenger.AddListener(s,OnEvent);
		}
	}

	void OnEvent () {
		int i = events.IndexOf(Messenger.lastCalled);
		target = rotations [i];
	}

	void Update(){
		transform.localEulerAngles = Vector3.Lerp (transform.localEulerAngles, target, lerp);
	}
}
