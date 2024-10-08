Shader "Custom/YellowGlow"
{
    Properties
    {
        _Color ("Glow Color", Color) = (1,1,0,1) // 노란색
        _GlowIntensity ("Glow Intensity", Range(0, 5)) = 1.0
        _Frequency ("Flicker Frequency", Range(0.1, 10)) = 2.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        half4 _Color;
        float _GlowIntensity;
        float _Frequency;

        struct Input
        {
            float3 worldPos;
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            // 시간에 따라 변하는 값을 사용하여 깜빡임 효과 적용
            float glow = _GlowIntensity * abs(sin(_Frequency * _Time.y));
            o.Albedo = _Color.rgb * glow;
            o.Emission = _Color.rgb * glow;
        }
        ENDCG
    }
    FallBack "Diffuse"
}