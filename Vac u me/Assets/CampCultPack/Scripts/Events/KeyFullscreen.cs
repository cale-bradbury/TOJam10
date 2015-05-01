using UnityEngine;
using System.Collections;

public class KeyFullscreen : MonoBehaviour {
	public KeyCode key = KeyCode.F;
	public Vector2 windowed = new Vector2(960,600);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key)){
			Screen.fullScreen = !Screen.fullScreen;
			if(Screen.fullScreen) Screen.SetResolution((int)windowed.x,(int)windowed.y,false);
			else Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
		}
	}
}
