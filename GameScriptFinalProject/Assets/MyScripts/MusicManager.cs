using UnityEngine;

// Written by Presley
// Class to adjust music audiosource 
public class MusicManager : MonoBehaviour
{
    public AudioSource music;

    // Credit to Ale, code from Ale's Challenge 3 assignment
    // Ensures that there is only one copy of this gameobject
    public static MusicManager Instance; 
    private void Awake()
    {
        if (Instance == null) 
        {
            DontDestroyOnLoad(gameObject);
            Instance = this; 
        }
        else if (Instance != this)
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        Time.timeScale = 1f;
        music.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
    }
}
