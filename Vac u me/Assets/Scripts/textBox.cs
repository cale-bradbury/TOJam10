using UnityEngine;
using System.Collections;

public class textBox : ccEventBase {

	public string completeEvent;
	public string[] text;
	public string[] textEvents;

	private TextMesh textMesh;
	private int currentTextIndex = 0;
	private bool isTextShown = false;

	void Awake(){
		textMesh = GetComponent<TextMesh>();
	}

	protected override void OnEvent (){
		base.OnEvent ();
		displayText ();
	}

	void displayText(){

		if (isTextShown) {
			currentTextIndex++;
		} else {
			isTextShown = true;
		}

		if (currentTextIndex < text.Length) {
			textMesh.text = text [currentTextIndex];
			broadcastTextEvents();
		} else {
			Messenger.Broadcast(completeEvent);
		}
	}

	void broadcastTextEvents(){
		if (textEvents.Length > 0) {
			if(textEvents[currentTextIndex].Length > 0){
				Messenger.Broadcast(textEvents[currentTextIndex]);
			}
		}
	}

}
