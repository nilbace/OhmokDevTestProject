using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryForest : MonoBehaviour
{
    public TMP_Text tmp;
    int count;
    string s = "���� ���� �ִ�";

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
            Manager.Instance.NightActive();
        }
    }
    
}

/*

script�� canvas�� �Ҵ���
TextMeshPro - using TMPro�� �ؾ� ��
��ư - On Click() ���� + ��ư ������ hierarchy���� Canvas�� �Ҵ����� �� ��ư Ŭ���� ������ �Լ��� �־���
(���� ��ư���� ���� �ʰ� update �Լ����� ó���ص� �ɵ�?)


 */