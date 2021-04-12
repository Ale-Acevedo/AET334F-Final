using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Class to handle game scene changes and order */
public class SceneHandler : MonoBehaviour
{
    
    // Loads new scene based on object that called it
    public void SceneByObjectName()
    {
        SceneManager.LoadScene(this.name);
    }
}
