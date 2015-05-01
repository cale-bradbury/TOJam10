Shader "Dezert/Hologram" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_StaticTex ("Static Noise", 2D) = "white" {}
		_Static("Static XZ-xy freq, YW-xy speed", Vector) = (1,1.5707,1,1.5707)
		_Color ("Scan Color",Color) = (1,0,1,1)
		_Scan("Scanlines X-Speed, YZW-Shape", Vector) = (1.5707,1,1,1)
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
		sampler2D _StaticTex;
		float4 _StaticTex_ST;
		float4 _Static;
		float4 _Color;
		float4 _Scan;
		
		struct appdata
        {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
        };

        struct v2f
        {
                float4 vertex : SV_POSITION;
                float4 pos : COLOR;
                float2 p;
                half2 uv : TEXCOORD0;
        };
		
        v2f vert (appdata v)
        {
                v2f o;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.pos = ComputeScreenPos(v.vertex);
                o.p = ComputeScreenPos(o.vertex);
                o.p = float2(sin(o.p.x*_Static.x+_Time.y*_Static.y),cos(o.p.y*_Static.z+_Time.y*_Static.w));
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
        };
		
		float4 frag(v2f i):COLOR{
			const float TAU = 6.2831853;
			float4 c = tex2D (_MainTex, i.uv);//samples the texture
			c.rgb -= sin(i.pos.x*_Scan.y*(i.pos.z/_Scan.z)+_Scan.x*_Time.y)*.3+.3;
			c.a = tex2D(_StaticTex,i.p)*.4+.6;
			return c;
		};
		#ENDCG
	} 
	}
	}
	FallBack "Diffuse"
}
