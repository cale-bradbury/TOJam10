using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class CollectedItemManager : MonoBehaviour {

	public Vector3 itemScale = new Vector3 (.2f, .2f, .2f);
	public float itemRotateSpeed = 45f;
	public string endgameEvent;

	public GameObject testObj;

	private ccCreateRing orbitRing;
	private List<GameObject> items = new List<GameObject>();

	void Awake(){
		orbitRing = GetComponent<ccCreateRing> ();
	}

	// Use this for initialization
	void Start () {
		Messenger.AddListener (endgameEvent, OnEnd);
	}

	void OnEnd(){
		foreach (GameObject g in items) {
			Destroy(g);
		}
		items.Clear ();
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

		// Set new first item
		items.Insert (0, newItem);

		if (items.Count > 1) {
			HOTween.To (items [1].transform, .2f, new TweenParms ().Prop ("localScale", itemScale));
		}


		// Do this to the new item
		newItem.transform.parent = transform;

		// Set position
		newItem.transform.localPosition = Vector3.zero;
		Utils.ZeroChildPosition (newItem.transform);

		HOTween.To(newItem.transform, .2f, new TweenParms ().Prop("localScale", itemScale*2));
		newItem.AddComponent<ccRotate> ().degreesPerSecond = Vector3.up * itemRotateSpeed;


	}

	void updateItemsPositions(){
		int loopAmount;

		if (items.Count > orbitRing.all.Count) {
			loopAmount = orbitRing.all.Count;
		} else {
			loopAmount = items.Count;	
		}

		for (int i = 1; i < loopAmount; i++) {
			int orbitIndex = orbitRing.all.Count - (i+1);
			items[i].transform.localPosition = Vector3.Lerp(items[i].transform.localPosition,orbitRing.all[orbitIndex].transform.localPosition,.05f);
		}
	}

	void removeItem(TweenEvent data){
		GameObject item = (GameObject) data.parms[0];
		items.Remove (item);
		Destroy (item);
	}
}