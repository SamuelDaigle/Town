﻿using UnityEngine;

namespace Assets.Scripts.LevelComponents.Terrains
{
    public class TerrainRestore : MonoBehaviour
    {
        private float[,] oldTerrain;
        private Terrain terrain;
        private int terrainWidth;
        private int terrainHeight;

        void Start()
        {
            terrain = Terrain.activeTerrain;
            terrainWidth = terrain.terrainData.heightmapWidth;
            terrainHeight = terrain.terrainData.heightmapHeight;
            oldTerrain = terrain.terrainData.GetHeights(0, 0, terrainWidth, terrainHeight);
        }

        void OnDestroy()
        {
            RestoreTerrain();
        }

        public void RestoreTerrain()
        {
            // Don't reset the terrain if it hasn't changed.
            if (oldTerrain != null && terrain != null)
            {
                if (oldTerrain != terrain.terrainData.GetHeights(0, 0, terrainWidth, terrainHeight))
                {
                    terrain.terrainData.SetHeights(0, 0, oldTerrain);
                }
            }
        }
    }
}