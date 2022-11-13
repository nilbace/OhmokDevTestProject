using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;  // 씬 전환 위해 추가해야 함

public class StoryNightscape : MonoBehaviour
{
    public TMP_Text tmp;
    int count;
    string s = "야경이 멋지다";

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
            SceneManager.LoadScene("Resolution");  // 씬 전환
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
