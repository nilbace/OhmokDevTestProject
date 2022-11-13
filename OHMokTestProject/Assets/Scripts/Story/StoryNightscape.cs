using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;  // �� ��ȯ ���� �߰��ؾ� ��

public class StoryNightscape : MonoBehaviour
{
    public TMP_Text tmp;
    int count;
    string s = "�߰��� ������";

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
            SceneManager.LoadScene("Resolution");  // �� ��ȯ
            Manager.data.isFirst = false;
            SaveGameDataToJson();
        }
    }
    void SaveGameDataToJson()
    {
        string jsonData = JsonUtility.ToJson(Manager.data, true);
        string path = Path.Combine(Application.streamingAssetsPath, "GameData.json");
        File.WriteAllText(path, jsonData);
    }
}
