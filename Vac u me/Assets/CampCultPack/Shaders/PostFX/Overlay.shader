Shader "Cale/Overlay" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_Alpha ("Alpha", float) = 1
	_Overlay("Overlay",2D) = "white"{}
}

SubShader {
	Pass {
		ZTest Always Cull Off ZWrite Off
		Fog { Mode off }

CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag
//#pragma fragmentoption ARB_precision_hint_fastest
#include "UnityCG.cginc"

uniform sampler2D _MainTex;
uniform sampler2D _Overlay;
uniform float4 _MainTex_ST;
uniform float _Alpha;

fixed4 frag (v2f_img i) : COLOR
{
	float2 uv = i.uv*_MainTex_ST.xy+_MainTex_ST.zw;
	return lerp(tex2D(_MainTex, uv),tex2D(_Overlay,uv),_Alpha);
}
ENDCG

	}
}

Fallback off

}