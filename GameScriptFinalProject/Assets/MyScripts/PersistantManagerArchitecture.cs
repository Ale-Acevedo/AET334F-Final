using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//From Ale's Challenge 3 assignment
//When using this architecture for your manager, make sure to replace the 'PersistantManagerArchitecture' instances with the relevant class
//Just copy and paste this code at the beginning of your script, and fill in the logic from there
//Keep the comments for documentation
public class PersistantManagerArchitecture : MonoBehaviour
{
    public static PersistantManagerArchitecture Instance; //specifying this particular instant of the manager
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
