using UnityEngine;
using System.Collections;

public class NozzleScript : MonoBehaviour {

	public Transform lookTarget;
	public float lerp = .1f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion v = transform.localRotation;
		transform.LookAt (lookTarget.position);
		v = Quaternion.Lerp(v,transform.localRotation,lerp);
		transform.localRotation = v;
	}
}
