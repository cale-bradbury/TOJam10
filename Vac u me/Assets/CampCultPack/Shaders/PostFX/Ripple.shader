﻿Shader "Cale/Ripple" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_Strength("Strength",float)=0
	_Phase("Phase",float)=0
	_Freq("Freq",float)=0
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
uniform float _Strength;
uniform float _Phase;
uniform float _Freq;

fixed4 frag (v2f_img i) : COLOR
{
	float2 uv = i.uv;
	uv-=.5;
	float a = atan2(uv.y,uv.x);
	float d = length(uv);
	d+=sin(_Phase+d*_Freq)*_Strength+_Strength;
	uv.x = cos(a)*d;
	uv.y = sin(a)*d;
	
	return tex2D(_MainTex, uv+.5);
}
ENDCG

	}
}

Fallback off

}