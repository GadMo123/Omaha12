Shader "Custom/Glow"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _GlowColor ("Glow Color", Color) = (1, 1, 1, 1)
    _GlowStrength ("Glow Strength", Float) = 1.0
  }
  SubShader
  {
    Tags { "RenderType"="Opaque" }
    LOD 200

    CGPROGRAM
      #pragma surface surf Standard fullforwardshadows

      fixed4 _MainTex; // Texture (sampler2D)
      fixed4 _GlowColor;
      float _GlowStrength;

      struct Input
      {
        float2 texcoord0 : TEXCOORD0; // Texture coordinates
      };

      void surf (Input IN, inout SurfaceOutputStandard o)
      {
        fixed4 texColor = tex2D (_MainTex, IN.texcoord0); // Sample texture using texture coordinates
        fixed4 glow = texColor * _GlowColor;
        o.Albedo = lerp(texColor, glow, _GlowStrength);
      }
    ENDCG
  }
  FallBack "Diffuse"
}