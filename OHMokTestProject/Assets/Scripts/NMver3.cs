using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NMver3 : MonoBehaviourPunCallbacks
{
    public GameObject StartPannel;
    public TextMeshProUGUI status;
    public TMP_InputField nameField;
    public Button connectBtn;
    public PhotonView PV;
    bool cointossed = false;
    public bool isMasterTurn = true;
    public TextMeshProUGUI tmpText;
    void Awake()
    {
        Screen.SetResolution(960, 540, false);
        PhotonNetwork.ConnectUsingSettings();
        StartPannel.SetActive(true);
    }

    private void Update() {
        status.text = PhotonNetwork.NetworkClientState.ToString();
        tmpText.text = isMasterTurn.ToString();

        if (PhotonNetwork.InRoom&&PhotonNetwork.CurrentRoom.PlayerCount==2&&cointossed == false
            &&PhotonNetwork.IsMasterClient)
        {
            print("코인 토스");
            cointossed = true;
            StartCoroutine(Cointoss());
        }
    }


    public void connect() 
    {
        RoomOptions roomOption = new RoomOptions();
        roomOption.MaxPlayers = 2;
        PhotonNetwork.NickName = nameField.text;
        PhotonNetwork.JoinOrCreateRoom("Room", roomOption, null);
    }

    public override void OnJoinedRoom()
    {
        StartPannel.SetActive(false); 
        PhotonNetwork.Instantiate("TestPlayer", new Vector3(0, 0, 0), Quaternion.identity);

        
    }


    IEnumerator Cointoss()
    {
        yield return new WaitForSeconds(0.2f);
        int tmp = Random.Range(0,2); //0이면 마스터 먼저 1이면 마스터 늦게
        print(tmp);
        if(tmp == 1)
        PV.RPC("setCoinResult", RpcTarget.AllBuffered, false);
    }

    [PunRPC]
    void setCoinResult(bool val)
    {
        isMasterTurn = val;
    }    
    public void changeBTN()
    {
        PV.RPC("changeTurn", RpcTarget.All);
    }
    [PunRPC]
    public void changeTurn()
    {
        print("다음 턴");
        isMasterTurn = !isMasterTurn;
    }
}