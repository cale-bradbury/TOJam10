using UnityEngine;
using System.Collections.Generic;

public class missionManager : MonoBehaviour {

	private string[] adjective = new string[]
	{
		"a wild",
		"a professional",	
	    "a steamy",
	    "an intellectual",
	    "an avant garde",
	    "a filthy",
	    "a trippy",
	    "a technical",
	    "a phat",
	    "a social",
	    "an unsanitary",
	    "an unethical",
	    "a relaxing",
		"a pretentious",
	 	"a chilling",
		"a discreet"
	};

	private object[,] subject = new object[,]
	{
		{"GameBoy"},
		{"chips 'n dip"},
		{"arts and crafts"},
		{"Lego"},
		{"sex"},
		{"heroin"},
		{"swinger"},
		{"D&D"},
		{"LARPing"},
		{"candy"},
		{"Netflix"},
		{"video game"},
		{"battery"},
		{"anime"},
		{"coding"}
	};

	private string[] activity = new string[]
	{
		"orgy",
		"party",
		"business meeting",
		"tournament",
		"performance",
		"binge",
		"incident",
		"calamity",
		"crisis",
		"accident",
		"event",
		"marathon",
		"discussion",
		"jam",
		"disaster",
		"rap battle",
		"dance-off",
		"chill sesh"
	};

	private string[] questTemplate = new string[]
	{
		"I had {{adjective}} {{subject}} {{activity}} last night and the couch is a mess. My mother is coming to visit, can you help me clean it? She will be here in 27 seconds.",
		"I am going to be hosting {{adjective}} {{activity}} tonight, and I need this couch to be spotless.",
		"We had a bit of {{adjective}} {{subject}} {{activity}}. Now the couch reeks and I don't know who else to turn to. Can you help me?",
		"Der was a {{activity}}"
	};

	// Use this for initialization
	void Start () {
		Debug.Log (generateMissionText ());
		Debug.Log (generateMissionText ());
		Debug.Log (generateMissionText ());
		Debug.Log (generateMissionText ());
		Debug.Log (generateMissionText ());
		Debug.Log (generateMissionText ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	string generateMissionText(){
		string template = questTemplate [Random.Range (0, questTemplate.Length)];

		template = template.Replace ("{{adjective}}", adjective [Random.Range (0, adjective.Length)]);
		template = template.Replace ("{{subject}}", (string)subject [Random.Range (0, subject.Length),0]);
		template = template.Replace ("{{activity}}", activity [Random.Range (0, activity.Length)]);

		return template;
	}


	void getItemType(){
		// Create a list of gameObjects to send to spawners
		// the list is determined by the level text selected
		// Game.getObjectOfType ("type").gameObject;
	}
}















