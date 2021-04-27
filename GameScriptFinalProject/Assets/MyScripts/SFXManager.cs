using UnityEngine;

// Written by Presley

/* Class to adjust sfx audiosource */
public class SFXManager : MonoBehaviour
{
    public AudioSource sfx;

    // Credit to Ale, code from Ale's Challenge 3 assignment
    // Ensures that there is only one copy of this gameobject
    public static SFXManager Instance; 
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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        sfx.volume = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
    }
}
