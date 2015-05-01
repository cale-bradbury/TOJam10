using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosiveForce : MonoBehaviour {

	public List<GameObject> all;
	public float force = 1;
	public float radius = 10;


	// Use this for initialization
	void OnEnable () {
		foreach(GameObject g in all){
			g.GetComponent<Rigidbody>().AddExplosionForce(force,transform.position,radius);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
