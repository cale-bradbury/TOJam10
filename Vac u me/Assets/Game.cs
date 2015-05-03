using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	public enum GameType{
		Timed,
		CollectAll
	}
	public GameType gameType = GameType.Timed;
	public float completeTime;
	float startTime;

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

	public string onEndGameEvent;
	bool allCollected;
	bool allSpawned = false;
	bool gameEnded = false;
	public GameObject spawnHolder;
	List<SpawnManager> spawns;
	public List<Type> spawnTypes;
	public int differentObjects  = 4;

	// Use this for initialization
	void Start () {

	}

	void OnEnable(){
		i = this;
		spawnTypes = missionManager.missionTypes;
		if (spawnTypes.Count == 0) {
			spawnTypes.Add(Type.General);
		}
		typeNames = System.Enum.GetNames (typeof(Type));
		allSpawned = false;
		allCollected = false;
		startTime = Time.time;
		spawnHolder = Instantiate (spawnHolder);
		spawnHolder.transform.parent = transform;
		spawnHolder.transform.localPosition = Vector3.zero;
		spawns = new List<SpawnManager> ();

		List<ObjectScript> g = new List<ObjectScript> ();
		for (int j = 0; j<differentObjects; j++) {
			spawnTypes = Utils.RandomizeList<Type>(spawnTypes);
			g.Add(GetObjectOfType(spawnTypes[0]));
			Debug.Log (spawnTypes[0]+"  "+g[g.Count-1]);
		}

		foreach (SpawnManager s in spawnHolder.GetComponentsInChildren<SpawnManager>()) {
			spawns.Add(s);
			for (int j = 0; j<s.objects.Count; j++) {
				s.objects[j] = g[0];
				g.RemoveAt(0);
				g.Add(s.objects[j]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (startTime + completeTime<Time.time) {
			if(gameType==GameType.Timed)EndGame();
		}
		if (!allSpawned) {
			bool safe = true;
			foreach(SpawnManager s in spawns){
				if(!s.allSpawned){
					safe = false;
					break;
				}
			}
			allSpawned = safe;
		}

		if (all.Count == 0 && !allCollected && allSpawned) {
			allCollected = true;
			if(gameType == GameType.CollectAll)EndGame();
		} else {
			allCollected = false;
		}
	}

	void EndGame(){
		if (gameEnded)
			return;
		gameEnded = true;
		Messenger.Broadcast (onEndGameEvent);
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
