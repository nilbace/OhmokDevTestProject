using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cardrotate : MonoBehaviour
{
    public GameObject cardfront;
    public GameObject cardback;
    private SpriteRenderer backsp;
    private SpriteRenderer frontsp;
    private bool front=false;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            rotate();
        }
        if(Input.GetKeyDown(KeyCode.LeftControl)) {
            move();
        }
    }

    void move() {
        this.transform.DOMove(new Vector3(0,700,0),0.75f).SetEase(Ease.OutQuad);
    }
    void rotate() {
        if(front==false) {
            cardback.transform.DORotate(new Vector3(0,180,0),0.5f);
            cardfront.transform.DORotate(new Vector3(0,180,0),0.5f);
            Invoke("layerchange", 0.2f);
            front=true;}
        else {
            cardback.transform.DORotate(new Vector3(0,360,0),0.5f);
            cardfront.transform.DORotate(new Vector3(0,360,0),0.5f);
            Invoke("layerchange", 0.2f);
            front=false;}
        }
    
    void layerchange() {
        backsp=cardback.GetComponent<SpriteRenderer>();
        frontsp=cardfront.GetComponent<SpriteRenderer>();
        int tmp=backsp.sortingOrder;
        backsp.sortingOrder=frontsp.sortingOrder;
        frontsp.sortingOrder=tmp;
    }
}
