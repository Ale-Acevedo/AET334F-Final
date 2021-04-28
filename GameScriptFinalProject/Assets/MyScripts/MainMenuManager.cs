using UnityEngine;

// Written by Presley
/* Class to begin game menu with saved audio preferences */
public class MainMenuManager : MonoBehaviour
{
    public AudioSource musicAudio;
    public AudioSource sfxAudio;

    // Start is called before the first frame update
    void Start()
    {
        musicAudio.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        sfxAudio.volume = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
    }
}
