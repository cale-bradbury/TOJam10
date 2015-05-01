// colored vertex lighting
Shader "Shrooms/Blobs" {
    // a single color property
    Properties {
	    _MainTex("Texture", 2D) = "white"{}
        _phaseX ("X Phase",Float) = 0
        _phaseZ ("Z Phase",Float) = 0
        _freqX ("X Frequency", Float) = 0
        _freqZ ("Z Frequency", Float) = 0
        _height("Height",Float) = 0
        _baseHeight("Base Height",Float) = 0
        _funcA("Function A", Range(0,1)) = 1
        _funcB("Function B", Range(0,1)) = 0
        _funcC("Function C", Range(0,1)) = 0
    }
    Category{
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest Greater 0.5
		Tags {"Queue"="Transparent"}
    // define one subshader
    SubShader {
        Pass {
            
            CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			sampler2D _MainTex;
			float _phaseX;
			float _phaseZ;
			float _freqX;
			float _freqZ;
			float _height;
			float _baseHeight;
			float _funcA;
			float _funcB;
			float _funcC;
			
			struct appdata {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tex : TEXCOORD0;
			};
			struct v2f {
				float4 vertex : POSITION;
				float4 tex : TEXCOORD;
				
			};
			
			float getHeight(float x, float z){
				//x+=transform.position.x;
				//z+=transform.position.z;
				return (sin(_freqX*.01*x+_phaseX)*cos(_freqZ*.01*z+_phaseZ))*_height;
			};
			v2f vert(appdata v) {
				v2f o;
				v2f vert;
				vert.vertex = mul(_Object2World, v.vertex);
				v.vertex.y += getHeight(vert.vertex.x,vert.vertex.z);
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.tex = v.tex*10;//(vert.vertex * 0.5 + 0.5)*_Color;
				return o;
			};
			half4 frag(v2f i) : COLOR {
				float2 strength;
				strength.x = cos(i.tex.y)*sin(i.tex.x)*.5+.5;
				strength.y=0;
				return tex2D (_MainTex, strength);
			};
			
			
			ENDCG
        }
    }
    }
    Fallback "VertexLit"
}