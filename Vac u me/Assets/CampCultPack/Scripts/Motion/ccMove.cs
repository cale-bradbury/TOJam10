using UnityEngine;
using System.Collections;

public class ccMove : MonoBehaviour {
	
	public Vector3 movePerSecond = Vector3.zero;
	public Vector3 modMove = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 s = transform.localPosition;
		s+=movePerSecond*Time.deltaTime;
		
		if(!float.IsNaN(modMove.x) && modMove.x!=0)s.x %= modMove.x;
		if(!float.IsNaN(modMove.y) && modMove.y!=0)s.y %= modMove.y;
		if(!float.IsNaN(modMove.z) && modMove.z!=0)s.z %= modMove.z;
		transform.localPosition = s;
	}
}
