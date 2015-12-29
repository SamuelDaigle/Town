using UnityEngine;
using System.Collections;

public class TerrainLoading : MonoBehaviour 
{
    void Start()
    {
        Terrain terrain = Terrain.activeTerrain;
        int sizeX = 200;
        int sizeY = 200;
        int posXInTerrain = -100;
        int posYInTerrain = -100;

        // get the heights of the terrain under this game object
        float[,] heights = terrain.terrainData.GetHeights(posXInTerrain, posYInTerrain, sizeX, sizeY);

        // we set each sample of the terrain in the size to the desired height
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                heights[y, x] += Mathf.Sin(Time.deltaTime);
            }
        }

        // set the new height
        terrain.terrainData.SetHeights(posXInTerrain, posYInTerrain, heights);
    }
}
