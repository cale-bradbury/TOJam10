using UnityEngine;
using System.Collections;

public class LightSineColor : MonoBehaviour {
	public Light[] lights;
	public Color c1;
	public Color c2;
	public float speed = 1;
	float i = 0;
	// Update is called once per frame
	void Update () {
		i+= (1/speed)*Time.deltaTime;
		Color c = Color.Lerp(c1,c2,Mathf.Sin(i)*0.5f+0.5f);
		foreach(Light l in lights){
			l.color = c;
		}
	}
}
