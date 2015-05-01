using UnityEngine;
using System.Collections;
using Holoville.HOTween;
[RequireComponent(typeof(Kalidescope))]
public class SpinKaleideoscope : MonoBehaviour {

	public float baseSpeed;
	public float spinSpeed;
	Kalidescope k;

	// Use this for initialization
	void Start () {
		k = GetComponent<Kalidescope>();
		HOTween.To(k,3,"angle",12,false,EaseType.EaseInOutSine,0);
	}
	
	// Update is called once per frame
	void Update () {
		k.baseAngle+=baseSpeed*Time.deltaTime;
		k.spinAngle+=spinSpeed*Time.deltaTime;
	}
}
