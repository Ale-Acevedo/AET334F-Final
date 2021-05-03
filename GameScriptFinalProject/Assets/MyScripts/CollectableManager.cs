using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Ale
public class CollectableManager : MonoBehaviour
{
    public int colGot = 0;
    public static CollectableManager Instance; //specifying this particular instant of the manager

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Puzzle 1" || SceneManager.GetActiveScene().name == "LoseScreen")
        {
            colGot = 0;
        }
    }

    private void Awake()
    {
        this.transform.parent = null;

        if (Instance == null) //checking for other copies of the manager
        {
            DontDestroyOnLoad(gameObject);
            Instance = this; //on first load, declare this particular instance of the manager as the original
            Debug.Log("DontDestroyed success");
        }
        else if (Instance != this)
        {
            Destroy(gameObject); //all subsequent copies of this manager will be deleted on load
        }
    }

    public void colGet()
    {
        colGot += 1; //+1 to collectables gotten, function runs on collision in player controller
        Debug.Log(colGot);
    }
}
