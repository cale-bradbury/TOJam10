using UnityEngine;
using System.Collections.Generic;

public class ObjectScript : MonoBehaviour {

	public static List<ObjectScript> all = new List<ObjectScript> ();

	public float weight = 1;
	public float value = 1;

	[HideInInspector]public Rigidbody body;

	// Use this for initialization
	void Start () {
		all.Add (this);
		body = GetComponent<Rigidbody> ();
		if (body == null) {
			body = gameObject.AddComponent<Rigidbody>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
