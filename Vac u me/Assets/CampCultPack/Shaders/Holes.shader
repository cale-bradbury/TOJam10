Shader "Cale/Hole"
{
        Properties
        {
                _MainTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
                _LeftEye ("Left Eye",Vector) = (0,0,0,0)
                _LeftOval("Left Eye Oval", float)= 1
        }
       
        SubShader
        {
                LOD 100
                Tags
                {
                        "Queue" = "Transparent"
                        "IgnoreProjector" = "True"
                        "RenderType" = "Transparent"
                }
               
                Cull Off
                Lighting Off
                ZWrite Off
                Fog { Mode Off }
                Offset -1, -1
                Blend SrcAlpha OneMinusSrcAlpha
 
                Pass
                {
                        CGPROGRAM
                                #pragma vertex vert
                                #pragma fragment frag
                                #include "UnityCG.cginc"
       
                                struct appdata_t
                                {
                                        float4 vertex : POSITION;
                                        float2 texcoord : TEXCOORD0;
                                        fixed4 color : COLOR;
                                };
       
                                struct v2f
                                {
                                        float4 vertex : SV_POSITION;
                                        half2 uv : TEXCOORD0;
                                        float4 color : COLOR0;
                                };
       
                                sampler2D _MainTex;
                                float4 _MainTex_ST;
                                float4 _LeftEye;
                                float _LeftOval;       
                               
                                v2f vert (appdata_t v)
                                {
                                        v2f o;
                                        o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                                        o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                                        o.color = v.color;
                                        return o;
                                }
                               
                                float4 frag(v2f i) : COLOR {
                                        float4 c = tex2D (_MainTex, i.uv) * i.color;//samples the texture
                                       
                                        c.a = min(c.a,clamp(distance(float2(i.uv.x,(_LeftEye.y-i.uv.y)*_LeftOval+i.uv.y), _LeftEye)*_LeftEye.z+_LeftEye.w,0,1));
                                        return c;
                                }
                        ENDCG
                }
        }
       
        
}