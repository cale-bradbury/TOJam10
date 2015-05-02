using UnityEngine;
using System.Collections.Generic;
using Holoville.HOTween;

public class trollObject : ObjectScript {

	public float speed = 2;

	private GameObject target;

	public override void Start(){
		base.Start ();
		body.constraints = RigidbodyConstraints.FreezeRotationY;

		//target = Game.all [Random.Range(0, Game.all.Count - 1)];
	}

	// selects a target object

	// moves to object
		// destroys object
		// selects new object
}
