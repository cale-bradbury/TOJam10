using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class BeatMatVector : MonoBehaviour
{
	public string eventName;
	public string vectorName;
	public Material mat;
	public bool xOn;
	public bool yOn;
	public bool zOn;
	public bool wOn;
	public Vector4 minValue;
	public Vector4 maxValue;
	public bool additive;
	public bool useValue = false;
	public float fadeSpeed = .5f;
	[HideInInspector]
	public Vector4 vector;
	
	// Use this for initialization
	void Start ()
	{
		vector = Vector4.zero;//mat.GetVector(vectorName);
		mat = GetComponent<Renderer>().material;
	}
	
	void OnEnable(){
		vector = mat.GetVector(vectorName);
		Messenger.AddListener<float>(eventName,Beat);
	}
	void OnDisable(){
		Messenger.RemoveListener<float>(eventName,Beat);
	}

	void Beat(float v){
		vector = mat.GetVector(vectorName);
		Vector4 target = vector;
		if(xOn){
			vector.x = useValue?(maxValue.x - minValue.x)*v+minValue.x:maxValue.x;
			target.x = minValue.x;
		}
		if(yOn){
			vector.y = useValue?(maxValue.y - minValue.y)*v+minValue.y:maxValue.y;
			target.y = minValue.y;
		}
		if(zOn){
			vector.z = useValue?(maxValue.z - minValue.z)*v+minValue.z:maxValue.z;
			target.z = minValue.z;
		}
		if(wOn){
			vector.w = useValue?(maxValue.w - minValue.w)*v+minValue.w:maxValue.w;
			target.w = minValue.w;
		}
		HOTween.To(this,fadeSpeed,"vector",target);
	}
	
	// Update is called once per frame
	void Update (){
		mat.SetVector(vectorName, vector);
	}
}

