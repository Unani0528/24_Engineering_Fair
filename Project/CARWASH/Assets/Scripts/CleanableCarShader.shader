Shader "Custom/OverlayDirtShader"
{
    Properties
    {
        _DirtTex("Dirt Texture", 2D) = "white" {}    // ������ �ؽ�ó
        _CleanMask("Clean Mask", 2D) = "white" {}    // Render Texture, û�ҵ� �κ� ǥ��
    }
        SubShader
    {
        Tags { "RenderType" = "Transparent" }
        LOD 200
        Blend SrcAlpha OneMinusSrcAlpha

        CGPROGRAM
        #pragma surface surf Standard alpha:fade

        sampler2D _DirtTex;
        sampler2D _CleanMask;

        struct Input
        {
            float2 uv_DirtTex;
            float2 uv_CleanMask;
        };

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            // ������ ���� ����(Material Color)�� ����
            fixed4 originalColor = fixed4(0, 0, 0, 0); // �⺻������ ������, �������� ����

            // Dirt Texture (������ �ؽ�ó) ��������
            fixed4 dirtColor = tex2D(_DirtTex, IN.uv_DirtTex);

            // Clean Mask���� û�ҵ� �κ� ��������
            fixed4 cleanMask = tex2D(_CleanMask, IN.uv_CleanMask);

            // Dirt Texture�� ���ĸ� �����Ͽ� û�ҵ� �κа� û�ҵ��� ���� �κ��� ����
            fixed4 finalColor = lerp(dirtColor, originalColor, cleanMask.r);

            // Albedo (�⺻ ����)�� ���� ��� ������ ����
            o.Albedo = finalColor.rgb;
            o.Alpha = finalColor.a;
        }
        ENDCG
    }
        FallBack "Diffuse"
}
