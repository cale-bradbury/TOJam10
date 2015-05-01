using UnityEngine;
using System.Collections;

public class ccSineScale : MonoBehaviour {
	
	public Vector3 phasePerSecond = Vector3.one;
	public Vector3 basePhase = new Vector3(0,0,0);
	public Vector3 minimumScale = new Vector3(1,1,1);
	public Vector3 maximumScale = new Vector3(2,2,2);
	
	Vector3 phase = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		phase+=phasePerSecond*Time.deltaTime;
		transform.localScale = new Vector3(
			Mathf.Lerp(minimumScale.x,maximumScale.x,Mathf.Sin((phase.x+basePhase.x)*Mathf.PI*2)*.5f+.5f),
			Mathf.Lerp(minimumScale.y,maximumScale.y,Mathf.Sin((phase.y+basePhase.y)*Mathf.PI*2)*.5f+.5f),
			Mathf.Lerp(minimumScale.z,maximumScale.z,Mathf.Sin((phase.z+basePhase.z)*Mathf.PI*2)*.5f+.5f)
			);
		
	}
}
