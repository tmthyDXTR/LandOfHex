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
            if (PV.ViewID == (int)1001)
            {
                //CreateMap();
                CreateAvatar(0);

            }
            // Secondd player at right spawn point
            else
            {
                CreateAvatar(1);
                PhotonNetwork.Instantiate("MapGenerator", this.transform.position, Quaternion.identity);
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
        Debug.Log("Create Avatar");
        myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"),
                        /*GameSetup.GS.spawnPoints[spawn].position*/ this.transform.position,
                        Quaternion.identity,
                        0);
        myAvatar.name = "myAvatar";
    }
    private void CreateMap()
    {
        Debug.Log("Create Map");
        //PV.RPC("RPC_CreateMap", RpcTarget.All);
    }
}
