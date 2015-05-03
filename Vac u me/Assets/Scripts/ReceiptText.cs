using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class ReceiptText : MonoBehaviour {

	public GameObject ReceiptTextMesh;
	public float LineHeight = 1f;

	private List<string> valueText = new List<string> ();
	private List<GameObject> allText = new List<GameObject> ();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		updateAllTextPosition ();
	}

	public void addItemToText(ObjectScript o){
		string itemText = o.gameObject.name.ToString() + " - " + o.value.ToString();
		itemText =  itemText.Replace ("(Clone)", "");
		valueText.Insert (0,itemText);
		Debug.Log (itemText);
		createNew3dText (itemText);
	}

	void createNew3dText(string textValue){
		GameObject t = (GameObject)Instantiate (ReceiptTextMesh, transform.position, transform.rotation);
		allText.Insert (0,t);
		if (allText.Count > 10) {
			allText.RemoveAt(10);
		}

		TextMesh tm = t.GetComponent<TextMesh> ();
		t.transform.parent = transform;
		tm.text = textValue;
	}

	void updateAllTextPosition(){

		for (int i = 0; i < allText.Count; i++) {
			Vector3 targetPosition = allText[i].transform.localPosition;
			targetPosition = new Vector3(targetPosition.x, i * LineHeight, targetPosition.z);

			HOTween.To(allText[i].transform, .2f, new TweenParms ().Prop("localPosition",targetPosition));
		}

	}
}
