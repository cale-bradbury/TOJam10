// colored vertex lighting
Shader "Cale/Ripple Ring" {
    // a single color property
    Properties {
        _MainTex("Texture", 2D) = "white"{}
        _x ("X Freq-Phase-Amp-Speed",Vector) = (0,0,0,0)
        _y ("Z Freq-Phase-Amp-Speed", Vector) = (0,0,0,0)
    }
    Category{
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest Greater 0.5
		Tags {"Queue"="AlphaTest"}
    // define one subshader
    SubShader {
        Pass {
            
            CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			float4 _x;
			float4 _y;
			float4 _z;
			float4 _xStrength;
			float4 _yStrength;
			float4 _zStrength;
			sampler2D _MainTex;
			struct appdata {
				float4 vertex : SV_POSITION;
				float4 tex : TEXCOORD0;
			};
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				
			};
			
			v2f vert(appdata v) {
				v2f o;
				float4 vert = mul(_Object2World, v.vertex);
				float deg = atan(vert.xz);
				v.vertex.xz += float2(sin((deg+vert.y)*_x.x+_x.y+_Time.y*_x.w)*_x.z,cos((deg+vert.y)*_y.x+_y.y+_Time.y*_y.w)*_y.z);
				o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
	            o.uv = v.tex;//TRANSFORM_TEX(v.tex, _MainTex);
	            return o;
			};
			half4 frag(v2f i) : COLOR {;
				return tex2D (_MainTex, i.uv);
			};
			
			
			ENDCG
        }
    }
    }
    Fallback "VertexLit"
} 