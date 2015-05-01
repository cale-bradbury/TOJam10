using UnityEngine;
using System.Collections;
using System.Reflection;

public class WebcamTexture : MonoBehaviour {
	WebCamTexture tex;
	public KeyCode nextCam;
	public KeyCode prevCam;
	int i = 0;
	public MonoBehaviour obj;
	public string varName;
	public FieldInfo field;

	// Use this for initialization
	void Start () {
		tex = new WebCamTexture();
		tex.Play();
		OnEnable();
	}
	void OnEnable () {
		field = obj.GetType().GetField(varName);
		if(tex!=null)field.SetValue(obj,tex);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(nextCam)){
			i++;
			i%=WebCamTexture.devices.Length;
			tex.deviceName = WebCamTexture.devices[i].name;
			tex.Play();
			field.SetValue(obj,tex);
			Debug.Log("next");
		}else if(Input.GetKeyDown(prevCam)){
			i--;
			if(i<0)i = WebCamTexture.devices.Length-1;
			tex.deviceName = WebCamTexture.devices[i].name;
			tex.Play();
			field.SetValue(obj,tex);
			Debug.Log("prev");
		}
	}
}
