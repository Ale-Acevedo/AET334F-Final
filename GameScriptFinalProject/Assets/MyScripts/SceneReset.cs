using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Ale
public class SceneReset : MonoBehaviour
{
    private string currentScene;
    private int initialCol;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        initialCol = GameObject.Find("ColManager").GetComponent<CollectableManager>().colGot;
    }

    public void ResetScene()
    {
        GameObject.Find("ColManager").GetComponent<CollectableManager>().colGot = initialCol;
        SceneManager.LoadScene(currentScene);
    }
}
