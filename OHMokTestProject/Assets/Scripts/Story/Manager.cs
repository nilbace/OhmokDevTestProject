using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

// 싱글톤 패턴
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

            // 씬 전환돼도 유지되도록
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // 매니저가 이미 있는데 하나 더 만들어지는 경우 여기로 들어옴. 파괴
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

Canvas component 설정
Canvas 
 - Render Mode -> Screen Space - Camera
 - Render Camera -> Main Camera
Canvas Scale Mode
 - UI Scale Mode -> Scale With Screen Size
 - Reference Resolution -> X 1080, Y 1920
Add Component -> Canvas Group 추가

코드 - Canvas, CanvasGroup 객체 모두 만들어야 함
CanvasGroup.alpha : 투명도
투명도를 조절하여 Canvas가 전환되는것처럼 보이게

참고한 동영상
- 디자인패턴 첫번째 - 초보자를 위한 싱글톤
- 유니티 Canvas 전환하기
- UI 비법서 - 버튼의 모든 것 | 유니티

* Json 관련 - Application.dataPath를 사용하면 빌드했을때 동작하지 않고 Asset 폴더 내에 streamingAssets 폴더를 생성 후 Application.streamingAssetsPath를 사용하면 동작함

 */