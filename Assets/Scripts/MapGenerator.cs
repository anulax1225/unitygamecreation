using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode { NoiseMap, ColourMap };
    public DrawMode drawMode;
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    //Limiting input between 0 and 1.
    [Range(0,1)]
    public float persistance;
    
    public int octaves;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public TerrainType[] regions;


    public bool autoUpdate;


    //Calls the perlin noise map function and passes 
    //the returned value to the display function.
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        Color[] coulourMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y];
                for(int i = 0; i < regions.length; i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        coulourMap[y * mapWidth + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }
        MainDisplay display = FindObjectOfType<MainDisplay>();

        //Choosing with map to draw.
        if (drawMode = DrawMode.NoiseMap)
        {
            display.DrawNoiseMap(noiseMap);
        }
        else if (drawMode == DrawMode.ColourMap)
        {

        }
        
    }

    //This function will be called every time a change to parametres is made.
    void OnValidation()
    {
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }
        if (mapHeight < 1)
        {
            mapHeight = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
    }
}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color colour;
}
