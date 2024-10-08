Shader "Custom/HitShader"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _MultiplyColor ("Multiply Color", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Sprite"}
        LOD 200

        // 알파 블렌딩 설정 추가
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing

            #include "UnityCG.cginc"

            sampler2D _MainTex;

            UNITY_INSTANCING_BUFFER_START(Props)
                UNITY_DEFINE_INSTANCED_PROP(fixed4, _MultiplyColor)
            UNITY_INSTANCING_BUFFER_END(Props)

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            v2f vert (appdata_t v)
            {
                UNITY_SETUP_INSTANCE_ID(v);
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, i.uv);
                fixed4 multiplyColor = UNITY_ACCESS_INSTANCED_PROP(_MultiplyColor_arr, _MultiplyColor);
                if (c.a > 0)
                {
                    c.rgb *= multiplyColor.rgb;
                    c.a *= multiplyColor.a;
                }
                

                return c;
            }
            ENDCG
        }
    }
    FallBack "Sprites/Diffuse"
}
