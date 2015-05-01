Shader "CampCult/testShader" {
    Properties {
        _Color ("Main Color", Color) = (1,.5,.5,1)
        _phase ("Phase",Vector) = (1,1,1,1)
        _amp ("Amplitude",Vector) = (0,0,0,1)
        _freq ("Frequency", Vector) = (0,0,0,1)
    }
    Category{
		Blend SrcAlpha OneMinusSrcAlpha
		Tags {Queue = Transparent}
	    SubShader {
	        Pass {	            
	            CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				float4 _Color;
				float4 _phase;
				float4 _amp;
				float4 _freq;
				struct appdata {
					float4 vertex : POSITION;
					float3 normal : NORMAL;
				};
				struct v2f {
					float4 vertex : POSITION;
					float4 color : COLOR;
				};
				v2f vert(appdata v) {
					v2f o;
					v.vertex.x += sin(_freq.x*v.vertex.y+_phase.x*_Time.y)*_amp.x;
					v.vertex.y += sin(_freq.y*v.vertex.z+_phase.y*_Time.y)*_amp.y;
					v.vertex.z += sin(_freq.z*v.vertex.x+_phase.z*_Time.y)*_amp.z;
					o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.color = (v.vertex * 0.5 + 0.5)*_Color;
					o.color.rgb= sin(o.color.rgb*10.+_Time.y)*.5+.5;
					return o;
				};
				half4 frag(v2f i) : COLOR {
					//_Color.x = i.pos.y;
					return i.color;
				};
				ENDCG
	        }
	    }
    }
    Fallback "VertexLit"
} 