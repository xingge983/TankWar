using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class launch : MonoBehaviourPunCallbacks
{

    public Text time;
    public static int timeval=2000;
    public int starttime = 1000;
    public static bool enough;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
      
    }
   
    private void Update()
    {
       
            time.text = Convert.ToString(timeval/100);
            timeval--;
        if(timeval==0)
            SceneManager.LoadScene(1);

    }
 
   
   


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.Instantiate("Player 1", new Vector3(-7, -7, 0), Quaternion.identity, 0);
        timeval = 4000;
        
    }
        
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
       
        PhotonNetwork.JoinOrCreateRoom("RoomOne", new Photon.Realtime.roomOptions { MaxPlayers = 10 }, null);
    }

   
}
