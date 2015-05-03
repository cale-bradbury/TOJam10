using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/CampCult/Distort/Kalidescope")]
public class Kalidescope : ImageEffectBase {
	public float mirrors;
	public float baseAngle;
	public float basePerSecond;
	public float spinAngle;
	public float spinPerSecond;
	public float intensity;

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		spinAngle += spinPerSecond * Time.deltaTime;
		baseAngle += basePerSecond * Time.deltaTime;
		float a = 360 / Mathf.Max (mirrors, .5f) * .5f;
		material.SetFloat ("_Angle", Mathf.Deg2Rad*(a));
		material.SetFloat ("_BaseAngle", Mathf.PI*2*baseAngle);
		material.SetFloat("_SpinAngle",Mathf.PI*2/a*spinAngle);
		material.SetFloat ("_Intensity", intensity);
		Graphics.Blit (source, destination, material);
	}
}
