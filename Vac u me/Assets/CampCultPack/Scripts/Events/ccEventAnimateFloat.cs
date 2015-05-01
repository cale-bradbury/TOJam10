using UnityEngine;
using System.Collections;
using System.Reflection;

public class ccEventAnimateFloat : ccEventFieldBase {

	public AnimationCurve animation;
	public float multiplier = 1;
	public float time = 1;
	float animTime = 1000;

	protected override void OnEvent (){
		animTime = 0;
		base.OnEvent ();
	}
	
	// Update is called once per frame
	void Update () {
		if (animTime < time) {
			animTime+=Time.deltaTime;
			SetValue(GetValue ());
		}
	}

	protected override object GetValue (){
		return animation.Evaluate(animTime/time)*multiplier;
	}
}
