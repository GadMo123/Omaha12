using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ImagesToMatsUtils
{

    const float brightness = 50.5f;

    public static void SavaObjectToFile(Object obj, string fileName)
    {
        AssetDatabase.CreateAsset(obj, fileName);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    public static void SaveImageAsMat(Material mat, string imagePath)
    {
        Texture2D texture = Resources.Load(imagePath) as Texture2D;
        BrightnessContrast(texture, 1f,1f, brightness);
        mat.mainTexture = texture;
        SavaObjectToFile(mat, "Assets/Resources/Materials/" + imagePath + ".mat");
    }

    public static void BuildMaterialsFromImages(Deck deck)
    {
        Card card = deck.GetNextCard();
        while (card != null)
        {
            Material mat = new Material(Shader.Find("Standard"));
            string path = "cards/" + card.toString();
            SaveImageAsMat(mat, path);
            card = deck.GetNextCard();
        }

    }

    public static float AdjustChannel(float colour,
           float brightness, float contrast, float gamma)
    {
        return Mathf.Pow(colour, gamma) * contrast + brightness;
    }

    public static Texture2D BrightnessContrast(Texture2D tex,
          float brightness = 1f, float contrast = 1f, float gamma = 1f)
    {
        float adjustedBrightness = brightness - 1.0f;

        Color[] pixels = tex.GetPixels();

        for (int i = 0; i < pixels.Length; i++)
        {
            var p = pixels[i];
            p.r = AdjustChannel(p.r, adjustedBrightness, contrast, gamma);
            p.g = AdjustChannel(p.g, adjustedBrightness, contrast, gamma);
            p.b = AdjustChannel(p.b, adjustedBrightness, contrast, gamma);
            pixels[i] = p;
        }

        tex.SetPixels(pixels);
        tex.Apply();

        return tex;
    }
}
