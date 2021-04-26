using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/* Class to change and save graphics settings */
// Referenced Tommy Yoder's tutorial: https://www.youtube.com/watch?v=rtpHU1kfabI
public class GraphicsManager : MonoBehaviour
{

    public Dropdown resolutionDropdown;
    private int screenInt;
    Resolution[] resolutions;


    public Toggle windowedToggle;
    private bool isWindowed = true;

    const string resName = "resolutionoption";

    void Awake()
    {
        screenInt = PlayerPrefs.GetInt("togglestate");

        if (screenInt == 1)
        {
            isWindowed = true;
            windowedToggle.isOn = true;
        }
        else
        {
            windowedToggle.isOn = false;
        }

        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resName, resolutionDropdown.value);
            PlayerPrefs.Save();
        }));
    }

    // Start is called before the first frame update
    void Start()
    {

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int index = 0; index < resolutions.Length; index++)
        {
            string option = resolutions[index].width + " X " + resolutions[index].height;
            options.Add(option);

            if (resolutions[index].width == Screen.currentResolution.width
                && resolutions[index].height == Screen.currentResolution.height
                && resolutions[index].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = index;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetWindowed(bool toggled)
    {
        isWindowed = toggled;
        Screen.fullScreen = !isWindowed;

        if (isWindowed == false)
        {
            PlayerPrefs.SetInt("togglestate", 0);
        }
        else
        {
            isWindowed = true;
            PlayerPrefs.SetInt("togglestate", 1);
        }
    }

}
