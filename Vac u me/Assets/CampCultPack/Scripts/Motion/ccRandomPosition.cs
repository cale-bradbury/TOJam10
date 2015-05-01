using UnityEngine;
using System.Collections;

public class ccRandomPosition : MonoBehaviour {
	
	public Vector3 minimumPosition = -Vector3.one;
	public Vector3 maximumPosition = Vector3.one;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition =new Vector3(
			Mathf.Lerp(minimumPosition.x,maximumPosition.x,Random.value),
			Mathf.Lerp(minimumPosition.y,maximumPosition.y,Random.value),
			Mathf.Lerp(minimumPosition.z,maximumPosition.z,Random.value)
		);
	}
}
