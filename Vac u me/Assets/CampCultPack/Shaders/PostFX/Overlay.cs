using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Cale/Overlay")]
public class Overlay: ImageEffectBase {

	public float alpha = 1.0f;
	public Texture texture;	
	
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		material.SetTexture ("_Overlay", texture);
		material.SetFloat ("_Alpha", alpha);
		Graphics.Blit (source, destination, material);
	}
}