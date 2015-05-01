Shader "Cale/Compression" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_Last ("last frame", 2D) = "white" {}
	_Flow ("flow control", 2D) = "white" {}
	_Stop ("stop control", 2D) = "white" {}
	_x("x-SampleX y-SampleY z-angle w-null",Vector) = (0,0,.1,0)
}

SubShader {
	Pass {
		ZTest Always Cull Off ZWrite Off
		Fog { Mode off }
				
CGPROGRAM
#pragma multi_compile radial nradial
#pragma vertex vert_img
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest 
#pragma target 3.0
#include "UnityCG.cginc"

uniform sampler2D _MainTex;	//the screen texture
uniform sampler2D _Last;	//the last frames texture
uniform sampler2D _Flow;	//texture to control distance shited per channel
uniform float4 _Flow_ST;
uniform sampler2D _Stop;	//texture to stop flow per channel
uniform float4 _Stop_ST;

uniform float4 _x;			//x/y-max flow distance		z-angle when not radial		w-frame/last frame lerp
uniform float4 _center;

fixed4 frag (v2f_img i) : COLOR
{
	float2 uv = i.uv;
	float4 c = tex2D(_MainTex,uv);
	#if !UNITY_UV_STARTS_AT_TOP
		uv.y = 1.0-uv.y;
	#endif
	float4 f = tex2D(_Flow,uv*_Flow_ST.xy+_Flow_ST.zw);
	float4 stop = tex2D(_Stop,uv*_Stop_ST.xy+_Stop_ST.zw);
	
	#ifdef radial
		float angle = atan2(uv.y-_center.y,uv.x-_center.x);
	#else
		float angle = _x.z;
	#endif
	
	float2 t = uv;
	t.x = cos(angle)*f.r*_x.x;
	t.y = sin(angle)*f.r*_x.y;
	float4 s = tex2D(_Last,uv-t*stop.r);
	s.g = tex2D(_Last,uv-t*stop.g).g;
	s.b = tex2D(_Last,uv-t*stop.b).b;
	s.a = tex2D(_Last,uv-t*stop.a).a;
	
	return (lerp(c,s,_x.w));
}
ENDCG

	}
}

Fallback off

}