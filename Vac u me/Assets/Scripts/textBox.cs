using UnityEngine;
using System.Collections;

public class textBox : ccEventBase {

	public string completeEvent;
	public string[] text;

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
		} else {
			Messenger.Broadcast(completeEvent);
		}
	}

}
