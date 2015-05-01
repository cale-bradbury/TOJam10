using UnityEngine;
using System.Collections;
using System.Reflection;

public class ccEventAnimatePosition : ccEventBase {
	public string endEvent;
	public AnimationCurve animation;
	public Vector3 multiplier;
	public float time = 1;
	float animTime = 1000;

	protected override void OnEvent (){
		animTime = 0;
		base.OnEvent ();
	}
	
	// Update is called once per frame
	void Update () {
		if (animTime < time) {
			animTime += Time.deltaTime;
			if(animTime>time){
				transform.position = animation.Evaluate(1)*multiplier;
				Messenger.Broadcast(endEvent);
			}else{
				transform.position = animation.Evaluate(animTime/time)*multiplier;
			}
		}
	}
}
