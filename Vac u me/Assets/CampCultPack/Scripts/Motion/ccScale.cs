using UnityEngine;
using System.Collections;

public class ccScale : MonoBehaviour {
	
	public Vector3 scalePerSecond = Vector3.zero;
	public Vector3 modScale = Vector3.zero;
	public Vector3 baseScale = Vector3.one;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 s = transform.localScale;
		s+=scalePerSecond*Time.deltaTime;

		if(!float.IsNaN(modScale.x) && modScale.x!=0)s.x = ((s.x-baseScale.x)%modScale.x)+baseScale.x;
		if(!float.IsNaN(modScale.y) && modScale.y!=0)s.y = ((s.y-baseScale.y)%modScale.y)+baseScale.y;
		if(!float.IsNaN(modScale.z) && modScale.z!=0)s.z = ((s.z-baseScale.z)%modScale.z)+baseScale.z;
		transform.localScale = s;
	}
}
