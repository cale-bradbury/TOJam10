using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {


	public Texture[] faces;
	Material mat;

	// Use this for initialization
	void Awake () {
		mat = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void NewFace(){
		mat.SetTexture("_MainTex",faces[Mathf.FloorToInt(Random.value*faces.Length)]);
	}
}
