using UnityEngine;
using System.Collections.Generic;

public class missionManager : MonoBehaviour {

	public GameObject characterGroupPrefab;
	public GameObject characterPrefab;
	public GameObject textBoxPrefab;

	[HideInInspector]public static List<Game.Type> missionTypes = new List<Game.Type> ();

	int adjIndex;
	int subIndex;
	int actIndex;

	private string[] adjective = new string[]
	{
		"a wild",				// 1
		"a professional",		// 2
	    "a steamy",				// 3
	    "an intellectual",		// 4
	    "an avant garde",		// 5
	    "a filthy",				// 6
	    "a trippy",				// 7
	    "a technical", 			// 8
	    "a phat",				// 9
	    "a social",				// 10
	    "an unsanitary",		// 11
	    "an unethical",			// 12
	    "a relaxing",			// 13
		"a pretentious",		// 14
	 	"a chilling", 			// 15
		"a discreet",			// 16
		"a cynical",			// 17
		"a dumpy",   			// 18
		"a rank",				// 19
		"a swell",				// 20
		"a cheesey",			// 21
		"a saucey",				// 22
		"a farty" 				// 23
	};

	private string[] adjectiveOnly;

	private Game.Type[][] adjectiveTypes = new Game.Type[][]{
		new Game.Type[] {Game.Type.General, Game.Type.Sex, Game.Type.Food},
		new Game.Type[] {Game.Type.General, Game.Type.Tech},
		new Game.Type[] {Game.Type.General, Game.Type.Sex},
		new Game.Type[] {Game.Type.General, Game.Type.Nerdy},
		new Game.Type[] {Game.Type.Drug, Game.Type.Sex, Game.Type.Games},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty},
		new Game.Type[] {Game.Type.General, Game.Type.Drug, Game.Type.VideoGames},
		new Game.Type[] {Game.Type.General, Game.Type.VideoGames, Game.Type.Nerdy, Game.Type.Tech},
		new Game.Type[] {Game.Type.General, Game.Type.Games, Game.Type.VideoGames, Game.Type.Dnd, Game.Type.LARPing, Game.Type.Nerdy},
		new Game.Type[] {Game.Type.General},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty},
		new Game.Type[] {Game.Type.General, Game.Type.Drug, Game.Type.Sex},
		new Game.Type[] {Game.Type.General, Game.Type.Food, Game.Type.Drug, Game.Type.VideoGames},
		new Game.Type[] {Game.Type.General, Game.Type.Nerdy},
		new Game.Type[] {Game.Type.General, Game.Type.Drug, Game.Type.Sex, Game.Type.LARPing},
		new Game.Type[] {Game.Type.General, Game.Type.Food},
		new Game.Type[] {Game.Type.General, Game.Type.Drug},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty, Game.Type.Food},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty, Game.Type.Food},
		new Game.Type[] {Game.Type.General, Game.Type.Lego, Game.Type.Games},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty, Game.Type.Food},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty, Game.Type.Sex},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty, Game.Type.Food},
	};

	private string[] subject = new string[]
	{
		"GameBoy",
		"chips 'n dip",
		"arts and crafts",
		"Lego",
		"sex",				// 5
		"heroin",
		"swingers",
		"D&D",
		"LARPing",
		"candy",			// 10
		"Netflix",
		"video games",
		"fecal",
		"anime",
		"coding",			// 15
		"BBQ",
		"scrap booking",
		"extreme sports"	// 18
	};

	private Game.Type[][] subjectTypes = new Game.Type[][]{
		new Game.Type[] {Game.Type.General, Game.Type.VideoGames, Game.Type.Tech},
		new Game.Type[] {Game.Type.General, Game.Type.Food, Game.Type.Dirty},
		new Game.Type[] {Game.Type.General, Game.Type.Nerdy, Game.Type.Drug},
		new Game.Type[] {Game.Type.General, Game.Type.Lego, Game.Type.Games},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty, Game.Type.Sex},
		new Game.Type[] {Game.Type.General, Game.Type.Drug},
		new Game.Type[] {Game.Type.General, Game.Type.Sex, Game.Type.Dirty},
		new Game.Type[] {Game.Type.General, Game.Type.Games, Game.Type.Dnd, Game.Type.LARPing, Game.Type.Nerdy},
		new Game.Type[] {Game.Type.General, Game.Type.Games, Game.Type.Dnd, Game.Type.LARPing, Game.Type.Nerdy},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty, Game.Type.Drug, Game.Type.Food},
		new Game.Type[] {Game.Type.General, Game.Type.Food, Game.Type.Tech},
		new Game.Type[] {Game.Type.General, Game.Type.Nerdy, Game.Type.Drug, Game.Type.VideoGames},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty, Game.Type.Sex},
		new Game.Type[] {Game.Type.General, Game.Type.Nerdy, Game.Type.Drug, Game.Type.VideoGames},
		new Game.Type[] {Game.Type.General, Game.Type.Nerdy, Game.Type.Tech},
		new Game.Type[] {Game.Type.General, Game.Type.Food, Game.Type.Tech},
		new Game.Type[] {Game.Type.General, Game.Type.Nerdy, Game.Type.Tech},
		new Game.Type[] {Game.Type.General, Game.Type.Games, Game.Type.Food, Game.Type.Dirty, Game.Type.Drug}
	};

	private string[] activity = new string[]
	{
		"an orgy",		
		"a party",
		"a business meeting",
		"a performance",
		"a binge",				// 5
		"an incident",
		"a calamity",
		"a crisis",
		"an accident",
		"an event",				// 10
		"a marathon",
		"a discussion",
		"a jam",
		"a disaster",
		"a rap battle",			// 15
		"a dance-off",
		"a chill sesh",
		"a ball",
		"a crusade",
		"a bender",				// 20
		"a detox"				// 21
	};

	private string[] activityOnly;

	private Game.Type[][] activityTypes = new Game.Type[][]{
		new Game.Type[] {Game.Type.General, Game.Type.Sex, Game.Type.Dirty},
		new Game.Type[] {Game.Type.General, Game.Type.Sex, Game.Type.Food, Game.Type.Games},
		new Game.Type[] {Game.Type.General, Game.Type.Nerdy, Game.Type.Tech},
		new Game.Type[] {Game.Type.General, Game.Type.Games},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty, Game.Type.Sex, Game.Type.Sex},
		new Game.Type[] {Game.Type.General, Game.Type.Drug, Game.Type.Dirty},
		new Game.Type[] {Game.Type.General, Game.Type.Drug, Game.Type.Dirty},
		new Game.Type[] {Game.Type.General, Game.Type.Drug, Game.Type.Dirty, Game.Type.Sex},
		new Game.Type[] {Game.Type.General, Game.Type.Drug, Game.Type.Dirty, Game.Type.Sex},
		new Game.Type[] {Game.Type.General},
		new Game.Type[] {Game.Type.General},
		new Game.Type[] {Game.Type.General, Game.Type.Nerdy},
		new Game.Type[] {Game.Type.General, Game.Type.Nerdy, Game.Type.Tech, Game.Type.VideoGames},
		new Game.Type[] {Game.Type.General, Game.Type.Drug, Game.Type.Dirty, Game.Type.Sex},
		new Game.Type[] {Game.Type.General, Game.Type.Drug, Game.Type.Dirty},
		new Game.Type[] {Game.Type.General, Game.Type.LARPing, Game.Type.Dirty},
		new Game.Type[] {Game.Type.General, Game.Type.Drug, Game.Type.VideoGames},
		new Game.Type[] {Game.Type.General, Game.Type.Food, Game.Type.Sex},
		new Game.Type[] {Game.Type.General, Game.Type.LARPing, Game.Type.Dirty},
		new Game.Type[] {Game.Type.General, Game.Type.Dirty, Game.Type.Drug},
		new Game.Type[] {Game.Type.General, Game.Type.Food, Game.Type.VideoGames}
	};

	private string[] questTemplate = new string[]
	{
		"Last night's {{adjectiveOnly}} {{subject}} {{activityOnly}} has left the couch a mess. Soon my mother will be here to visit, can you help me clean it? She will be here in 27 seconds.",
		"I am going to be hosting {{adjective}} {{activityOnly}} tonight, and I need this couch to be spotless.",
		"We had a bit of {{adjective}} {{subject}} {{activityOnly}}. Now the couch reeks and I don't know who else to turn to. Can you help me?",
		"Now that the monthly {{adjectiveOnly}} {{subject}} {{activityOnly}} has come to a close, I am in need of expertise.",
		"I am a bachelor. A bachelor is {{adjective}} man who comes to work each morning from a different {{activityOnly}}.  I do not have time to clean couches, so you have to do it.",
		"You can take the {{subject}} out of the couch, but you can't take the couch out of the {{subject}}.",
		"There was {{activity}}... {{subject}} everywhere.... The couch.... Please help.",
		"For the past 33 years, I have looked in the mirror every morning and asked myself: 'If today were the last day of my life, would I want to do what I am about to do today?' And whenever the answer has been 'No' for too many days in a row, I know I need to hire someone to clean my couch.",
		"You could not imagine the {{adjectiveOnly}} {{subject}} {{activityOnly}} that went down, but now where I sit is a mess, I need you to clean it alright? alright.",
		"I could sure go for {{activity}}, but my couch is {{adjective}} mess, you've got to clean it for me or it just won't happen.",
		"I was about to sit down to watch my favourite {{subject}} television program and noticed my couch is in {{adjectvie}} mess worthy of {{activity}}. Clean it so I can enjoy this program.",
		"My couch is my most prized possesion you'd think I'd take better care of it but my {{adjectiveOnly}} {{subject}} {{activityOnly}} last night really took it's toll, please help.",
		"I'm an individual who enjoys {{adjective}} {{subject}} {{activityOnly}} as much as the next person, but the state of my couch is un-acceptable, do something about it.",
		"I'm feelin pretty {{adjectiveOnly}} and my couch is a direct reflection of how I feel, please get to work so my {{subject}} {{activityOnly}} will go off with out a hitch."
	};

	// Use this for initialization
	void Start () {
		adjectiveOnly = removeFirstWords (adjective);
		activityOnly = removeFirstWords (activity);

		setUpNewMission ();
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

	void setUpNewMission(){

		// init characterGroupPrefab
		GameObject cg = (GameObject) Instantiate(characterGroupPrefab, new Vector3(-11.36f,-4.13f,-3.73f), transform.rotation);

		// Gen Mission Text
		string missionText = generateMissionText ();

		// Init dialog text box
		GameObject t = (GameObject) Instantiate(textBoxPrefab, cg.transform.position, transform.rotation);
		t.transform.parent = cg.transform;
		textBox tb = t.GetComponent<textBox> ();
		tb.lineHeight = 2f;
		tb.text.Add(missionText);
		tb.displayText ();

		// init characterPrefab 
		GameObject cm = (GameObject) Instantiate(characterPrefab, cg.transform.position, transform.rotation);
		cm.transform.parent = cg.transform;
		cm.GetComponent<CharacterManager> ().NewFace ();

		cg.transform.eulerAngles = new Vector3(42f,0f,0f);
	}

	string generateMissionText(){
		string template = questTemplate [Random.Range (0, questTemplate.Length)];

		generateTextIndice ();

		template = template.Replace ("{{adjective}}", adjective[adjIndex]);
		template = template.Replace ("{{adjectiveOnly}}", adjectiveOnly[adjIndex]);
		template = template.Replace ("{{subject}}", subject [subIndex]);
		template = template.Replace ("{{activity}}", activity [actIndex]);
		template = template.Replace ("{{activityOnly}}", activityOnly [actIndex]);

		return template;
	}

	void generateTextIndice(){

		missionTypes.Clear ();

		adjIndex = Random.Range (0, adjective.Length);
		subIndex = Random.Range (0, subject.Length);
		actIndex = Random.Range (0, activity.Length);

		addToGameTypeList ((Game.Type[])adjectiveTypes[adjIndex], missionTypes);
		addToGameTypeList ((Game.Type[])subjectTypes[subIndex], missionTypes);
		addToGameTypeList ((Game.Type[])activityTypes[actIndex], missionTypes);
	}

	List<Game.Type> addToGameTypeList(Game.Type[] types, List<Game.Type> typesList){
		for (int i = 0; i < types.Length; i++) {
			typesList.Add(types[i]);
		}

		return typesList;
	}

	void getItemType(){
		// Create a list of gameObjects to send to spawners
		// the list is determined by the level text selected
		// Game.getObjectOfType ("type").gameObject;
	}




	// this class will spawn and control the character
}















