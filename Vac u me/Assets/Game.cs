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
	public static Game i;
	public List<GameObject>allPrefabs;

	public string onAllCollectedEvent;
	bool allCollected;


	// Use this for initialization
	void Start () {
		if (i != null)
			Debug.LogError ("ONLY ONE GAME SCRIPT");
		i = this;
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
	public static GameObject GetObjectOfType(Game.Type t){
		if (i == null)
			return null;
		//i.allPrefabs.
	}
}
