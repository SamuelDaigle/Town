using UnityEngine;
using System.Collections;

public class TerrainLoading : MonoBehaviour 
{
    public int TerrainSize = 50;

	// Use this for initialization
	void Start () 
    {
        LoadGround();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private void LoadGround()
    {
        float groundTileSize = 2.26f;
        for (int i = 0; i < TerrainSize; i++)
        {
            GameObject groundTile = GameObject.Instantiate(Resources.Load("Terrain/Grass")) as GameObject;
            groundTile.transform.parent = gameObject.transform;
            groundTile.name = "ground";
            groundTile.transform.Translate(groundTileSize * i - (groundTileSize * TerrainSize) / 2, 0.5f, 0);
        }
    }
}
