using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
using TMPro;
using DG.Tweening;

public class setting : MonoBehaviour
{
    public AudioMixer audiomixer;
    public playerdata player;
    public Slider masterslid;
    public Slider bgmslid;
    public Slider sfxslid;
    public TMP_InputField nameinput;
    public TMP_Text welcometext;
    public Image victoryimg;
    // Start is called before the first frame update
    void Start()
    {
        loadplayer();
        masterslid.value=player.mastervol;
        sfxslid.value=player.sfxvol;
        bgmslid.value=player.bgmvol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("to json data")]
    void saveplayer() {
        string jsondata = JsonUtility.ToJson(player,true);
        string path = Path.Combine(Application.dataPath,"playerData.json");
        File.WriteAllText(path, jsondata);
    }

    [ContextMenu("from json data")]
    void loadplayer() {
        string path = Path.Combine(Application.dataPath,"playerData.json");
        string jsondata = File.ReadAllText(path);
        player = JsonUtility.FromJson<playerdata>(jsondata);
    }

    public void setmaster(float sliderval) {
        audiomixer.SetFloat("masterpar", Mathf.Log10(sliderval)*20);
        player.mastervol=sliderval;
        saveplayer();
    }

    public void setbgm(float sliderval) {
        audiomixer.SetFloat("bgmpar", Mathf.Log10(sliderval)*20);
        player.bgmvol=sliderval;
        saveplayer();
    }
    public void setsfx(float sliderval) {
        audiomixer.SetFloat("sfxpar", Mathf.Log10(sliderval)*20);
        player.sfxvol=sliderval;
        saveplayer();
    }

    public void namechange() {
        player.name = nameinput.text;
        saveplayer();
    }

    public void changename() {
        loadplayer();
        welcometext.text="Welcome!" + "\n" + player.name;
    }

    public void victory() {
        victoryimg.transform.DOScale(new Vector3(10,10,10),1).SetEase(Ease.OutCubic);
    }
}

[System.Serializable]
public class playerdata {
    public string name;
    public float mastervol;
    public float sfxvol;
    public float bgmvol;
}
