using UnityEngine;
using System.Collections;

public class ccFloatEventRotation : ccFloatEventBase {

	public Vector3 minRot;
	public Vector3 maxRot;

	protected override void OnEvent (float f)
	{
		transform.localEulerAngles = Vector3.Lerp (minRot, maxRot, f);
	}
}
