Shader "CampCult/Vac/DefaultItem" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_HoloMode("HoloMode",float) = 0
		_Holo("Holo",Vector) = (0,0,0,0)
		_HoloColor("HoloColor",Color) = (1,1,1,1)
	}
	Category{
		Blend SrcAlpha OneMinusSrcAlpha
		Tags {Queue = Transparent}
		Cull Off
	    SubShader {
	        Pass {	            
	            CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				float4 _Color;
				float4 _HoloColor;
				float _HoloMode;
				float4 _Holo;
				sampler2D _MainTex;
				float4 _vac; //xyz = vas pos - z =vac strength
				
				struct appdata {
					float4 vertex : POSITION;
					float2 uv : TEXCOORD;
				};
				struct v2f {
					float4 vertex : POSITION;
					float4 world: TEXCOORD1;
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
					o.world = world;
					o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.uv = v.uv;
					return o;
				};
				half4 frag(v2f i) : COLOR {
					float4 c = tex2D(_MainTex,i.uv)*_Color;
					
					float4 h = lerp(c,_HoloColor,.5);
					float3 f = i.world.xyz*_Holo.xyz;
					h.a *= sin(f.x+f.y+f.z+_Holo.w*_Time.y)*.25+.75;
					c = lerp(c,h,_HoloMode);
					
					return c;
				};
				ENDCG
	        }
	    }
    }
	FallBack "Diffuse"
}
