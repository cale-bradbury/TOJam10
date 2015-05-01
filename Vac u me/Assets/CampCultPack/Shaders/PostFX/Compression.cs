using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Cale/Compression")]
public class Compression : ImageEffectBase {

	RenderTexture  accumTexture;
	public CCTexture flow;
	public CCTexture stop;
	public Vector2 offset;
	public float fade = .9f;
	public bool radial = true;
	public float angle = 0;
	public float anglePerSecond = 0;
	public Transform center;

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		if (accumTexture == null || accumTexture.width != source.width || accumTexture.height != source.height){
			DestroyImmediate(accumTexture);
			accumTexture = new RenderTexture(source.width, source.height, 0);
			accumTexture.hideFlags = HideFlags.HideAndDontSave;
			Graphics.Blit( source, accumTexture );
		}
		accumTexture.MarkRestoreExpected();
		angle+=anglePerSecond*Time.deltaTime;

		flow.Update();
		stop.Update();

		Vector3 p = new Vector3(center.position.x,center.position.y,center.position.z);
		p = GetComponent<Camera>().WorldToViewportPoint(p);
		material.SetVector("_center",new Vector4(p.x,p.y,p.z,0.0f));

		material.SetVector("_x", new Vector4(offset.x,offset.y,angle,fade));
		material.SetTexture("_Last", accumTexture);
		material.SetTexture("_Flow",flow.texture);
		material.SetVector("_Flow_ST",flow.scaleTranslate);
		material.SetTexture("_Stop",stop.texture);
		material.SetVector("_Stop_ST",stop.scaleTranslate);
		
		if(radial){
			Shader.EnableKeyword("radial");
			Shader.DisableKeyword("nradial");
		}else{
			Shader.EnableKeyword("nradial");
			Shader.DisableKeyword("radial");
		}

		Graphics.Blit (source, destination, material);
		Graphics.Blit(destination,accumTexture);
	}
}
