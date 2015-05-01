using UnityEngine;
using System.Collections;

public class ccSinePosition : MonoBehaviour {
	
	public Vector3 phasePerSecond = Vector3.one;
	public Vector3 basePhase = new Vector3(.25f,0,0);
	public Vector3 minimumPosition = new Vector3(-.5f,-.5f,0);
	public Vector3 maximumPosition = new Vector3(.5f,.5f,0);
	
	Vector3 phase = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		phase+=phasePerSecond*Time.deltaTime;
		transform.localPosition = new Vector3(
			Mathf.Lerp(minimumPosition.x,maximumPosition.x,Mathf.Sin((phase.x+basePhase.x)*Mathf.PI*2)*.5f+.5f),
			Mathf.Lerp(minimumPosition.y,maximumPosition.y,Mathf.Sin((phase.y+basePhase.y)*Mathf.PI*2)*.5f+.5f),
			Mathf.Lerp(minimumPosition.z,maximumPosition.z,Mathf.Sin((phase.z+basePhase.z)*Mathf.PI*2)*.5f+.5f)
			);
	}
}
