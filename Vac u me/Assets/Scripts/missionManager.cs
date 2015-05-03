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
		"a discreet",
		"a cynical"
	};

	private string[] adjectiveOnly;

	private Game.Type[,] adjectiveTypes = new Game.Type[,]{
		{Game.Type.General, Game.Type.Sex, Game.Type.Food},
		{Game.Type.General, Game.Type.Tech},
		{Game.Type.General, Game.Type.Sex},
		{Game.Type.General, Game.Type.Nerdy},
		{Game.Type.Drug, Game.Type.Sex, Game.Type.Games},
		{Game.Type.General, Game.Type.Dirty},
		{Game.Type.General, Game.Type.Drug, Game.Type.VideoGames},
		{Game.Type.General, Game.Type.VideoGames, Game.Type.Nerdy, Game.Type.Tech},
		{Game.Type.General, Game.Type.Games, Game.Type.VideoGames, Game.Type.Dnd, Game.Type.LARPing, Game.Type.Nerdy},
		{Game.Type.General},
		{Game.Type.General, Game.Type.Dirty},
		{Game.Type.General, Game.Type.Drug, Game.Type.Sex},
		{Game.Type.General, Game.Type.Food, Game.Type.Drug, Game.Type.VideoGames},
		{Game.Type.General, Game.Type.Nerdy},
		{Game.Type.General, Game.Type.Drug, Game.Type.Sex, Game.Type.LARPing},
		{Game.Type.General, Game.Type.Food},
		{Game.Type.General, Game.Type.Drug}
	};

	private string[] subject = new string[]
	{
		"GameBoy",
		"chips 'n dip",
		"arts and crafts",
		"Lego",
		"sex",
		"heroin",
		"swingers",
		"D&D",
		"LARPing",
		"candy",
		"Netflix",
		"video games",
		"fecal",
		"anime",
		"coding"
	};

	private string[] activity = new string[]
	{
		"an orgy",
		"a party",
		"a business meeting",
		"a performance",
		"a binge",
		"an incident",
		"a calamity",
		"a crisis",
		"an accident",
		"an event",
		"a marathon",
		"a discussion",
		"a jam",
		"a disaster",
		"a rap battle",
		"a dance-off",
		"a chill sesh",
		"a ball",
		"a crusade"
	};

	private string[] activityOnly;

	private string[] questTemplate = new string[]
	{
		"Last night's {{adjectiveOnly}} {{subject}} {{activityOnly}} has left the couch is a mess. Soon my mother will be here to visit, can you help me clean it? She will be here in 27 seconds.",
		"I am going to be hosting {{adjective}} {{activityOnly}} tonight, and I need this couch to be spotless.",
		"We had a bit of {{adjective}} {{subject}} {{activityOnly}}. Now the couch reeks and I don't know who else to turn to. Can you help me?",
		"Now that the monthly {{adjectiveOnly}} {{subject}} {{activityOnly}} has come to a close, I am in need of expertise.",
		"I am a bachelor. A bachelor is {{adjective}} man who comes to work each morning from a different {{activityOnly}}.  I do not have time to clean couches, so you have to do it.",
		"You can take the {{subject}} out of the couch, but you can't take the couch out of the {{subject}}.",
		"There was {{activity}}... {{subject}} everywhere.... The couch.... Please help.",
		"For the past 33 years, I have looked in the mirror every morning and asked myself: 'If today were the last day of my life, would I want to do what I am about to do today?' And whenever the answer has been 'No' for too many days in a row, I know I need to hire someone to clean my couch."
	};

	// Use this for initialization
	void Start () {

		adjectiveOnly = removeFirstWords (adjective);
		activityOnly = removeFirstWords (activity);

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

	string[] removeFirstWords(string[] phrases){
		// this will currently only remove the first two or three char from a string
		string[] newPhrases = (string[])phrases.Clone ();
		string space = " ";
		for (int i = 0; i < phrases.Length; i++) {
			if(newPhrases[i][1].ToString() == space){
				newPhrases[i] = newPhrases[i].Remove(0,2);
			} else {
				newPhrases[i] = newPhrases[i].Remove(0,3);
			}
		}

		return newPhrases;
	}

	string generateMissionText(){
		string template = questTemplate [Random.Range (0, questTemplate.Length)];
		int adjIndex = Random.Range (0, adjective.Length);
		int subIndex = Random.Range (0, subject.Length);
		int actIndex = Random.Range (0, activity.Length);

		template = template.Replace ("{{adjective}}", adjective[adjIndex]);
		template = template.Replace ("{{adjectiveOnly}}", adjectiveOnly[adjIndex]);
		template = template.Replace ("{{subject}}", subject [subIndex]);
		template = template.Replace ("{{activity}}", activity [actIndex]);
		template = template.Replace ("{{activityOnly}}", activityOnly [actIndex]);

		return template;
	}


	void getItemType(){
		// Create a list of gameObjects to send to spawners
		// the list is determined by the level text selected
		// Game.getObjectOfType ("type").gameObject;
	}




	// this class will spawn and control the character
}















