using Photon.Pun;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Tile Prefabs array
    // Add default tile as array item[0]
    public GameObject[] tilePrefabs;
    private Transform map;
    private PhotonView PV;


    public bool mapGenerated;

    [Header("Map Config")]
    // Seed
    public int seed;

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
        if (!mapGenerated)
        {
            PV.RPC("RPC_CreateMap", RpcTarget.AllBuffered);
        }
        //RPC_CreateMap();
    }

    [PunRPC]
    public void RPC_CreateMap()
    {
        Random.InitState(seed);

        totalTiles = width * height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Offset at odd rows
                float xPos = x;
                if (y % 2 == 1)
                {
                    xPos += oddRowXOffset;
                }

                // Instantiate the Hex tile object
                map = GameObject.Find("Map").transform;
                GameObject hex = Instantiate(Resources.Load("Hex"), new Vector3(xPos, 0, y * zOffset), Quaternion.identity, map) as GameObject;

                // Instantate tiles with random rotation within the hex object position 
                // and as its child
                Quaternion randomRot = Quaternion.Euler(new Vector3(0, 60 * Random.Range(0, 5), 0));
                
                int rngValue = Random.Range(0, 100);
                
                if (rngValue <= percentTile1)
                {
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
        // Add the spawn points to the GameSetup after map generation
        GameSetup.GS.spawnPoints.Add(map.GetChild(0));
        GameSetup.GS.spawnPoints.Add(map.GetChild(map.childCount - 1));
        mapGenerated = true;
        Debug.Log("Map generated");
        this.enabled = false;
    }

    void CreateTile(GameObject prefab, GameObject hex, Quaternion randomRot)
    {
        Instantiate(prefab, hex.transform.position, randomRot, hex.transform);
        hex.name = prefab.tag;

        System.Type mType = null;
        if (hex.name == "Forest")
        {
            mType = System.Type.GetType("Forest");            
        }
        else if (hex.name == "Grassland")
        {
            mType = System.Type.GetType("Grassland");
        }
        else if (hex.name == "Mountain")
        {
            mType = System.Type.GetType("Mountain");
        }
        else if (hex.name == "Water")
        {
            mType = System.Type.GetType("Water");
        }
        hex.AddComponent(mType);
        //Debug.Log(hex.name + " created");
    }
}