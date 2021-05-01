using UnityEngine;
using UnityEngine.UI;

// Written by Presley
/* Class to update volume number display */
public class VolumeNumber : MonoBehaviour
{
    void Start()
    {
        // Show saved volume numbers
        if(gameObject.name.Equals("MusicNum"))
        {
            UpdateNumber(PlayerPrefs.GetFloat("MusicVolume"));
        }
        else
        {
            UpdateNumber(PlayerPrefs.GetFloat("SFXVolume"));
        }  
    }

    // Convert volume float to text display
    public void UpdateNumber(float volume)
    {
        gameObject.GetComponent<Text>().text = "" + ((int)(volume * 100));
    }
}
