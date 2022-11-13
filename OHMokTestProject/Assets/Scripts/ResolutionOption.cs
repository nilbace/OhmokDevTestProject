using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ResolutionOption : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    List<DeviceResolution> resolutionList;
    public int resolutionNum;
    
    // Start is called before the first frame update
    void Start()
    {
        InitUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitUI()
    {
        resolutionNum = 0;
        AddResolutions();

        resolutionDropdown.options.Clear();

        foreach(DeviceResolution device in resolutionList)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = string.Format("{0} x {1} ({2}:{3}) - {4}", device.width*5, device.height*5, device.width_ratio, device.height_ratio, device.device_name);
            resolutionDropdown.options.Add(option);
            Debug.Log(option.text);
        }
        resolutionDropdown.RefreshShownValue();
    }

    void AddResolutions()
    {
        resolutionList = new List<DeviceResolution>();

        DeviceResolution device1 =new DeviceResolution();
        device1.width = 108;
        device1.height = 192;
        device1.width_ratio = 9;
        device1.height_ratio = 16;
        device1.device_name = "Full HD";

        DeviceResolution device2 = new DeviceResolution();
        device2.width = 160;
        device2.height = 256;
        device2.width_ratio = 10;
        device2.height_ratio = 16;
        device2.device_name = "Galaxy Tab S8";

        DeviceResolution device3 = new DeviceResolution();
        device3.width = 144;
        device3.height = 304;
        device3.width_ratio = 9;
        device3.height_ratio = 19;
        device3.device_name = "Galaxy S10";

        DeviceResolution device4 = new DeviceResolution();
        device4.width = 108;
        device4.height = 234;
        device4.width_ratio = 9;
        device4.height_ratio = 19.5f;
        device4.device_name = "Galaxy S22";

        DeviceResolution device5 = new DeviceResolution();
        device5.width = 108;
        device5.height = 240;
        device5.width_ratio = 9;
        device5.height_ratio = 20;
        device5.device_name = "Galaxy S21";

        resolutionList.Add(device1);
        resolutionList.Add(device2);
        resolutionList.Add(device3);
        resolutionList.Add(device4);
        resolutionList.Add(device5);
    }

    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }

    public void OnButtonClicked()
    {
        Screen.SetResolution(resolutionList[resolutionNum].width*5, resolutionList[resolutionNum].height*5, false, 60);
    }
}

struct DeviceResolution
{
    public int width;
    public int height;
    public int width_ratio;
    public float height_ratio;
    public string device_name;
}