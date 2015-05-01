Shader "Custom/SkySphere" {
        Properties {
                _MainTex ("Base (RGB)", 2D) = "white" {}
                _Wind ("Direction XYZ, Speed W", Vector) = (0,0,1,1)
                _LoopSize ("Loop Size", float) = 0.1
                _Tint ("Tint RGB + Alpha", Color) = (1,1,1,1)
                _Tint2 ("Tint RGB + Alpha", Color) = (1,1,1,1)
        }
        SubShader {
                Tags { "Queue"="Transparent" "RenderType"="Transparent" }
                blend SrcAlpha OneMinusSrcAlpha
                ZWrite Off Fog { Mode Off }
                Cull Front
               
            Pass {
                CGPROGRAM
// Upgrade NOTE: excluded shader from DX11 and Xbox360; has structs without semantics (struct v2f members pos)
#pragma exclude_renderers d3d11 xbox360
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"
       
                float _LoopSize;
                float4 _Tint;
                float4 _Tint2;
                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _Wind;
               
                struct v2f {
                        float4 vertex : SV_POSITION;
                        float2 texcoord : TEXCOORD0;
                        float4 test:COLOR;
                        float4 pos;
                };
               
                v2f vert (appdata_full v)
                {
                        v2f o;
                        o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                        o.texcoord = v.texcoord;
                        o.test = mul(_Object2World,  v.vertex);
                        o.pos = sin(o.test*_Time.x*_Wind.x*.1);
                        return o;
                }
 
                fixed4 frag (v2f i ) : COLOR
                {
                        fixed timer = _Time.x*_Wind.w;
 
                        float loop0 = sin(timer);
                        float loop1 = sin(timer+0.5);
                        fixed4 texA = tex2D (_MainTex, (i.texcoord+_MainTex_ST.zw+ (i.pos.xyz*loop0*_LoopSize))*_MainTex_ST.xy )*_Tint;
                        fixed4 texB = tex2D (_MainTex, (i.texcoord+_MainTex_ST.zw+ (i.pos.xyz*loop1*_LoopSize))*_MainTex_ST.xy )*_Tint2;
                        fixed4 col = lerp(texA,texB,sin(loop0+(i.test.z*_Wind.y*.1))*.5+.5);
                        return col;
                }
               
                ENDCG
                }
        }
        FallBack "Diffuse"
}