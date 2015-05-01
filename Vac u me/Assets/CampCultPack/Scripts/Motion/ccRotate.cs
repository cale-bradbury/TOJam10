using UnityEngine;
using System.Collections;

public class ccRotate : MonoBehaviour {

	public Vector3 degreesPerSecond = Vector3.zero;
	public Vector3 modRotation = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(degreesPerSecond*Time.deltaTime);
		Vector3 r = transform.localEulerAngles;
		if(!float.IsNaN(modRotation.x) && modRotation.x!=0)r.x %= modRotation.x;
		if(!float.IsNaN(modRotation.y) && modRotation.y!=0)r.y %= modRotation.y;
		if(!float.IsNaN(modRotation.z) && modRotation.z!=0)r.z %= modRotation.z;
		transform.localEulerAngles = r;
	}
}
