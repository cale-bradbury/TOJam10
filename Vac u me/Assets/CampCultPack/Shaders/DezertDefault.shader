Shader "Dezert/Default" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		UsePass "Specular/BASE"
	} 
	FallBack "Specular"
}

