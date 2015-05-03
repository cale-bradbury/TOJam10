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
				float4 _vac; //xyz = vas pos - z =vac strength
				
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
					float4 world = mul (_Object2World, v.vertex);
					float d = distance(world.xyz,_vac.xyz)/_vac.w;
					d = max(0.0,1.0-d);
					d = pow(d,4.0);
					world.xyz = lerp(world.xyz,_vac.xyz,d);
					v.vertex = mul (_World2Object, world);
					
					o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.uv = v.uv;
					return o;
				};
				half4 frag(v2f i) : COLOR {
					return tex2D(_MainTex,i.uv)*_Color;
				};
				ENDCG
	        }
	    }
    }
	FallBack "Diffuse"
}
