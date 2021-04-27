using UnityEngine;
using UnityEngine.UI;

// Written by Presley

/* Class to adjust audiosources based on settings volume sliders */
// Referenced ChrisVernerStudio tutorial: https://www.youtube.com/watch?v=s-Y4e0mNuwI
public class VolumeController : MonoBehaviour
{
    private AudioSource musicAudio;
    private AudioSource sfxAudio;

    public Slider musicVolume;
    public Slider sfxVolume;

    void Start()
    {
        musicAudio = GameObject.Find("MusicManager").GetComponent<AudioSource>();
        sfxAudio = GameObject.Find("SFXManager").GetComponent<AudioSource>();

        // Start with saved volume preferences, default is full volume (1)
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        sfxVolume.value = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
    }

    // Adjust audiosource volume from slider positions
    void Update()
    {
        musicAudio.volume = musicVolume.value;
        sfxAudio.volume = sfxVolume.value;
    }

    // Save current volume preferences
    public void VolumePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicAudio.volume);
        PlayerPrefs.SetFloat("SFXVolume", sfxAudio.volume);
    }

}
