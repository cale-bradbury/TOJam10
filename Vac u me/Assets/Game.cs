using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	
	public static List<ObjectScript> all = new List<ObjectScript>();

	public string onAllCollectedEvent;
	bool allCollected;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (all.Count == 0 && !allCollected) {
			allCollected = true;
			Messenger.Broadcast (onAllCollectedEvent);
		} else {
			allCollected = false;
		}
	}
}
