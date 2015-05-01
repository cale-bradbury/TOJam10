using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Cale/Color Correction LUT")]
public class ColorCorrectionLUT : ImageEffectBase {
	public Texture  textureRamp;
	public Vector4 offset;

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		material.SetTexture ("_RampTex", textureRamp);
		material.SetVector ("_Off", offset);
		Graphics.Blit (source, destination, material);
	}
}
