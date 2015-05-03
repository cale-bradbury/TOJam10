using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public enum Type{
		Food,
		Drug,
		Sex,
		Lego,			// related to games
		Games,
		VideoGames,		// related to games + Nerdy + tech
		Dnd,			// related to games + Nerdy
		LARPing, 		// related to games + Nerdy
		Nerdy,
		Tech, 
		General,
		Dirty
	}
	public static string[] typeNames;

	public static List<ObjectScript> all = new List<ObjectScript>();
	public static Game i;
	public List<ObjectScript>allPrefabs;

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
	public static ObjectScript GetObjectOfType(Game.Type t){
		if (i == null)
			return null;
		i.allPrefabs = Utils.RandomizeList (i.allPrefabs);
		for(int j = 0; j< i.allPrefabs.Count;j++){
			foreach(Game.Type type in i.allPrefabs[j].types){
				if(type==t)return i.allPrefabs[j];
			}
		}
		return null;
	}
}
