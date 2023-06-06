using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    /*
    Noise map generator with perlin noise. 
    Takes the size of the map as arguments 
    and returns the 2D perlin noise map. 
    */
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale) 
    {
        //Init of the 2D array of float of perlin noise value.
        float[,] noiseMap = new float[mapWidth, mapHeight];

        //Verifie the scale input to not divide by zero.
        if (scale <= 0) 
        {
            scale = 0.0001f;
        }

        for (int y = 0; y < mapHeight; y++) 
        {
            for (int x = 0; x < mapWidth; x++) 
            {
                float sampleX = x / scale;
                float sampleY = y / scale;
                //Calculating perlin noise with Math 
                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x,y] = perlinValue;
            }
        }
        return noiseMap;
    }
}
