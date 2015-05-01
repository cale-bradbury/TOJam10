using UnityEngine;
using System.Collections;

public class ccRandomScale : MonoBehaviour {
	
	public Vector3 minimumScale = Vector3.one*.5f;
	public Vector3 maximumScale = Vector3.one;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale =new Vector3(
			Mathf.Lerp(minimumScale.x,maximumScale.x,Random.value),
			Mathf.Lerp(minimumScale.y,maximumScale.y,Random.value),
			Mathf.Lerp(minimumScale.z,maximumScale.z,Random.value)
		);
	}
}
