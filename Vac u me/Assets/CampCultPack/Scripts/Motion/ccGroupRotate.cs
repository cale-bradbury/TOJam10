using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ccCreateGroup))]
public class ccGroupRotate: MonoBehaviour {
	public Vector3 axisMultiplier = Vector3.forward*45;
	public AnimationCurve rotation;
	public float phase;
	public float phasePerSecond = 1f;
	public float frequency = 1;

	ccCreateGroup group;

	// Use this for initialization
	void Start () {
		group = GetComponent<ccCreateGroup>();
	}
	
	// Update is called once per frame
	void Update () {
		phase+=phasePerSecond*Time.deltaTime;
		for(int i = 0; i<group.all.Count;i++){
			group.all[i].transform.localEulerAngles = axisMultiplier*rotation.Evaluate((frequency*i/group.all.Count+phase)%1.0f);
		}
	}
}
