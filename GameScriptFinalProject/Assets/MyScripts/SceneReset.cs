using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Ale
public class SceneReset : MonoBehaviour
{
    private string currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(currentScene);
    }
}
