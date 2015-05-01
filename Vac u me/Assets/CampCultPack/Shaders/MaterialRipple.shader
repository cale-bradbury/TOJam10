Shader "Cale/Material Ripple" {
	Properties {
		_MainTex ("Base (RGBA)", 2D) = "white" {}
		_SecondTex ("Second (RGBA)", 2D) = "white" {}
		_Shape("Shape X-Speed, YZW-Shape", Vector) = (1.5707,1,1,1)
	}
	
	Category{
		Blend SrcAlpha OneMinusSrcAlpha
		Tags {Queue = Transparent}
	SubShader {
	Pass{
		
		CGPROGRAM
		#pragma vertex vert
        #pragma fragment frag
		#pragma target 3.0
        #include "UnityCG.cginc"

		sampler2D _MainTex;
		float4 _MainTex_ST;
		sampler2D _SecondTex;
		float4 _Shape;
		
		struct appdata
        {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
        };

        struct v2f
        {
                float4 vertex : SV_POSITION;
                float4 pos;
                half2 uv : TEXCOORD0;
        };
		
        v2f vert (appdata v)
        {
                v2f o;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.pos = mul(_Object2World,  v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
        };
		
		float4 frag(v2f i):COLOR{
			const float TAU = 6.2831853;
			float4 c = tex2D (_MainTex, i.uv);//samples the texture
			float4 c2 = tex2D(_SecondTex,i.uv);
			float m = sin(
				i.pos.x*_Shape.x+
				i.pos.y*_Shape.y+
				i.pos.z*_Shape.z+
				_Time.y*_Shape.w)*.5+.5;
			return c*m+c2*(1-m);
		};
		#ENDCG
	} 
	}
	}
	FallBack "Diffuse"
}
