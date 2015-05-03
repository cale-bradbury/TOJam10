Shader "CampCult/Skybox/Spacebox"
{
    Properties
    {
        _Color1 ("Color 1", Color) = (1, 1, 1, 0)
        _Color2 ("Color 2", Color) = (1, 1, 1, 0)
        _Shape ("Shape", Vector) = (1, 1, 1, 0)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }

    CGINCLUDE
    #include "UnityCG.cginc"

    struct appdata
    {
        float4 position : POSITION;
        float3 texcoord : TEXCOORD0;
    };
    
    struct v2f
    {
        float4 position : SV_POSITION;
        float3 uv : TEXCOORD0;
    };
    
    half4 _Color1;
    half4 _Color2;
    float4 _Shape;
    sampler2D _MainTex;
    
    v2f vert (appdata v)
    {
        v2f o;
        o.position = mul (UNITY_MATRIX_MVP, v.position);
        o.uv = v.texcoord;
        return o;
    }
    
    fixed4 frag (v2f i) : COLOR
    {
    	float2 uv = abs(i.uv.xy*_Shape.x+_Time.y*_Shape.zw);
    	uv.x = abs(fmod(uv.x,_Shape.y)-_Shape.y*.5);
    	uv.x += _Time.y*_Shape.z;
    	
    	uv.y = abs(fmod(uv.y,_Shape.y)-_Shape.y*.5);
    	uv.y += _Time.y*_Shape.w;
    	
    	uv+=_Time.y*_Shape.zw*.5;
    	uv = abs(fmod(uv,2.0)-1.0);    	
        float4 c = tex2D(_MainTex,uv);
        return lerp (_Color1, _Color2, c);
    }

    ENDCG

    SubShader
    {
        Tags { "RenderType"="Background" "Queue"="Background" }
        Pass
        {
            ZWrite Off
            Cull Off
            Fog { Mode Off }
            CGPROGRAM
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma vertex vert
            #pragma fragment frag
            ENDCG
        }
    }
}