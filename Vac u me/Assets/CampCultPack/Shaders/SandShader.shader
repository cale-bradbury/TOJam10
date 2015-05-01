// colored vertex lighting
Shader "SandShader" {
    // a single color property
    Properties {
	    _MainTex("Color Texture", 2D) = "white"{}
	    _NoiseTex("Noise Texture", 2D) = "white"{}
	    _Noise("Noise Offset",Float) = 0
        _phaseX ("X Phase",Float) = 0
        _phaseZ ("Z Phase",Float) = 0
        _freqX ("X Frequency", Float) = 0
        _freqZ ("Z Frequency", Float) = 0
        _height("Height",Float) = 0
        _baseHeight("Base Height",Float) = 0
        _funcA("Function A", Range(0,1)) = 1
        _funcB("Function B", Range(0,1)) = 0
        _funcC("Function C", Range(0,1)) = 0
    }
    Category{
    // define one subshader
    SubShader {
    	
        Pass {
            
            CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#include "UnityCG.cginc"
			sampler2D _MainTex;
			sampler2D _NoiseTex;
			float4 _MainTex_ST;
			float4 _NoiseTex_ST;
			float _Noise;
			float _phaseX;
			float _phaseZ;
			float _freqX;
			float _freqZ;
			float _height;
			float _baseHeight;
			float _funcA;
			float _funcB;
			float _funcC;
			
			struct appdata {
				float4 vertex : POSITION;
				float4 tex : TEXCOORD0;
			};
			struct v2f {
				float4 vertex : POSITION;
				float4 tex : TEXCOORD;
				
			};
			
			float getHeight(float x, float z){
				//x+=transform.position.x;
				//z+=transform.position.z;
				return ((sin(_freqX*.01*x+_phaseX)*cos(_freqZ*.015*z+_phaseZ))*.5+.5)*_height*.10+
					max(0,sin(_freqX*.001*x+_phaseX*.1+cos(_freqZ*.002*z+_phaseZ*.2))*cos(_freqZ*.001*(x+z)+sin(z*.006)*cos(-x*.007))*_height*.90);
			};
			v2f vert(appdata v) {
				v2f o;
				float4 world = mul(_Object2World, v.vertex);
				float height = getHeight(world.x,world.z);
				v.vertex.y += height;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.tex.xy = world.xz;//(vert.vertex * 0.5 + 0.5)*_Color;
				o.tex.zw = world.xz;//TRANSFORM_TEX(world.xz, _NoiseTex);
				o.tex.z =height/_height;
				return o;
			};
			half4 frag(v2f i) : COLOR {
				float2 strength = i.tex.xy*.01;
				strength.y+=_Noise;
				float4 samp = tex2D(_NoiseTex,TRANSFORM_TEX(strength, _NoiseTex));
				strength.x = pow(sin(((i.tex.x+i.tex.y)*.1+sin(i.tex.x*.01)*20*cos(i.tex.z*2))*.1)*.5+.5,2)*.3+.5;
				strength.x+=(samp.x-.5)*.7;
				//strength.x = clamp(strength.x,.01,.99);
				strength.y=sin(samp.y)*.4+.5;
				float4 c = tex2D (_MainTex,TRANSFORM_TEX(strength, _MainTex));
				c *=(i.tex.z)*.3+.7;
				c.a=1;
				return c;
			};
			
			
			ENDCG
        }
    }
    }
    Fallback "VertexLit"
}