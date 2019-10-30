using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Tile Prefabs array
    // Add default tile as array item[0]
    public GameObject[] tilePrefabs;

    private PhotonView PV;

    [Header("Map Config")]
    // Size of the map in amount of 
    // tiles in each direction. 
    public int width;
    public int height;
    // Map detail config
    public int percentTile1;
    public int percentTile2;
    public int percentTile3;
    // Map Info
    [Header("Map Info")]
    public int totalTiles;
    public int tile0Total;
    public int tile1Total;
    public int tile2Total;
    public int tile3Total;

    // Hex Offset
    float oddRowXOffset = 0.5f;
    float zOffset = 0.866f;

    void Start()
    {
        PV = GetComponent<PhotonView>();

        totalTiles = width * height;

        for (int x = 0; x < width; x++)
        {            
            for (int y = 0; y < height; y++)
            {
                // Offset at odd rows
                float xPos = x;
                if ( y % 2 == 1 )
                {
                    xPos += oddRowXOffset;
                }

                // Instantiate the Hex tile object
                GameObject hex = Instantiate(Resources.Load("Hex"), new Vector3(xPos, 0, y * zOffset), Quaternion.identity, this.transform) as GameObject;

                // Instantate tiles with random rotation within the hex object position 
                // and as its child
                Quaternion randomRot = Quaternion.Euler(new Vector3(0, 60 * Random.Range(0, 5), 0));
                int rngValue = Random.Range(0, 100);
                if (rngValue <= percentTile1)
                {
                    //Instantiate(tilePrefabs[1], new Vector3(xPos, 0, y * zOffset), randomRot, this.transform);
                    CreateTile(tilePrefabs[1], hex, randomRot);
                    tile1Total++;
                }
                else if (rngValue <= percentTile1 + percentTile2 && tilePrefabs.Length > 2)
                {
                    CreateTile(tilePrefabs[2], hex, randomRot);
                    tile2Total++;
                }
                else if (rngValue <= percentTile1 + percentTile2 + percentTile3 && tilePrefabs.Length > 3)
                {
                    CreateTile(tilePrefabs[3], hex, randomRot);
                    tile3Total++;
                }
                else
                {
                    CreateTile(tilePrefabs[0], hex, randomRot);
                    tile0Total++;
                }
            }
        }
        Debug.Log("Map generated");
    }

    private void CreateTile(GameObject prefab, GameObject hex, Quaternion randomRot)
    {
        Instantiate(prefab, hex.transform.position, randomRot, hex.transform);
        hex.name = prefab.tag;
        //Debug.Log(hex.name + " created");
    }
}