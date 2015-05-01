Shader "CampCult/Rezlike/RezWireframe" {
    Properties {
	    _Color("Color",Color)=(1.0,1.0,1.0,1.0)
	    _FaceColor("FaceColor",Color)=(0.0,0.0,0.0,0.0)
	 	_EdgeSize("EdgeSize",Range (0.0, 1.0))=0.1
	 	_FogColor("FogColor",Color) = (0.0,0.0,0.0,1.0)
	 	_FogEnd("FogEnd",float)=100.0
	 	_KillFreq("KillFreq",float) = 1000.0
	 	_Kill("Kill",float) = 0
    }
    Category{
		Blend SrcAlpha OneMinusSrcAlpha
		Tags {"Queue" = "Transparent"}
	    SubShader {
	        Pass {   
	    		//Lighting Off      
	    		Cull Front  
	            CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 3.0
				#include "UnityCG.cginc"
				float4 _Color;
				float4 _FaceColor;
				float _EdgeSize;
				float4 _FogColor;
				float _Kill;
				float _FogEnd;
				float _KillFreq;
				
				struct appdata {
					float4 vertex : POSITION;
					float4 tex:TEXCOORD0;
				};
				struct v2f {
					float4 pos : POSITION;	
					float4 vert: TEXCOORD0;	
					float fog:TEXCOORD1;
					//float4 world;	
				};
				v2f vert(appdata v) {
					v2f o;
					v.vertex.xyz += sin(v.vertex.xyz*(_KillFreq)+_Time.y*3.1415)*_Kill;
					o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
					o.vert = v.tex;//v.vertex;
					float4 world = mul(_Object2World, v.vertex);
					o.fog = world.z/_FogEnd;
					return o;
				};
				half4 frag(v2f i) : COLOR {
					float s = min(i.vert.x,min(i.vert.y,min(1.0-i.vert.x,1.0-i.vert.y)));
					float4 c = lerp(lerp(_Color,_FaceColor,smoothstep(0.0,_EdgeSize,s)), _FogColor,i.fog);
					c.a*=(1.0-_Kill);
					return c;
				};
				ENDCG
	        }
	        Pass {   
	    		//Lighting Off      
	    		Cull Back  
	            CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 3.0
				#include "UnityCG.cginc"
				float4 _Color;
				float4 _FaceColor;
				float _EdgeSize;
				float4 _FogColor;
				float _Kill;
				float _FogEnd;
				float _KillFreq;
				
				struct appdata {
					float4 vertex : POSITION;
					float4 tex:TEXCOORD0;
				};
				struct v2f {
					float4 pos : POSITION;	
					float4 vert: TEXCOORD0;	
					float fog:TEXCOORD1;
					//float4 world;	
				};
				v2f vert(appdata v) {
					v2f o;
					v.vertex.xyz += sin(v.vertex.xyz*(_KillFreq)+_Time.y*3.14158)*_Kill;
					o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
					o.vert = v.tex;//v.vertex;
					float4 world = mul(_Object2World, v.vertex);
					o.fog = world.z/_FogEnd;
					return o;
				};
				half4 frag(v2f i) : COLOR {
					float s = min(i.vert.x,min(i.vert.y,min(1.0-i.vert.x,1.0-i.vert.y)));
					float4 c = lerp(lerp(_Color,_FaceColor,smoothstep(0.0,_EdgeSize,s)), _FogColor,i.fog);
					c.a*=(1.0-_Kill);
					return c;
				};
				ENDCG
	        }
	    }
    }
    Fallback "VertexLit"
}