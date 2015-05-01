Shader "Cale/TweenGradient" {
	Properties {
		_color1 ("Grad 1 Color 1", Color) = (1,.5,.5,1)
		_color2 ("Grad 1 Color 2", Color) = (.5,1,1,1)
		_color3 ("Grad 2 Color 1", Color) = (.5,1,.5,1)
		_color4 ("Grad 2 Color 2", Color) = (.5,.5,1,1)
		_offset("Interpolation Offset",Float)=0
		_speed("Interpolation Speed",Float)=1
		_alpha("Alpha", Range(0,1)) = 0
		_MainTex ("SelfIllum Color (RGB) Alpha (A)", 2D) = "white"{}
	}
	Category{
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest Greater 0
		Tags {"Queue"="Transparent"}
		SubShader {
			Pass{
			
				CGPROGRAM
// Upgrade NOTE: excluded shader from DX11 and Xbox360; has structs without semantics (struct v2f members vertex)
//#pragma exclude_renderers d3d11 xbox360
				#pragma vertex vert
				#pragma fragment frag

				float4 _color1;
				float4 _color2;	
				float4 _color3;
				float4 _color4;		
				float _offset;			
				float _speed;
				float _alpha;	
				sampler2D _MainTex;
				float4 _MainTex_ST;
				
				struct appdata {
					float4 vertex : POSITION;
					float2 tex : TEXCOORD0;
				};
				struct v2f {
					float2 vertex:TEXCOORD1;
					float2 uv : TEXCOORD0;
					float4 pos : POSITION;
				};
				v2f vert(appdata v) {
					v2f o;
					o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
					o.vertex = v.tex;
					o.uv = v.tex*_MainTex_ST.xy+_MainTex_ST.zw;
					return o;
				};
				
				float4 frag(v2f i) : COLOR {
					const float PI = 3.14159;
					float _inter = sin(_offset+_Time.y*_speed*PI)*.5+.5;
					_color1.rgba = (_color1.rgba *i.vertex.y+_color2.rgba *(1-i.vertex.y))*_inter+ (_color3.rgba *i.vertex.y+_color4.rgba *(1-i.vertex.y))*(1-_inter);
					float4 s = tex2D(_MainTex,i.uv.xy).rgba;
					_color1 *= s;
					_color1.a = min(s.a,_alpha);
					return _color1;
				};

				ENDCG
			}
		}
	} 
	FallBack "Diffuse"
}
