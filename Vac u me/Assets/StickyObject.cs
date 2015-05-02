using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class StickyObject : ObjectScript {

	public float stickiness = 100f;

	private ccRandomPosition animRandom;

	public override void Start(){
		base.Start ();
		body.constraints = RigidbodyConstraints.FreezePosition;

		addRandomPositionAnimation ();
	}

	public override void Collect(Vector3 target){

		if (stickiness <= 0) {
			animRandom.enabled = false;
			base.Collect (target);
		} else {
			animRandom.enabled = true;
			stickiness -= 0.5f;
			// shaking animation would be cool
		}
	}

	// TODO: this animation repositions the object, which we do not want
	// Also I am unsure of how to know if the item is not being sucked anymore so 
	// I can disable the shaking animation again.
	void addRandomPositionAnimation(){
		animRandom = GetComponent<ccRandomPosition> ();
		if (animRandom == null) {
			animRandom = gameObject.AddComponent<ccRandomPosition>();
		}
		animRandom.minimumPosition = new Vector3 (-0.05f, -0.05f, -0.05f);
		animRandom.maximumPosition = new Vector3 (0.05f, 0.05f, 0.05f);
		animRandom.enabled = false;
	}
}
