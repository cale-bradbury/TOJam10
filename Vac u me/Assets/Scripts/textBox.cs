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
	
	private List<GameObject> letterMeshes = new List<GameObject>();			// All instances of letterMesh
	private int 			currentTextIndex = 0;
	private bool 			isTextShown = false;


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
		int numberOfChar = text[currentTextIndex].Length;
		float currLineWidth;

		for (int i = 0; i < text[currentTextIndex].Length; i++) {
			char letter = text[currentTextIndex][i];

			if(char.IsWhiteSpace(letter)){

			} else {
				// TODO: scale up animation

				//if(currLineWidth > maxLineWidth){
					// start a new line
				//}

				Vector3 letterPos = transform.position;
				letterPos.x = letterPos.x + (letterWidth * (float)i);
				GameObject l = (GameObject) Instantiate(letterMesh, letterPos, transform.rotation);
				l.GetComponent<TextMesh>().text = letter.ToString();
				l.transform.parent = transform;
				letterMeshes.Add(l);
			}
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




























