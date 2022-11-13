using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryForest : MonoBehaviour
{
    public TMP_Text tmp;
    int count;
    string s = "멋진 숲이 있다";

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

script는 canvas에 할당함
TextMeshPro - using TMPro를 해야 함
버튼 - On Click() 에서 + 버튼 누르고 hierarchy에서 Canvas를 할당해준 뒤 버튼 클릭시 수행할 함수를 넣어줌
(굳이 버튼으로 하지 않고 update 함수에서 처리해도 될듯?)


 */