Shader "Custom/Gradient" {
	Properties {
		_color1 ("Color 1", Color) = (1,.5,.5,1)
		_color2 ("Color 2", Color) = (.5,1,1,1)
	}
	SubShader {
	Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
	Blend SrcAlpha OneMinusSrcAlpha 
	Lighting Off
		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4 _color1;
			float4 _color2;			
			
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
				v2f vf;
				vf.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				vf.vertex = v.tex;
				return vf;
			};
			float4 frag(v2f i) : COLOR {
				_color1.r = (_color1.r*i.vertex.y+_color2.r*(1-i.vertex.y));
				_color1.g = (_color1.g*i.vertex.y+_color2.g*(1-i.vertex.y));
				_color1.b = (_color1.b*i.vertex.y+_color2.b*(1-i.vertex.y));
				_color1.a = (_color1.a*i.vertex.y+_color2.a*(1-i.vertex.y));
				return _color1;
			};

			ENDCG
		}
	} 
	FallBack "Diffuse"
}
