using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generate the two map textures
public static class TextureGenerator
{
    //Generate texture for the colour map
    public static Texture2D TextureFromColourMap(Color[] colourMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colourMap);
        texture.Apply();
        return texture;
    }

    public static Texture2D TextureFromColourMap(float[,] noiseMap, TerrainType[] regions, int width, int height)
    {
        //Setting color in the colored map,
        //Picking colour from height value the regions colour 
        Color[] colourMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float currentHeight = noiseMap[x, y];
                for(int i = 0; i < GetLengthArray(regions); i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y * width + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }
        return TextureFromColourMap(colourMap, width, height);
    }

    public static Texture2D TextureFromNoiseMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        //Setting color in the noise matrix,
        //Picking colour between black and white 
        Color[] colourMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colourMap[y * width + x] = Color.Lerp(Color.white, Color.black, heightMap[x, y]);
            }
        }
        return TextureFromColourMap(colourMap, width, height);
    }

    private static int GetLengthArray(TerrainType[] array)
    {
        int cpt = 0;
        foreach (var item in array) 
        {
            cpt += 1;
        }
        return cpt;
    }
}
