using UnityEngine;
using System.Collections;

public class ccRandomRotation : MonoBehaviour {
	
	public Vector3 minimumRotation = -Vector3.one*15;
	public Vector3 maximumRotation = Vector3.one*15;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localEulerAngles = new Vector3(
			Mathf.Lerp(minimumRotation.x,maximumRotation.x,Random.value),
			Mathf.Lerp(minimumRotation.y,maximumRotation.y,Random.value),
			Mathf.Lerp(minimumRotation.z,maximumRotation.z,Random.value)
		);
	}
}
