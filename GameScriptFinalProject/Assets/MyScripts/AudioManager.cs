using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static string firstPlay = "FirstPlay";
    private static string firstSettings = "FirstSettings";

    private static string musicPref = "MusicPref";
    private static string sfxPref = "SFXPref";
    private static string masterPref = "MasterPref";

    private int firstPlayInt;
    private int firstSettingsInt;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private float musicVolume;
    private float sfxVolume;
    private float masterVolume;

    public AudioSource musicAudio;
    public AudioSource sfxAudio;

    public static AudioManager Instance; //specifying this particular instant of the manager
    private void Awake()
    {
        if (Instance == null) //checking for other copies of the manager
        {
            DontDestroyOnLoad(gameObject);
            Instance = this; //on first load, declare this particular instance of the manager as the original
        }
        else if (Instance != this)
        {
            Destroy(gameObject); //all subsequent copies of this manager will be deleted on load
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(firstPlay);

        // Set default sound settings on first play
        if (firstPlayInt == 0)
        {
            musicVolume = 1.0f;
            sfxVolume = 1.0f;
            masterVolume = 1.0f;

            PlayerPrefs.SetFloat(musicPref, musicVolume);
            PlayerPrefs.SetFloat(sfxPref, sfxVolume);
            PlayerPrefs.SetFloat(masterPref, masterVolume);
            PlayerPrefs.SetInt(firstPlay, -1);


        }
        // Get saved values from last playthrough
        else
        {
            musicVolume = PlayerPrefs.GetFloat(musicPref);
            sfxVolume = PlayerPrefs.GetFloat(sfxPref);
            masterVolume = PlayerPrefs.GetFloat(masterPref);

        }
    }


    private void Update()
    {
        if (firstSettingsInt == 0 && SceneManager.GetActiveScene().name.Equals("Settings"))
        {
            FindSliders();
            firstSettingsInt = PlayerPrefs.GetInt(firstSettings);
            PlayerPrefs.SetInt(firstSettings, -1);

        }
        else if (SceneManager.GetActiveScene().name.Equals("Settings"))
        {
            AdjustSettingsDisplay();
        }
    }

    
    public void FindSliders()
    {
        musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        sfxSlider = GameObject.Find("SFXSlider").GetComponent<Slider>();
        masterSlider = GameObject.Find("MasterSlider").GetComponent<Slider>();
    }

    public void AdjustSettingsDisplay()
    {
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
        masterSlider.value = masterVolume;
        SaveSoundSettings();
    }

    // Save volumes according to slider positions
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(musicPref, musicSlider.value);
        PlayerPrefs.SetFloat(sfxPref, sfxSlider.value);
        PlayerPrefs.SetFloat(masterPref, masterSlider.value);
    }

    public void UpdateSound()
    {
        musicAudio.volume = musicSlider.value;
        sfxAudio.volume = sfxSlider.value;
    }

}
