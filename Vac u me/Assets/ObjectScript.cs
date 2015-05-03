using UnityEngine;
using System.Collections.Generic;
using Holoville.HOTween;

public class ObjectScript : MonoBehaviour {

	public Game.Type[] types;

	public float weight = 1;
	public float value = 1;
	public string onCollectEvent;

	[HideInInspector]
	public bool collected = false;

	[HideInInspector]public Rigidbody body;

	// Use this for initialization
	public virtual void Start () {

		Game.all.Add (this);
		body = GetComponent<Rigidbody> ();
		if (body == null) {
			body = gameObject.AddComponent<Rigidbody>();
		}
		body.mass = weight;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnDestroy(){
		Game.all.Remove (this);
	}

	public virtual void Collect(){
		Messenger.Broadcast (onCollectEvent);
		Destroy (body);
		Game.all.Remove(this);
		Renderer r = GetComponent<Renderer> ();
		if (r == null) {
			foreach(Renderer rend in GetComponentsInChildren<Renderer>()){
				rend.material.SetFloat("_HoloMode", 1);
			}
		} else {
			r.material.SetFloat ("_HoloMode", 1);
		}
		collected = true;
	}

	void Kill(){
		Destroy (gameObject);
	}
}
