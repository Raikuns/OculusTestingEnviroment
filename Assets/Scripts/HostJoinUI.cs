using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class HostJoinUI : MonoBehaviour
{
    public NetworkManager manager;
    [SerializeField] private TMP_Text console;
    public GameObject host;
    public GameObject connect;
    public GameObject joinNew;
    public GameObject leaveServer;

    [SerializeField] private GameObject offlineCharacter;






    private void Awake() 
    {
        GameObject serg = GameObject.FindWithTag("Network");

        if(serg != null){
            manager = serg.GetComponent<NetworkManager>();
        }
    }


    public void HostGame()
    {
        if(!NetworkClient.active){
            manager.StartHost();
            Destroy(offlineCharacter);
            console.text = "Hosting a game";
            host.SetActive(false);
            connect.SetActive(true);

        }
        else{
            console.text = "Something went wrong, Try again";
        }
    }

    public void JoinHostedGame()
    {
        if(NetworkClient.active)
        {
            manager.networkAddress = "localhost";
            manager.StartClient();
            console.text = "Joining game";
            connect.SetActive(false);
            Destroy(offlineCharacter);
        }
        else{
            console.text = "Could not find the host server";
            connect.SetActive(false);
            host.SetActive(true);
        }
    }


    public void StopButtons()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            manager.StopHost();
            console.text = "Stopped osting and left the server";
        }
        else if (NetworkClient.isConnected){
            manager.StopClient();
            console.text = "Left the server";
        }
        else if (NetworkServer.active){
            manager.StopServer();
            console.text = "Server stopped";
        }
    }
}
