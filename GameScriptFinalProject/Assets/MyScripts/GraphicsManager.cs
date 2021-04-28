using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Written by Presley

/* Class to change and save graphics settings */
// Referenced Tommy Yoder's tutorial: https://www.youtube.com/watch?v=rtpHU1kfabI
public class GraphicsManager : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private int screenInt;
    public Toggle windowedToggle;

    // Ensure windowed option preferences are considered
    void Awake()
    {
        screenInt = PlayerPrefs.GetInt("ToggleState", 1);
        if (screenInt == 1)
        {
            windowedToggle.isOn = true;
            SetWindowed(true);
        }
        else
        {
            windowedToggle.isOn = false;
            SetWindowed(false);
        }
    }

    // Add resolution options to dropdown
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int index = 0; index < resolutions.Length; index++)
        {
            // Resolution string shown in the dropdown
            string option = resolutions[index].width + " X " + resolutions[index].height;
            options.Add(option);
            if (resolutions[index].width == Screen.currentResolution.width 
                && resolutions[index].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = index;
            }
        }

        resolutionDropdown.AddOptions(options);
        // Show current resolution selected to start with
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Set game resolution based on list index 
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Set screen window based on toggle
    public void SetWindowed(bool toggled)
    {
        Screen.fullScreen = !toggled;
        // Save this preference
        if (toggled)
        {
            PlayerPrefs.SetInt("ToggleState", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ToggleState", 0);
        }   
    }
}
