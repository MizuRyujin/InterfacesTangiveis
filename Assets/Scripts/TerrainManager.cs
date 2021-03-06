﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public Terrain terrain;
    public int xOffest;
    public int yOffset;

    public void GenerateTerrain()
    {
        int width = 513;
        int height = 513;

        float startF = 1.5f;
        float startA = 0.3f;

        float[,] heightData = new float[width, height];

        int thing = ((int)transform.position.x / 1000) * (width -1) * 2;
        int thing2 = ((int)transform.position.z / 1000) * (height-1) * 2;

        for (int i = 0; i < 4; i++)
        {
            for (int x = 0; x < width * 2; x += 2)
            {
                for (int y = 0; y < height * 2; y += 2)
                {
                    int nY = y + thing ;
                    int nX = x + thing2 ;

                    float xx = ((startF * nX / width) + 1);
                    float yy = ((startF * nY / height) + 1);

                    float data = Mathf.PerlinNoise(xx + xOffest, yy + yOffset);

                    int dX = x == 0 ? x : x / 2;
                    int dY = y == 0 ? y : y / 2;

                    heightData[dX, dY] += (data * startA);
                }
            }
            startF *= 2f;
            startA /= 2;
        }

        terrain.terrainData.SetHeights(0, 0, heightData);

        float[,,] map = new float[terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight, 3];

        // For each point on the alphamap...
        for (var y = 0; y < terrain.terrainData.alphamapHeight; y++)
        {
            for (var x = 0; x < terrain.terrainData.alphamapWidth; x++)
            {
                // Get the normalized terrain coordinate that
                // corresponds to the the point.
                float normX = (float)(x * 1.0 / (terrain.terrainData.alphamapWidth - 1));
                float normY = (float)(y * 1.0 / (terrain.terrainData.alphamapHeight - 1));

                // Get the steepness value at the normalized coordinate.
                float angle = terrain.terrainData.GetSteepness(normX, normY);

                // Steepness is given as an angle, 0..90 degrees. Divide
                // by 90 to get an alpha blending value in the range 0..1.
                float frac = angle / 80.0f;

                map[x, y, 0] = frac;
                map[x, y, 1] = 1 - frac;

                if (heightData[x, y] <= 0.3f)
                {
                    map[x, y, 2] = (Mathf.Abs(heightData[x, y] - 0.3f) / 0.2f) * 2;
                }
            }
        }
        terrain.terrainData.SetAlphamaps(0, 0, map);
        terrain.terrainData.SetTreeInstances(terrain.terrainData.treeInstances, true);

        // Get all of layer zero.
        var grassMap = terrain.terrainData.GetDetailLayer(0, 0, terrain.terrainData.detailWidth, terrain.terrainData.detailHeight, 0);

        // For each pixel in the detail map...
        for (int y = 0; y < terrain.terrainData.detailHeight; y++)
        {
            for (int x = 0; x < terrain.terrainData.detailWidth; x++)
            {
                // Get the normalized terrain coordinate that
                // corresponds to the the point.
                float normX = (float)(x * 0.5f / ((terrain.terrainData.alphamapWidth) - 1));
                float normY = (float)(y * 0.5f / ((terrain.terrainData.alphamapHeight) - 1));

                // Get the steepness value at the normalized coordinate.
                float angle = terrain.terrainData.GetSteepness(normX, normY);

                // Steepness is given as an angle, 0..90 degrees. Divide
                // by 90 to get an alpha blending value in the range 0..1.
                float frac = angle / 90.0f;

                grassMap[x, y] = 20;

                // If the pixel value is below the threshold then
                // set it to zero.
                if (frac < 0.45f || heightData[x/2,y/2] <= 0.22f)
                {
                    grassMap[x, y] = 0;

                }
            }
        }

        // Assign the modified map back.
        terrain.terrainData.SetDetailLayer(0, 0, 0, grassMap);

    }
}