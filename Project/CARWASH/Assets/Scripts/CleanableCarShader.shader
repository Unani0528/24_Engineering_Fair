Shader "Custom/OverlayDirtShader"
{
    Properties
    {
        _DirtTex("Dirt Texture", 2D) = "white" {}    // 더러움 텍스처
        _CleanMask("Clean Mask", 2D) = "white" {}    // Render Texture, 청소된 부분 표시
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
            // 차량의 기존 색상(Material Color)을 유지
            fixed4 originalColor = fixed4(0, 0, 0, 0); // 기본적으로 검은색, 투명으로 시작

            // Dirt Texture (더러움 텍스처) 가져오기
            fixed4 dirtColor = tex2D(_DirtTex, IN.uv_DirtTex);

            // Clean Mask에서 청소된 부분 가져오기
            fixed4 cleanMask = tex2D(_CleanMask, IN.uv_CleanMask);

            // Dirt Texture의 알파를 조정하여 청소된 부분과 청소되지 않은 부분을 구분
            fixed4 finalColor = lerp(dirtColor, originalColor, cleanMask.r);

            // Albedo (기본 색상)에 최종 결과 색상을 적용
            o.Albedo = finalColor.rgb;
            o.Alpha = finalColor.a;
        }
        ENDCG
    }
        FallBack "Diffuse"
}
