using UnityEngine;
using System.Collections;

public class ccSineRotation : MonoBehaviour {

	public Vector3 phasePerSecond = Vector3.one;
	public Vector3 basePhase = new Vector3(.25f,0,0);
	public Vector3 minimumAngle = new Vector3(-45,-45,0);
	public Vector3 maximumAngle = new Vector3(45,45,0);

	Vector3 phase = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		phase+=phasePerSecond*Time.deltaTime;
		transform.localEulerAngles = new Vector3(
			Mathf.Lerp(minimumAngle.x,maximumAngle.x,Mathf.Sin((phase.x+basePhase.x)*Mathf.PI*2)*.5f+.5f),
			Mathf.Lerp(minimumAngle.y,maximumAngle.y,Mathf.Sin((phase.y+basePhase.y)*Mathf.PI*2)*.5f+.5f),
			Mathf.Lerp(minimumAngle.z,maximumAngle.z,Mathf.Sin((phase.z+basePhase.z)*Mathf.PI*2)*.5f+.5f)
		);
	}
}
