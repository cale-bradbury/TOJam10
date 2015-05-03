using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class StickyObject : ObjectScript {

	public float stickiness = 100f;
	public GameObject childObject;

	private ccRandomPosition animRandom;
	private float lastTimeSucked;

	public override void Start(){
		base.Start ();
		body.constraints = RigidbodyConstraints.FreezeAll;
		if (childObject == null)
			childObject = transform.GetChild (0).gameObject;
		//childObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;

		addRandomPositionAnimation ();
	}

	void Update(){
		if (stickiness < 0)
			body.constraints = RigidbodyConstraints.None;
		// Cancels animation shortly after this is no longer being sucked.
		if (animRandom.enabled) {
			if (Time.time - 0.05f > lastTimeSucked) {
				animRandom.enabled = false;
			}
		}
	}
	
	public override void Collect(){

		if (stickiness <= 0) {
			animRandom.enabled = false;
			base.Collect ();
		} else {
			lastTimeSucked = Time.time;
			animRandom.enabled = true;
			stickiness -= 0.5f;
		}
	}

	//TODO: on collision with the ground freeze RigidbodyConstraints
	
	void addRandomPositionAnimation(){
		animRandom = GetComponent<ccRandomPosition> ();
		if (animRandom == null) {
			animRandom = childObject.AddComponent<ccRandomPosition>();
		}
		animRandom.minimumPosition = new Vector3 (-0.05f, -0.05f, -0.05f);
		animRandom.maximumPosition = new Vector3 (0.05f, 0.05f, 0.05f);
		animRandom.enabled = false;
	}
}
