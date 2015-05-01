using UnityEngine;
using System.Collections;

public class EventSetMaterial : MonoBehaviour {
	public string eventName;
	public Material mat;
	// Use this for initialization
	void Start () {
		Messenger.AddListener(eventName,ChangeMat);
	}
	
	// Update is called once per frame
	void ChangeMat () {
		GetComponent<Renderer>().material = mat;
	}
}
