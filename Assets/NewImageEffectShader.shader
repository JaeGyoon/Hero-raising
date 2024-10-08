Shader "Custom/GlowImageEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GlowIntensity ("Glow Intensity", Range(0, 10)) = 1.0
        _GlowSpeed ("Glow Speed", Range(0, 10)) = 2.0 // 두 배속
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _GlowIntensity;
            float _GlowSpeed;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                // Glow effect
                float glow = abs(sin(_Time.y * _GlowSpeed)); // 0 to 1
                glow = smoothstep(0.0, 1.0, glow);
                col.rgb += glow * _GlowIntensity;

                return col;
            }
            ENDCG
        }
    }
}