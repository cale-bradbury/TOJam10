Shader "Cale/TweenGradientInverseTex" {
	Properties {
		_color1 ("Grad 1 Color 1", Color) = (1,.5,.5,1)
		_color2 ("Grad 1 Color 2", Color) = (.5,1,1,1)
		_color3 ("Grad 2 Color 1", Color) = (.5,1,.5,1)
		_color4 ("Grad 2 Color 2", Color) = (.5,.5,1,1)
		_inter("Interpolation",Range(0,1))=0
		_MainTex ("SelfIllum Color (RGB) Alpha (A)", 2D) = "white"{}
	}
	Category{
		Blend SrcAlpha OneMinusSrcAlpha
		Tags {Queue=Transparent}
		SubShader {
			Pass{
			
				CGPROGRAM
// Upgrade NOTE: excluded shader from DX11 and Xbox360; has structs without semantics (struct v2f members uv_MainTex)
#pragma exclude_renderers d3d11 xbox360
				#pragma vertex vert
				#pragma fragment frag

				float4 _color1;
				float4 _color2;	
				float4 _color3;
				float4 _color4;		
				float _inter;	
				sampler2D _MainTex;
				
				struct appdata {
					float4 vertex : POSITION;
					float4 tex : TEXCOORD0;
					float3 normal : NORMAL;
				};
				struct v2f {
					float4 vertex : TEXCOORD;
					float4 pos : POSITION;
				};
				v2f vert(appdata v) {
					v2f o;
					o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
					o.vertex = v.tex;
					return o;
				};
				
				half4 frag(v2f i) : COLOR {
					_color1 = (_color1*i.vertex.y+_color2*(1-i.vertex.y))*_inter+ (_color3*i.vertex.y+_color4*(1-i.vertex.y))*(1-_inter);
					_color1.a *= tex2D(_MainTex,i.vertex.xy).a;
					
					return _color1;
				};

				ENDCG
			}
		}
	} 
	FallBack "Diffuse"
}
