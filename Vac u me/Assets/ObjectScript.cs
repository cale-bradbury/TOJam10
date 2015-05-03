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

	public virtual void Collect(Vector3 target){
		Messenger.Broadcast (onCollectEvent);
		body.mass = 0;
		body.isKinematic = true;
		collected = true;
		HOTween.To (transform, .5f, new TweenParms ().Prop("position",target).OnComplete(Kill));
	}

	void Kill(){
		Destroy (gameObject);
	}
}
