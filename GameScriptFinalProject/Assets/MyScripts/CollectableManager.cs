using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public GameObject[] collectables;

    //private int colTrack;
    public int colGot = 0;

    public static CollectableManager Instance; //specifying this particular instant of the manager
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

    private void Start()
    {
        collectables = (GameObject.FindGameObjectsWithTag("Collectable"));
    }

    public void colGet()
    {
        colGot += 1;
        Debug.Log(colGot);
    }
}
