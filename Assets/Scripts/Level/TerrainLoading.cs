using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainLoading : MonoBehaviour
{
    public float Amplitude = 0.001f;
    public float WaveLength = 1f;

    private Terrain terrain;
    private int sizeX;
    private int sizeY;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        sizeX = terrain.terrainData.heightmapWidth;
        sizeY = terrain.terrainData.heightmapHeight;

        RaiseTerrain();
        CreateMountains();
    }

    private void RaiseTerrain()
    {
        Debug.Log("Raising Terrain..");
        // get the heights of the terrain under this game object
        float[,] heights = GetTerrainHeights();

        // we set each sample of the terrain in the size to the desired height
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                heights[y, x] += Amplitude;
            }
        }

        SetTerrainHeights(heights);
    }

    private void CreateMountains()
    {
        int nbMountains = Random.Range(0, 5);
        Debug.Log("Creating " + nbMountains + " Mountains..");

        List<Vector2> mountainPositions = new List<Vector2>();
        for (int i = 0; i < nbMountains; i++)
        {
            Vector2 position;
            position.x = Random.Range(0, sizeX);
            position.y = Random.Range(0, sizeY);
            mountainPositions.Add(position);
        }

        float[,] heights = GetTerrainHeights();

        foreach (Vector2 mountainPosition in mountainPositions)
        {
            int x = (int)mountainPosition.x;
            int y = (int)mountainPosition.y;

            int mountainSize = Random.Range(15, 50);

            for (int i = x - mountainSize; i < x + mountainSize; i++)
            {
                for (int j = y - mountainSize; j < y + mountainSize; j++)
                {
                    if (j > 0 && j < sizeY && i > 0 && i < sizeX)
                    {
                        heights[j, i] += 0.05f;
                    }
                }
            }
        }

        SetTerrainHeights(heights);
    }

    private float[,] GetTerrainHeights()
    {
        return terrain.terrainData.GetHeights(0, 0, sizeX, sizeY);
    }

    private void SetTerrainHeights(float[,] _heights)
    {
        terrain.terrainData.SetHeights(0, 0, _heights);
    }
}
