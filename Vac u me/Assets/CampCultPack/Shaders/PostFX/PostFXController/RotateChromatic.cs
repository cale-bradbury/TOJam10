using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ChromaticArb))]
public class RotateChromatic : MonoBehaviour {

	ChromaticArb arb;
	public float dist;
	public float speed;
	float phase;

	// Use this for initialization
	void Start () {
		arb = GetComponent<ChromaticArb>();
	}
	
	// Update is called once per frame
	void Update () {
		phase+=Time.deltaTime*speed;
		arb.center.Set(Mathf.Sin(phase)*dist,Mathf.Cos(phase)*dist);
	}
}
