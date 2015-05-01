using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Two Tone")]
public class TwoTone : ImageEffectBase {
	public Color light;
	public Color dark;
	public float low = 0.2f;
	public float high = 0.8f;
	public Texture2D pattern;
	public float size = 100;
	
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		material.SetColor("_Light",light);
		material.SetColor("_Dark",dark);
		material.SetFloat("_Low",low);
		material.SetFloat("_High",high);
		material.SetTexture("_PatTex",pattern);
		material.SetVector("_Overlay",new Vector4(GetComponent<Camera>().pixelWidth,GetComponent<Camera>().pixelHeight,size,size));
		Graphics.Blit (source, destination, material);
	}
}
