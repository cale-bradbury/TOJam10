using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectedItemManager : MonoBehaviour {

	public GameObject testObj;

	private ccCreateRing orbitRing;
	private List<GameObject> items = new List<GameObject>();

	void Awake(){
		orbitRing = GetComponent<ccCreateRing> ();
	}

	// Use this for initialization
	void Start () {
		Invoke ("test", 1f);
	}

	void test(){
		// this code is for testing and will be removed.
		testObj.GetComponent<trollObject> ().enabled = false;
		Destroy (testObj.GetComponent<Rigidbody> ());
		Debug.Log (testObj.transform.localScale);
		testObj.transform.localScale = Vector3.zero;
		Debug.Log (testObj.transform.localScale);
		addItem (testObj);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void addItem(GameObject newItem){
		items.Insert (0, newItem);

		revealItem (newItem);

		if (items.Count > orbitRing.count) {
			// Remove the last item?
		}
	}

	void revealItem(GameObject newItem){

		newItem.transform.parent = transform;

		// TODO: animate the scale up
		//newItem.transform.localScale = Vector3.one;
		Debug.Log (newItem.transform.localScale);

		newItem.transform.localPosition = Vector3.zero;
		Utils.ZeroChildPosition (newItem.transform);
	}
}