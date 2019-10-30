using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public static GameSetup GS;
    private PhotonView PV;

    public MapGenerator mapGen;

    public bool mapLoaded = false;

    public List<Transform> spawnPoints = new List<Transform>();

    private void OnEnable()
    {
        if (GameSetup.GS == null)
        {
            GameSetup.GS = this;
        }               
    }


}
