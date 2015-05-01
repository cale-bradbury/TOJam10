Shader "Dezert/Default Transparent" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SpecTex("Spec Map",2D)  = "black"{}
		_Shininess ("Shininess", Range (0.03, 1)) = 0.05
		_Ramp("Ramp",2D) = "white"{}
		_RampOff("Ramp Off",Range(0,1)) = 0
		_Shroom("Shroom",Range(0,1)) = 1
		_ShroomTex("Shroom Tex",2D) = "white"{}
		_ShroomShape("Shroom Shape",Vector) = (0,0,0,0)
		_ShroomColor ("Shroom Color", Color) = (1,1,1,1)
	}
	Category{
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest Greater 0.5
		SubShader {
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
			CGPROGRAM
			#pragma multi_compile ScreenOverlayOff ScreenOverlay
			#pragma multi_compile RadialRippleOff RadialRipple
			#pragma surface surf SimpleSpecular vertex:vert		
			#pragma target 3.0	
			sampler2D _MainTex;
			sampler2D _SpecTex;
			sampler2D _Ramp;
			half _Shininess;
			half _RampOff;
			fixed4 _Color;
			
			float _Shroom;
			sampler2D _ShroomTex;
			float4 _ShroomTex_ST;
			float4 _ShroomShape;
			float4 _ShroomColor;
			
			half4 LightingSimpleSpecular (SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
		        half3 h = normalize (lightDir + viewDir);

		        half diff = max (0, dot (s.Normal, lightDir));
				half3 ramp = tex2D (_Ramp, float2(diff,_SinTime.w)).rgb;
		        float nh = max (0, dot (s.Normal, h));
		        float spec = pow (nh, 48.0)*s.Specular;

		        half4 c;
		        c.rgb = (s.Albedo * _LightColor0.rgb * ramp + _LightColor0.rgb * spec) * (atten * 2);
		        c.a = s.Alpha;
		        return c;		        
		    }
			
			struct Input {
				float2 uv_MainTex;
				float2 uv_SpecTex;
				float4 screenPos;
			};
			
			void vert(inout appdata_full v){
			
				#ifdef RadialRipple
					float y = mul(_Object2World, v.vertex).y;
	                float deg = atan2(v.vertex.z, v.vertex.x);
	                float dis = length(v.vertex.xz);
	                dis += (sin(y*_ShroomShape.x+_ShroomShape.y+_Time.y)+_ShroomShape.w)*_ShroomShape.z;
	                v.vertex.xz = float2(cos(deg)*dis,sin(deg)*dis);
                #endif
			}
			
			void surf (Input IN, inout SurfaceOutput o) {
				fixed4  c = tex2D(_MainTex, IN.uv_MainTex);
				fixed4  spec = tex2D(_SpecTex, IN.uv_SpecTex);
				o.Albedo = c.rgb*_Color.rgb;
				o.Alpha = c.a*_Color.a;
				o.Gloss = spec.r;
				o.Specular = _Shininess*spec.r;
				
		        #ifdef ScreenOverlay
		        	c = tex2D(_ShroomTex,((IN.screenPos.xy*_ShroomTex_ST.xy)/IN.screenPos.w)+_ShroomTex_ST.wz);
		        	c.rgb *= _ShroomColor.a;
		        	o.Albedo.rgb += lerp(o.Albedo.rgb,c.rgb,c.a);
		        #endif
			}
			ENDCG
		} 
	}
	FallBack "Diffuse"
}

