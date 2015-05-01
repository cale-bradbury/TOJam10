using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Color Adjustments/Color Correction LUT")]
public class ColorCorectionLut : ImageEffectBase {
	public Texture  textureRamp;
	public float red;
	public float green;
	public float blue;
	public float intensity;

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		material.SetTexture ("_RampTex", textureRamp);
		material.SetVector ("_Off", new Vector4(red,green,blue,1));
		material.SetFloat ("_Intensity", intensity);
		Graphics.Blit (source, destination, material);
	}
}
