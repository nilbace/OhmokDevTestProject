using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class TestPlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public SpriteRenderer SR;
    public PhotonView PV;
    public TextMeshProUGUI NickNameText;
    public bool isMyturn = false;
    public TextMeshProUGUI MyturnText;
    public Button turnchangeBtn;
    public GameObject NMver3;

    public void setTurn(bool bol)
    {
        this.isMyturn = bol;
    }
    public void reverseTurn()
    {
        this.isMyturn = !this.isMyturn;
    }
     void Awake()
    {
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        NickNameText.color = PV.IsMine ? Color.green : Color.red;
        StartCoroutine(SetPlace());
        turnchangeBtn = GameObject.Find("changTurn").GetComponent<Button>();
        NMver3 = GameObject.Find("NMver3");
    }

    IEnumerator SetPlace()
    {
        yield return new WaitForSeconds(0.5f);
        if(PV.IsMine) 
        {
            transform.Translate(-6f,-2f,0);
            
        }
        else transform.Translate(6f,2f,0);
        
    }

    void Update()
    {
        if(PhotonNetwork.IsMasterClient && PV.IsMine)
        {
            isMyturn = NMver3.GetComponent<NMver3>().isMasterTurn ? true : false;
        }

        if(!PhotonNetwork.IsMasterClient && PV.IsMine)
        {
            isMyturn = !NMver3.GetComponent<NMver3>().isMasterTurn ? true : false;
        }
        

        

        if (PV.IsMine)
        {
            MyturnText.text = isMyturn.ToString();
            turnchangeBtn.interactable = isMyturn;
            
        }
        
    }



    [PunRPC]
    void JumpRPC()
    {
        
    }

    public void Hit()
    {
        
    }

    [PunRPC]
    void DestroyRPC() => Destroy(gameObject);


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting && PV.IsMine)
        {
        }
        else
        {
            
        }
    }
}