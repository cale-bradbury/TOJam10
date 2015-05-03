using UnityEngine;
using System.Collections;

public class CouchScript : MonoBehaviour {
	public GameObject surface;
	public Color[] colors;

	Material mat;
	Material childMat;

	void Start(){
		mat = GetComponent<Renderer> ().material;
		childMat = surface.GetComponent<Renderer> ().material;
		Randomize ();
	}

	// Use this for initialization
	void Randomize () {
		mat.color = childMat.color = ArrayUtils.getRandom(colors);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
