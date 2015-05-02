Shader "CampCult/Vac/DefaultItem" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	Category{
		Blend SrcAlpha OneMinusSrcAlpha
		Tags {Queue = Transparent}
	    SubShader {
	        Pass {	            
	            CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				float4 _Color;
				sampler2D _MainTex;
				float4 _Vac; //xyz = vas pos - z =vac strength
				
				struct appdata {
					float4 vertex : POSITION;
					float2 uv : TEXCOORD;
				};
				struct v2f {
					float4 vertex : POSITION;
					float2 uv:TEXCOORD;
				};
				v2f vert(appdata v) {
					v2f o;
					v.vertex.x += sin(_freq.x*v.vertex.y+_phase.x*_Time.y)*_amp.x;
					v.vertex.y += sin(_freq.y*v.vertex.z+_phase.y*_Time.y)*_amp.y;
					v.vertex.z += sin(_freq.z*v.vertex.x+_phase.z*_Time.y)*_amp.z;
					o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.uv = v.uv;
					return o;
				};
				half4 frag(v2f i) : COLOR {
					return texture2D(_MainTex,i.uv)*_Color;
				};
				ENDCG
	        }
	    }
    }
	FallBack "Diffuse"
}
