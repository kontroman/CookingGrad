// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Based on cician's shader from: https://forum.unity3d.com/threads/simple-optimized-blur-shader.185327/#post-1267642

Shader "Custom/MaskedUIBlur" {
    Properties {
        _Size ("Blur", Range(0, 30)) = 1
        [HideInInspector] _MainTex ("Tint Color (RGB)", 2D) = "white" {}
		_GradTex("Grad Texture", 2D) = "white" {}
		[MaterialToggle] _Vertical("Vertical", Float) = 1
    }
 
    Category {
 
        // We must be transparent, so other objects are drawn before this one.
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Opaque" }
 


        SubShader 
        {
		// Horizontal blur
		GrabPass
	{
	}
            Pass 
            {             
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma fragmentoption ARB_precision_hint_fastest
                #include "UnityCG.cginc"
             
                struct appdata_t {
                    float4 vertex : POSITION;
                    float2 texcoord: TEXCOORD0;
                };
             
                struct v2f {
                    float4 vertex : POSITION;
                    float4 uvgrab : TEXCOORD0;
                    float2 uvmain : TEXCOORD1;
                };

                sampler2D _MainTex;
				sampler2D _GradTex;
				float4 _MainTex_ST;
				float _Vertical;
				// Materials often have Tiling and Offset fields for their texture properties.
				// This information is passed into shaders in a float4 {TextureName}_ST property: (
				// x contains X tiling value; 	y contains Y tiling value; z contains X offset value; w contains Y offset value )

                v2f vert (appdata_t v)
                {
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);

					#if UNITY_UV_STARTS_AT_TOP
					float scale = -1.0;
					#else
					float scale = 1.0;
					#endif

					o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y * scale) + o.vertex.w) * 0.5;
					o.uvgrab.zw = o.vertex.zw;

					o.uvmain = TRANSFORM_TEX(v.texcoord, _MainTex);
					//The vertex and fragment programs here don’t do anything fancy;
					//vertex program uses the TRANSFORM_TEX macro from UnityCG.cginc to make sure 
					//texture scale and offset is applied correctly, and fragment program just samples the texture and multiplies by the color property.
					return o;
                }
             
				sampler2D _GrabTexture;
				float4 _GrabTexture_TexelSize;	//  {TextureName}_TexelSize - a float4 property contains texture size information:(x contains 1.0 / width, y contains 1.0 / height, z contains width, w contains height)
											//https://docs.unity3d.com/Manual/SL-PropertiesInPrograms.html

				float _Size;

                half4 frag( v2f i ) : COLOR 
                {      
					half4 sum = half4(0,0,0,0);
					float alpha =(_Vertical)? tex2D(_GradTex, float2(0.5f, i.uvmain.y)).r : tex2D(_GradTex, float2(0.5f, i.uvmain.x)).r;
                 

                    #define GRABPIXEL(weight,kernelx) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x + _GrabTexture_TexelSize.x * kernelx * _Size * alpha, i.uvgrab.y, i.uvgrab.z, i.uvgrab.w))) * weight

                    sum += GRABPIXEL(0.05, -4.0);
                    sum += GRABPIXEL(0.09, -3.0);
                    sum += GRABPIXEL(0.12, -2.0);
                    sum += GRABPIXEL(0.15, -1.0);
                    sum += GRABPIXEL(0.18,  0.0);
                    sum += GRABPIXEL(0.15, +1.0);
                    sum += GRABPIXEL(0.12, +2.0);
                    sum += GRABPIXEL(0.09, +3.0);
                    sum += GRABPIXEL(0.05, +4.0);

                    return sum ;
                }
                ENDCG
            }

            // Vertical blur
            GrabPass 
            {
         
            }

            Pass
            {             
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma fragmentoption ARB_precision_hint_fastest
                #include "UnityCG.cginc"
             
                struct appdata_t {
                    float4 vertex : POSITION;
                    float2 texcoord: TEXCOORD0;
                };
             
                struct v2f {
                    float4 vertex : POSITION;
                    float4 uvgrab : TEXCOORD0;
                    float2 uvmain : TEXCOORD1;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
				sampler2D _GradTex;
				float _Vertical;

                v2f vert (appdata_t v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);

                    #if UNITY_UV_STARTS_AT_TOP
                    float scale = -1.0;
                    #else
                    float scale = 1.0;
                    #endif

                    o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y * scale) + o.vertex.w) * 0.5;
					o.uvgrab.zw = o.vertex.zw;

					o.uvmain = TRANSFORM_TEX(v.texcoord, _MainTex);

                    return o;
                }
             
                sampler2D _GrabTexture;
                float4 _GrabTexture_TexelSize;
                float _Size;
             
                half4 frag( v2f i ) : COLOR 
                {
                	//float alpha = tex2D(_MainTex, i.uvmain).a;
                    half4 sum = half4(0,0,0,0);
					float alpha = (_Vertical) ? tex2D(_GradTex, float2(0.5f, i.uvmain.y)).r : tex2D(_GradTex, float2(0.5f, i.uvmain.x)).r;

                    #define GRABPIXEL(weight,kernely) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x, i.uvgrab.y + _GrabTexture_TexelSize.y * kernely * _Size * alpha, i.uvgrab.z, i.uvgrab.w))) * weight

                    sum += GRABPIXEL(0.05, -4.0);
                    sum += GRABPIXEL(0.09, -3.0);
                    sum += GRABPIXEL(0.12, -2.0);
                    sum += GRABPIXEL(0.15, -1.0);
                    sum += GRABPIXEL(0.18,  0.0);
                    sum += GRABPIXEL(0.15, +1.0);
                    sum += GRABPIXEL(0.12, +2.0);
                    sum += GRABPIXEL(0.09, +3.0);
                    sum += GRABPIXEL(0.05, +4.0);

					return sum;
                }
                ENDCG
            }
        }
    }
}