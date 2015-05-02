using UnityEngine;
using System.Collections.Generic;
using Holoville.HOTween;

public class trollObject : ObjectScript {

	public float speed = 2;

	private GameObject target;

	public override void Start(){
		base.Start ();
	}

	void Update(){
		selectTarget ();
		moveToTarget ();
	}
	
	void selectTarget(){
		if (target == null) {
			target = targetFoodObject();
		}
	}
	
	void moveToTarget(){
		if (target != null) {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
		}
	}

	GameObject targetFoodObject(){
		GameObject[] gos;
		GameObject newTarget;
		gos = GameObject.FindGameObjectsWithTag ("Food");

		if (gos.Length > 0) {
			newTarget = gos [Random.Range (0, gos.Length - 1)];
		} else {
			newTarget = null;
		}

		return newTarget;
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Food")) {
			Destroy(col.gameObject);
			target = null;
		}
	}
}
