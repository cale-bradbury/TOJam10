Shader "CampCult/LSDZen" {
Properties {
	_Shape ("Shape X-XScale Y-YScale Z-Loops W-Time", Vector) = (.1,.1,.1,0)
	_x ("X X-Wiggle Y-Ripple z-null W-null", Vector) = (.1,.1,.1,0)
	_v ("V X-Wiggle Y-Ripple z-null W-null", Vector) = (.1,.1,.1,0)
}

SubShader {
 	Tags{ "Queue" = "Transparent" "RenderType" = "Transparent"}
 	Blend SrcAlpha OneMinusSrcAlpha
	Pass {
		Cull Front
				
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest 
#pragma target 3.0
#include "UnityCG.cginc"
#define PI 3.14158

uniform float4 _Shape;
uniform float4 _x;
uniform float4 _v;
struct appdata_t
{
        float4 vertex : POSITION;
        float2 texcoord : TEXCOORD0;
};

struct v2f
{
        float4 vertex : SV_POSITION;
        half2 uv : TEXCOORD0;
};

v2f vert (appdata_t v){
        v2f o;
        float t = _Time.y*_Shape.w;
        o.vertex = v.vertex;
        o.vertex.xyz+=sin(o.vertex.xyz*_v.x*cos(_v.y*o.vertex.z+t)+t)*_v.w;
        o.vertex = mul(UNITY_MATRIX_MVP, o.vertex);
        o.uv = o.vertex.xy*2.;
        return o;
}

float f(float3 p, float t) 
{ 
    p.z-=t*_x.y;
    return length(cos(p)-.1*cos(9.*(p.z+.1*p.x-p.y)+t*1.8))-(_x.z+sin(t)*.1); 
}

fixed4 frag (v2f_img v2f) : COLOR
{
    float i = _Time.y*_Shape.w;
    
    float3 d = (float3(.5-v2f.uv,.1));
    d.xy*=_Shape.xy;
    d.x = abs(d.x);
    float3 o=d;
    float l = length(d.xyz)*_x.x;
    float a = atan2(d.y,d.x);
    float2x2 m = float2x2(cos(i+sin(a+i))+10.0, sin(i*.5+a*l)*2.0, -sin(i+a),cos(i*d.z+l)+10.0);
    o.xy = mul(m,o.xy);
    for(int i=0;i<int(_Shape.z);i++){
        o+=f(o,i)*d*_x.w;
    }
    o.z = length(o*d);
    
	return float4(sin(i+abs((o-d)+length(o.xy*step(o.z,700.0))))*.3+.7,.7);
}
ENDCG

	}
}

Fallback off

}