using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit to Ale, code from their Challenge 3
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance; //specifying this particular instant of the manager
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
}
