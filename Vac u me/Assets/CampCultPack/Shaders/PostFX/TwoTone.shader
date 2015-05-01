Shader "Cale/TwoTone" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_PatTex ("Pat (RGB)", 2D) = "white" {}
		_Light ("Light Color", Color) = (1,1,1,1)
		_Dark ("Dark Color", Color) = (0,0,0,1)
		_Low("Low", float)= 0.2
		_High("High", float)= 0.8
		_Overlay("Overlay", Vector) = (1,1,1,1)
	}
	SubShader {
		Pass {
			ZTest Always Cull Off ZWrite Off
			Fog { Mode off }
					
	CGPROGRAM
	#pragma vertex vert_img
	#pragma fragment frag
	#pragma fragmentoption ARB_precision_hint_fastest 
	#include "UnityCG.cginc"

	uniform sampler2D _MainTex;
	uniform sampler2D _PatTex;
	uniform float4 _Light;
	uniform float4 _Dark;
	uniform float _Low;
	uniform float _High;
	uniform float4 _Overlay;

	fixed4 frag (v2f_img i) : COLOR
	{
		float4 c = tex2D(_MainTex, i.uv);
		float r = (c.r+c.b+c.g)/3;
		
		float samp = floor(r*(_Low-1))/_Low;
		float2 uv = i.uv*_Overlay.xy/_Overlay.zw;
		uv.x = (uv.x,1/_Low)+samp;
		uv.y = (uv.y*_High,1);
		c = tex2D(_PatTex, uv);
		return c;
	}
	ENDCG

		}
	} 
	FallBack "Diffuse"
}

