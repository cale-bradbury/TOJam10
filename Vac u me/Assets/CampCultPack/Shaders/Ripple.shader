// colored vertex lighting
Shader "Cale/Ripple" {
    // a single color property
    Properties {
        _MainTex("Texture", 2D) = "white"{}
        _x ("X Freq-Phase-Amp-Speed",Vector) = (0,0,0,0)
        _y ("Y Freq-Phase-Amp-Speed", Vector) = (0,0,0,0)
        _z ("Z Freq-Phase-Amp-Speed", Vector) = (0,0,0,0)
        _xStrength("X Wave Strength",Vector) = (0,1,0,0)
        _yStrength("Y Wave Strength",Vector) = (0,0,1,0)
        _zStrength("Z Wave Strength",Vector) = (1,0,0,0)
    }
    Category{
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest Greater 0.5
		Tags {"Queue"="AlphaTest"}
    // define one subshader
    SubShader {
        Pass {
            name "BASE"
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
			float4 _MainTex_ST;
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
				v.vertex.x += sin(_x.x*(_xStrength.x*v.vertex.x+_xStrength.y*v.vertex.y+_xStrength.z*v.vertex.z)+_x.y+_Time.y*_x.w)*_x.z;
				v.vertex.y += sin(_y.x*(_yStrength.x*v.vertex.x+_yStrength.y*v.vertex.y+_yStrength.z*v.vertex.z)+_y.y+_Time.y*_y.w)*_y.z;
				v.vertex.z += sin(_z.x*(_zStrength.x*v.vertex.x+_zStrength.y*v.vertex.y+_zStrength.z*v.vertex.z)+_z.y+_Time.y*_z.w)*_z.z;
	            o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
	            o.uv = TRANSFORM_TEX(v.tex, _MainTex);
	            return o;
			};
			half4 frag(v2f i) : COLOR {
				return tex2D (_MainTex, i.uv);
			};
			
			
			ENDCG
        }
    }
    }
    Fallback "VertexLit"
} 