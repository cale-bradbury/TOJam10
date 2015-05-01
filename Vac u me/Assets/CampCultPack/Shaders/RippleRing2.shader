//ripple effect on the y axis
//uses world space too :D
//by Cale Bradbury (@netgrind)
//use for whatever wherever whenever
Shader "Cale/Ripple Ring 2" {
    Properties {
        _MainTex("Texture", 2D) = "white"{}
        _x ("Freq-Phase-Amp-Speed",Vector) = (0,0,0,0)
    }
    Category{
        Blend SrcAlpha OneMinusSrcAlpha
        AlphaTest Greater 0.5
        Tags {"Queue"="AlphaTest"}
        Cull Off
    SubShader {
        Pass {
	        CGPROGRAM
	        #pragma vertex vert
	        #pragma fragment frag
	        #include "UnityCG.cginc"
	        float4 _x;
	        sampler2D _MainTex;
	        float4 _MainTex_ST;
	        struct appdata {
	                float4 vertex : SV_POSITION;
	                float4 tex : TEXCOORD0;
	        };
	        struct v2f {
	                float4 pos : SV_POSITION;
	                float2 uv : TEXCOORD0;
	               
	        };
	       
	        v2f vert(appdata v) {
	                v2f o;
	                float4 y = mul(_Object2World, v.vertex).y;
	                float deg = atan2(v.vertex.z, v.vertex.x);
	                float dis = length(v.vertex.xz);
	                dis += sin(y*_x.x+_x.y+_Time.y*_x.w)*_x.z;
	                v.vertex.xz = float2(cos(deg)*dis,sin(deg)*dis);
	                o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
	                o.uv = v.tex;
	                return o;
	        };
	        half4 frag(v2f i) : COLOR {
	                return tex2D (_MainTex, i.uv*_MainTex_ST.xy+_MainTex_ST.zw);
	        };
	       
	       
	        ENDCG
        }
        
    }
	}
}