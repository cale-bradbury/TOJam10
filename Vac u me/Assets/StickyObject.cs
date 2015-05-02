using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class StickyObject : ObjectScript {

	public float stickiness = 100f;
	public GameObject childObject;

	private ccRandomPosition animRandom;

	public override void Start(){
		base.Start ();
		body.constraints = RigidbodyConstraints.FreezeAll;
		childObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;

		addRandomPositionAnimation ();
	}

	// TODO: we need to be able to disable the shaking if 
	// the GameObject is not being sucked anymore.
	public override void Collect(Vector3 target){

		if (stickiness <= 0) {
			animRandom.enabled = false;
			base.Collect (target);
		} else {
			animRandom.enabled = true;
			stickiness -= 0.5f;
		}
	}
	
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
