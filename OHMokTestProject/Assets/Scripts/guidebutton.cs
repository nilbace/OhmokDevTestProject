using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guidebutton : MonoBehaviour
{
    // Start is called before the first frame update
    int guideflag=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void guideon() {
        GameObject scroll = GameObject.Find("guide");
        if(guideflag==0) {
            scroll.transform.GetChild(1).gameObject.SetActive(true);
        guideflag=1;}
        else {
            scroll.transform.GetChild(1).gameObject.SetActive(false);
            guideflag=0;
        }
    }
}
