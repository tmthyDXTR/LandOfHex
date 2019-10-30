using Photon.Pun;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView PV;
    public GameObject myAvatar;

    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            // First player spawns
            int spawn;
            if (PV.ViewID == (int)1001)
            {
                spawn = 0;
                CreateAvatar(spawn);
                //PV.RPC("SetPlayerName", RpcTarget.AllBuffered, "Player1");

            }
            // Secondd player at right spawn point
            else
            {
                spawn = 1;
                CreateAvatar(spawn);
                //PV.RPC("SetPlayerName", RpcTarget.AllBuffered, "Player2");
            }
        }
    }
    //[PunRPC]
    //void SetPlayerName(string name)
    //{        
    //    myAvatar.name = name;        
    //}




    private void CreateAvatar(int spawn)
    {
        myAvatar = PhotonNetwork.Instantiate(Path.Combine("Resources", "PlayerAvatar"),
                        GameSetup.GS.spawnPoints[spawn].position,
                        Quaternion.identity,
                        0);
        myAvatar.name = "myAvatar";
    }

}
