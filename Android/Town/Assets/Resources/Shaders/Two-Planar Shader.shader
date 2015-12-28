Shader "Custom/Two-Planar Shader" {
	Properties {
		_Texture("Texture", 2D) = "white" {}
		_Scale("Scale", Float) = 2
	}
	
	SubShader {
		Tags {
			"Queue"="Geometry"
			"IgnoreProjector"="False"
			"RenderType"="Opaque"
		}

		Cull Back
		ZWrite On
		
		CGPROGRAM
		#pragma surface surf Lambert
		#pragma exclude_renderers flash

		sampler2D _Texture;
		float _Scale;
		
		struct Input {
			float3 worldPos;
			float3 worldNormal;
		};
			
		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = tex2D(_Texture, frac(IN.worldPos.xy) * _Scale);
		} 
		ENDCG
	}
	Fallback "Diffuse"
}
