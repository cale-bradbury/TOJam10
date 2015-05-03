using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public enum Type{
		Food,
		Drug,
		Lego
	}
	public static string[] typeNames;

	public static List<ObjectScript> all = new List<ObjectScript>();

	public string onAllCollectedEvent;
	bool allCollected;


	// Use this for initialization
	void Start () {
		typeNames = System.Enum.GetNames (typeof(Type));
		Debug.Log (typeNames [0]);
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
