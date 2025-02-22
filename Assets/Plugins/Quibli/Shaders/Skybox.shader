﻿Shader "Quibli/Skybox" {
    Properties {
        [Gradient(1024)] _Gradient("Gradient", 2D) = "white" {}

        [Space]
        _Intensity ("Intensity", Range (0, 5)) = 1.0
        _Exponent ("Exponent", Range (0, 5)) = 1.0

        [Space]
        _DirectionYaw ("Direction X angle", Range (0, 1)) = 0
        _DirectionPitch ("Direction Y angle", Range (0, 1)) = 0
    }

    CGINCLUDE

    #include "UnityCG.cginc"

    struct appdata {
        float4 position : POSITION;
        float3 texcoord : TEXCOORD0;
    };
    
    struct v2f {
        float4 position : SV_POSITION;
        float3 texcoord : TEXCOORD0;
    };

    UNITY_DECLARE_TEX2D_FLOAT(_Gradient);
	CBUFFER_START(UnityPerMaterial)
    float _DirectionYaw, _DirectionPitch;
    float _Intensity;
    float _Exponent;
	CBUFFER_END

    v2f vert (appdata v) {
        v2f o;
        o.position = UnityObjectToClipPos(v.position);
        o.texcoord = v.texcoord;
        return o;
    }
    
    fixed4 frag (v2f i) : COLOR {
        const float pitch = _DirectionPitch * UNITY_PI;
        const float yaw = _DirectionYaw * UNITY_PI;
        const float3 direction = float3(sin(pitch) * sin(yaw), cos(pitch), sin(pitch) * cos(yaw));
        const float d = dot(normalize(i.texcoord), direction) * 0.5f + 0.5f;
        const float alpha = pow(d, _Exponent);
        return UNITY_SAMPLE_TEX2D(_Gradient, float2(alpha, 0.5f)) * _Intensity;
    }

    ENDCG

    SubShader {
        Tags { "RenderType"="Background" "Queue"="Background" }

        Pass {
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
