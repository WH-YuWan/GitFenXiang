Shader "Hidden/VertexAttributeViewer"
{
    Properties
    {
        _ShowID("显示ID",float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal :NORMAL;
                float4 tangent :TANGENT;
                float4 color :COLOR;
                float4 uv1 : TEXCOORD0;
                float4 uv2 : TEXCOORD1;
                float4 uv3 : TEXCOORD2;
                float4 uv4 : TEXCOORD3;
            };

            struct v2f
            {
                
                float4 uv1 : TEXCOORD7;
                float4 uv2 : TEXCOORD8;
                float4 uv3 : TEXCOORD9;
                float4 uv4 : TEXCOORD10;
                float3 biTangentWS :TEXCOORD11;
                float4 positionOS :TEXCOORD1;
                float4 positionWS :TEXCOORD2;
                float3 normalOS :TEXCOORD3;
                float3 normalWS :TEXCOORD4;
                float4 color :TEXCOORD5;
                float3 tangentWS :TEXCOORD6;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _ShowID; 

            v2f vert (appdata v)
            {
                v2f o = (v2f)0;
                o.positionOS =v.vertex;
                o.positionWS =mul(unity_ObjectToWorld,v.vertex);
                o.normalOS =v.normal;
                o.normalWS = UnityObjectToWorldNormal(v.normal);
                o.color = v.color;
                o.tangentWS =UnityObjectToWorldDir(v.tangent);
                half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
                o.biTangentWS = cross(o.normalWS, o.tangentWS) * tangentSign;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv1 = v.uv1;
                o.uv2 = v.uv2;
                o.uv3 = v.uv3;
                o.uv4 = v.uv4;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 c = 0;
                switch(_ShowID)
                {
                    case 0:
                    c=i.positionOS;
                    break;
                    
                    case 1:
                    c=i.positionWS;
                    break;

                    case 2:
                    c=float4(i.normalOS,1);
                    break;

                    case 3:
                    c=float4(i.normalWS,1);
                    break;
                    case 4:
                    c=i.color;
                    break;
                    case 5:
                    c=float4(i.tangentWS,1);
                    break;
                    case 6:
                    c=float4(i.biTangentWS,1);
                    break;

                    case 7:
                    c=i.uv1.x;
                    break;

                    case 8:
                    c=i.uv1.y;
                    break;

                    case 9:
                    c=i.uv2.x;
                    break;

                    case 10:
                    c=i.uv2.y;
                    break;

                    case 11:
                    c=i.uv3.x;
                    break;
                    case 12:
                    c=i.uv3.y;
                    break;
                }

                return c;
            }
            ENDCG
        }
    }
}
