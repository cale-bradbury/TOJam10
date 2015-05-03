using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {


	public Texture[] faces;
	Material mat;

	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void NewFace(){
		mat.SetTexture("_MainTex",faces[Mathf.FloorToInt(Random.value*faces.Length)]);
	}
}
