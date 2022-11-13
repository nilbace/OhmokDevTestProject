using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryNight : MonoBehaviour
{
    public TMP_Text tmp;
    int count;
    string[] s = new string[] { "���� ���̴�", "�������� ���ִ�" };

    // Start is called before the first frame update
    void Start()
    {
        tmp.text = "";
        count = 0;
    }

    public void OnNextButtonClicked()
    {
        if (count < 2) 
        {
            tmp.text = s[count];
            count++;
        }
        else
        {
            Manager.Instance.SunsetActive();
        }
    }
}
