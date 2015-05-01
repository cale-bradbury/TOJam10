Shader "CampCult/Generators/WiggleBeams" {
	Properties {
		_Color("Color",Color) = (1,1,1,1)
		_Color2("Color2",Color) = (1,1,1,1)
		_Phase("Phase",float) = 0
		_Freq("Freq", float) = 0
		_WigglePhase("Wiggle Phase",float)=0
		_WiggleFreq("Wiggle Freq",float)=0
		_WiggleAmp("Wiggle Amp",float)=0
	}
	Category{
		Blend SrcAlpha OneMinusSrcAlpha
		Tags {Queue = Transparent}
		SubShader {
			Pass{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#pragma target 3.0
			#include "UnityCG.cginc"
				float4 _Color;
				float4 _Color2;
				float _Phase;
				float _Freq;
				float _WigglePhase;
				float _WiggleFreq;
				float _WiggleAmp;
								
				float2 rotate(float2 p, float angle){
					float2 r;
					r.x = cos(angle)*p.x-sin(angle)*p.y;
					r.y = sin(angle)*p.x+cos(angle)*p.y;
					return r;
				}
				
				float4 frag(v2f_img i) : COLOR {
					i.uv = i.uv*2-1;
					i.uv = rotate(i.uv, _Phase+sin(_WiggleFreq*length(i.uv)+_WigglePhase)*_WiggleAmp);
					return lerp(_Color2,_Color,abs(sin(_Freq*atan2(i.uv.x,i.uv.y))));
				}
			ENDCG
			}
		} 
	}
}
