using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

// �̱��� ����
public class Manager : MonoBehaviour
{
    private static Manager instance = null;
    public static GameData data;

    public Canvas forest;
    public Canvas night;
    public Canvas sunset;
    public Canvas nightscape;

    public CanvasGroup forest_group;
    public CanvasGroup night_group;
    public CanvasGroup sunset_group;
    public CanvasGroup nightscape_group;


    public static Manager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // �� ��ȯ�ŵ� �����ǵ���
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // �Ŵ����� �̹� �ִµ� �ϳ� �� ��������� ��� ����� ����. �ı�
            Destroy(this.gameObject);
        }

        LoadGameDataFromJson();
        Debug.Log(data.isFirst);
        if (data.isFirst)
        {
            forest.enabled = true;
            night.enabled = false;
            sunset.enabled = false;
            nightscape.enabled = false;

            forest_group.alpha = 1;
            night_group.alpha = 0;
            sunset_group.alpha = 0;
            nightscape_group.alpha = 0;

            forest_group.interactable = true;
            night_group.interactable = false;
            sunset_group.interactable = false;
            nightscape_group.interactable = false;
        }
        else
        {
            SceneManager.LoadScene("Resolution");
        }
    }

    public void ForestActive()
    {
        forest.enabled = true;
        night.enabled = false;
        sunset.enabled=false;
        nightscape.enabled=false;

        forest_group.alpha = 1;
        forest_group.interactable = true;
    }

    public void NightActive()
    {
        forest.enabled = false;
        night.enabled = true;
        sunset.enabled = false;
        nightscape.enabled = false;

        night_group.alpha = 1;
        night_group.interactable = true;
    }

    public void SunsetActive()
    {
        forest.enabled = false;
        night.enabled = false;
        sunset.enabled = true;
        nightscape.enabled = false;

        sunset_group.alpha = 1;
        sunset_group.interactable = true;
    }

    public void NightscapeActive()
    {
        forest.enabled = false;
        night.enabled = false;
        sunset.enabled = false;
        nightscape.enabled = true;

        nightscape_group.alpha = 1;
        nightscape_group.interactable = true;
    }

    
    void LoadGameDataFromJson()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "GameData.json");
        string jsonData = File.ReadAllText(path);
        data = JsonUtility.FromJson<GameData>(jsonData);
    }
}

[System.Serializable]
public class GameData
{
    public bool isFirst;
};












/*

Canvas component ����
Canvas 
 - Render Mode -> Screen Space - Camera
 - Render Camera -> Main Camera
Canvas Scale Mode
 - UI Scale Mode -> Scale With Screen Size
 - Reference Resolution -> X 1080, Y 1920
Add Component -> Canvas Group �߰�

�ڵ� - Canvas, CanvasGroup ��ü ��� ������ ��
CanvasGroup.alpha : ����
������ �����Ͽ� Canvas�� ��ȯ�Ǵ°�ó�� ���̰�

������ ������
- ���������� ù��° - �ʺ��ڸ� ���� �̱���
- ����Ƽ Canvas ��ȯ�ϱ�
- UI ����� - ��ư�� ��� �� | ����Ƽ

* Json ���� - Application.dataPath�� ����ϸ� ���������� �������� �ʰ� Asset ���� ���� streamingAssets ������ ���� �� Application.streamingAssetsPath�� ����ϸ� ������

 */