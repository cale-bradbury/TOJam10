using UnityEngine;
using System.Collections;

public class ccFloatEventFOV : ccFloatEventBase {

	public Camera cam;

	protected override void OnEvent (float f){
		cam.fieldOfView = f;
	}
}
