using UnityEngine;
using System.Collections;

public class WarpOnKey : MonoBehaviour {

	public GameObject ToWarp;
	public KeyCode key;
	public bool rotation;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key)){
			ToWarp.transform.position = transform.position;
			if(rotation)ToWarp.transform.rotation = transform.rotation;
		}
	}
}
