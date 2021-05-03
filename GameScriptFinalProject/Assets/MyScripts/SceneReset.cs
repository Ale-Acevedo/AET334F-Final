using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Ale
public class SceneReset : MonoBehaviour
{
    private string currentScene;
    private int initialCol; //get collectable count at start of scene for resetting value

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        initialCol = GameObject.Find("ColManager").GetComponent<CollectableManager>().colGot;
        if (SceneManager.GetActiveScene().name == "Puzzle 1") //check if player died
        {
            GameObject.Find("ColManager").GetComponent<CollectableManager>().colGot = 0;
        }
    }

    public void ResetScene()
    {
        GameObject.Find("ColManager").GetComponent<CollectableManager>().colGot = initialCol;
        SceneManager.LoadScene(currentScene);
    }
}
