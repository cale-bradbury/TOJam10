using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class CollectedItemManager : MonoBehaviour {

	public Vector3 itemScale = new Vector3 (.2f, .2f, .2f);

	public GameObject testObj;

	private ccCreateRing orbitRing;
	private List<GameObject> items = new List<GameObject>();

	void Awake(){
		orbitRing = GetComponent<ccCreateRing> ();
	}

	// Use this for initialization
	void Start () {


		/*for (int i = 1; i <= 15; i++) {
			Invoke ("test", (float)i);	// this code is for testing and will be removed.
		}*/
	}

	void test(){
		GameObject t = (GameObject) Instantiate(testObj, transform.position, transform.rotation);
		t.GetComponent<trollObject> ().enabled = false;
		Destroy (t.GetComponent<Rigidbody> ());
		t.transform.localScale = Vector3.zero;
		addItem (t);
	}
	
	// Update is called once per frame
	void Update () {
		updateItemsPositions ();
	}

	public void addItem(GameObject newItem){
		revealItem (newItem);

		if (items.Count > orbitRing.count) {
			int removeIndex = orbitRing.count;
			HOTween.To(items[removeIndex].transform, .2f, new TweenParms ().Prop("localScale", Vector3.zero).OnComplete(removeItem, items[removeIndex]));
		}
	}

	void revealItem(GameObject newItem){
		newItem.transform.parent = transform;

		// Set position
		newItem.transform.localPosition = Vector3.zero;
		Utils.ZeroChildPosition (newItem.transform);

		HOTween.To(newItem.transform, .2f, new TweenParms ().Prop("localScale", itemScale));
		newItem.AddComponent<ccRotate> ().degreesPerSecond = Vector3.up * 15;

		items.Insert (0, newItem);
	}

	void updateItemsPositions(){
		int loopAmount;

		if (items.Count > orbitRing.all.Count) {
			loopAmount = orbitRing.all.Count;
		} else {
			loopAmount = items.Count;	
		}

		for (int i = 0; i < loopAmount; i++) {
			int orbitIndex = orbitRing.all.Count - (i+1);
			Vector3 target = orbitRing.all[orbitIndex].transform.localPosition;
			HOTween.To(items[i].transform, .5f, new TweenParms ().Prop("localPosition",target));
		}
	}

	void removeItem(TweenEvent data){
		GameObject item = (GameObject) data.parms[0];
		items.Remove (item);
		Destroy (item);
	}
}