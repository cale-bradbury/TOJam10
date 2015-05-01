Shader "Cale/Scan" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Scan Color",Color) = (1,0,1,1)
		_Shape("info", Vector) = (0,0,0,0)
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
		float4 _Shape;
		float4 _Color;
		
		struct appdata
        {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
        };

        struct v2f
        {
                float4 vertex : SV_POSITION;
                float4 pos : COLOR;
                half2 uv : TEXCOORD0;
        };
		
        v2f vert (appdata v)
        {
                v2f o;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.pos = ComputeScreenPos(v.vertex);//mul(_Object2World, o.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
        };
		
		float4 frag(v2f i):COLOR{
			const float TAU = 6.2831853;
			float4 c = tex2D (_MainTex, i.uv);//samples the texture
            c = lerp(c,_Color,fmod(i.pos.y*_Shape.x+_Shape.y*_Time.y+(sin(i.pos.x*_Shape.z+_Shape.y*_Time.y)*_Shape.w),1));              
			return c;
		};
		#ENDCG
	} 
	}
	}
	FallBack "Diffuse"
}
