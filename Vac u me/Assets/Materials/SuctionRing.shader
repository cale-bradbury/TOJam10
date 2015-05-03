Shader "CampCult/Vac/SuctionRing" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Color2("Color2", Color)=(1,1,1,1)
		_Shape("Shape",Vector) = (1,1,1,1)
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
				float4 _Color2;
				float4 _Shape;
				sampler2D _MainTex;
				
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
					o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.uv = v.uv;
					return o;
				};
				half4 frag(v2f i) : COLOR {
					float2 uv = i.uv-.5;
					float d = length(uv);
					float a = atan2(uv.y,uv.x)/3.14159;
					a+=d*_Shape.x-_Time.y*_Shape.w;
					uv = float2(abs(fmod(d+_Time.y*_Shape.z,2.0)-1.0),a);
					float4 c = tex2D(_MainTex,uv);
					c = lerp(_Color,_Color2,c);
					c.a *= 1.0-d*2.0;
					return c;
				};
				ENDCG
	        }
	    }
    }
	FallBack "Diffuse"
}
