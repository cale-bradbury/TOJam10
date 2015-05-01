using UnityEngine;
using System.Collections;
using System.Reflection;
using Holoville.HOTween;

public class AudioController : MonoBehaviour {

	public static float value = 0;
	public bool processingVj;

	string oscHost = "127.0.0.1";
	int outPort = 3200;
	int inPort = 121;
	UDPPacketIO udp;
	Osc handler;

	public Compression com;

	void Start(){
		if(processingVj){
			udp = gameObject.AddComponent<UDPPacketIO>();
			handler = gameObject.AddComponent<Osc>();

			udp.init(oscHost,outPort,inPort);
			handler.init(udp);
			handler.SetAddressHandler("/vj",vjValue);
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			Screen.fullScreen = true;
		}
	}

	void vjValue(OscMessage msg){
		if((int)msg.Values[0]==1){
			com.fade = 1;
		}else{
			com.fade = 0.95f;
		}
	}


	
}