using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Utils
{
    public static void SavaObjectToFile(Object obj, string fileName)
    {
        AssetDatabase.CreateAsset(obj, fileName);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    public static void SaveImageAsMat(Material mat, string imagePath)
    {
        Texture texture = Resources.Load(imagePath) as Texture;
        mat.mainTexture = texture;
        SavaObjectToFile(mat, "Assets/Resources/Materials/" + imagePath +".mat");
    }

    public static void BuildMaterialsFromImages(Deck deck)
    {
        Card card = deck.GetNextCard();
        while (card != null)
        {
            Debug.Log(card.ToString());
            Material mat = new Material(Shader.Find("Standard"));
            string path = "cards/" + card.ToString();
            SaveImageAsMat(mat, path);
            card = deck.GetNextCard();
        }

    }
}
