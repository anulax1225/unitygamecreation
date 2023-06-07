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
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset) 
    {
        //Init of the 2D array of float of perlin noise value.
        float[,] noiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(seed);
        Vector2[] octavesOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octavesOffsets[i] = new Vector2(offsetX, offsetY);
        }

        //Verifie the scale input to not divide by zero.
        if (scale <= 0) 
        {
            scale = 0.0001f;
        }

        //Creation Noise value at extremes 
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        //Making it so that changes comes from the center
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++) 
        {
            for (int x = 0; x < mapWidth; x++) 
            {
                //Controlling the wave lenght and height
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;


                for (int i = 0; i < octaves; i++)
                {
                    //Offset the the sampled X and Y
                    float sampleX = (x - halfWidth) / scale * frequency + octavesOffsets[i].x;
                    float sampleY = (y - halfHeight) / scale * frequency + octavesOffsets[i].y;

                    //Calculating perlin noise with Math 
                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;
                    amplitude *= persistance;
                    frequency *= lacunarity;

                }

                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                } 
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }

                noiseMap[y, x] = noiseHeight;
            }
        }
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x,y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x,y]);
            }
        }
        return noiseMap;
    }
}
