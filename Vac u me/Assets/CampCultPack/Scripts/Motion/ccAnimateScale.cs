using UnityEngine;
using System.Collections;

public class ccAnimateScale: MonoBehaviour {
	public Vector3 axisMultiplier = Vector3.one;
	public AnimationCurve scale;
	public float phase;
	public float phasePerSecond = 1f;
	
	// Update is called once per frame
	void Update () {
		phase+=phasePerSecond*Time.deltaTime;
		transform.localScale = axisMultiplier*scale.Evaluate(phase%1.0f);
	}
}
