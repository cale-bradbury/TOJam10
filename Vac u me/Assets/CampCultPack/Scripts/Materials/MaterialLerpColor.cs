using UnityEngine;
using System.Collections;

public class MaterialLerpColor : MonoBehaviour {

	public Material mat;
	public string colorName;
	public Color c1;
	public Color c2;
	public float speed = 1;
	float i = 0;

	// Update is called once per frame
	void Update () {
		i+=Time.deltaTime*speed;
		mat.SetColor(colorName,Color.Lerp(c1,c2,Mathf.Sin(i)*.5f+.5f));
	}
}
