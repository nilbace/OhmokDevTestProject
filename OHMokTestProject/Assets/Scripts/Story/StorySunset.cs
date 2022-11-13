using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StorySunset : MonoBehaviour
{
    public TMP_Text tmp;
    int count;
    string s = "노을이 지고있다";

    // Start is called before the first frame update
    void Start()
    {
        tmp.text = "";
        count = 0;
    }
    
    public void OnNextButtonClicked()
    {
        if (count == 0) 
        {
            tmp.text = s;
            count++;
        }
        else
        {
            Manager.Instance.NightscapeActive();
        }
    }
}