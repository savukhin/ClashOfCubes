Shader "Unlit/CellUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1, 1)
        _UVCutoff ("UV Cutoff", Range(0, 1)) = 0.1
        [Toggle]_Active ("Active", Float) = 0
    }
    SubShader
    {
        Tags {
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 100
        
        // ZWrite On
        // ZTest Always
        // Cull Off
        Blend SrcAlpha OneMinusSrcAlpha

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float _UVCutoff;
            float _Active;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                float x = i.uv.x;
                if (i.uv.x > 0.5)
                    x = 1 - i.uv.x;
                float y = i.uv.y;
                if (i.uv.y > 0.5)
                    y = 1 - i.uv.y;
                
                if (x > _UVCutoff && y > _UVCutoff) {
                    if (_Active)
                        col.a = saturate(1 - pow(x - _UVCutoff + y - _UVCutoff, 2));
                    else
                        discard;
                }
                return col;
            }
            ENDCG
        }
    }
}
