using UnityEngine;
using System.Collections;

public class ccAnimatePosition: MonoBehaviour {
	public Vector3 axisMultiplier = Vector3.up;
	public AnimationCurve position;
	public float phase;
	public float phasePerSecond = 1f;
	
	// Update is called once per frame
	void Update () {
		phase+=phasePerSecond*Time.deltaTime;
		transform.localPosition = axisMultiplier*position.Evaluate(phase%1.0f);
	}
}
