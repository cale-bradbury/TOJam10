using UnityEngine;
using System.Collections;

public class ccAnimateRotation: MonoBehaviour {
	public Vector3 axisMultiplier = Vector3.up*45;
	public AnimationCurve rotation;
	public float phase;
	public float phasePerSecond = 1f;

	// Update is called once per frame
	void Update () {
		phase+=phasePerSecond*Time.deltaTime;
		transform.localEulerAngles = axisMultiplier*rotation.Evaluate(phase%1.0f);
	}
}
