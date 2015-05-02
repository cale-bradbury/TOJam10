using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class textBox : ccEventBase {

	public string 			completeEvent; 			// event broadcasted on completion
	public string[] 		text;					// text that will be iterated through
	public string[] 		textEvents;
	public GameObject		letterMesh; 			// Prefab
	public float			letterWidth = 1f;
	public float			lineHeight = 1f;
	public float 			maxLineWidth = 20f;	
	public float 			charDelay = .05f;
	
	private List<GameObject> letterMeshes = new List<GameObject>();			// All instances of letterMesh
	private int 			currentTextIndex = 0;
	private int 			currentLineIndex = 0;	// 0 is the first line
	private bool 			isTextShown = false;
	private int 			currentLetterIndex = 0;
	private float 			currLineWidth = 0f;


	protected override void OnEvent (){
		base.OnEvent ();
		displayText ();
	}

	void displayText(){

		incrementTextIndex ();

		if (currentTextIndex < text.Length) {
			destroyAllLetterMeshes();
			instantiateLetterMeshes();
			broadcastTextEvents();
		} else {
			Messenger.Broadcast(completeEvent);
		}
	}

	void incrementTextIndex(){
		if (isTextShown) {
			currentTextIndex++;
		} else {
			isTextShown = true;
		}
	}

	void broadcastTextEvents(){
		if (textEvents.Length > 0) {
			if(textEvents[currentTextIndex].Length > 0){
				Messenger.Broadcast(textEvents[currentTextIndex]);
			}
		}
	}

	void instantiateLetterMeshes(){
		currLineWidth = 0f;
		currentLetterIndex = -1;
		for (int i = 0; i < text[currentTextIndex].Length; i++) {
			Invoke("addCharacter",charDelay*i);
		}
	}

	void addCharacter(){
		currentLetterIndex++;
		char letter = text[currentTextIndex][currentLetterIndex];
		if(char.IsWhiteSpace(letter)){
			
			if(currLineWidth >= maxLineWidth){
				// start a new line
				Debug.Log ("Line width has been exceeded");
				currentLineIndex++;
				currLineWidth = 0;
			} else {
				currLineWidth += letterWidth;
			}
			
		} else {
			// TODO: scale up animation
			Vector3 letterPos = transform.position;
			letterPos.x = letterPos.x + (currLineWidth);
			letterPos.y = letterPos.y - (lineHeight * (float)currentLineIndex);
			GameObject l = (GameObject) Instantiate(letterMesh, letterPos, transform.rotation);
			l.GetComponent<TextMesh>().text = letter.ToString();
			l.transform.parent = transform;
			letterMeshes.Add(l);
			
			currLineWidth += letterWidth;
		}
	}
	
	void destroyAllLetterMeshes(){
		if (letterMeshes.Count > 0) {
			// TODO: scale them back down
			
			for (int i = 0; i < letterMeshes.Count; i++) {
				Destroy(letterMeshes[i]);
			}
			
			letterMeshes.Clear();
		}
	}
}




























