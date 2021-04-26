using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static string musicPref = "MusicPref";
    private static string sfxPref = "SFXPref";
    //private static string masterPref = "MasterPref";

    private float musicVolume;
    private float sfxVolume;
    //private float masterVolume;

    public AudioSource musicAudio;
    public AudioSource sfxAudio;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        musicVolume = PlayerPrefs.GetFloat(musicPref);
        sfxVolume = PlayerPrefs.GetFloat(sfxPref);

        musicAudio.volume = musicVolume;
        sfxAudio.volume = sfxVolume;
    }
}
