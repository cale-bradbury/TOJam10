using UnityEngine;
using System.Collections;

public class KeyLockMouse : MonoBehaviour {
	public KeyCode key;
	public bool unlock = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key)){
			if(unlock)Screen.lockCursor = !Screen.lockCursor;
			else Screen.lockCursor = true;
		}
	}
}
