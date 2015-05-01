using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Camera))]
public class FOVSine : MonoBehaviour {

	public float min = 35;
	public float max = 110;
	public float seconds = 5;
	float c = 0;
	// Update is called once per frame
	void Update () {
		c+= Mathf.PI*2/seconds*Time.deltaTime;
		GetComponent<Camera>().fieldOfView = (Mathf.Sin(c)*0.5f+0.5f)*(max-min)+min;
	}
}
