using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    //Returns the player to the main menu. 
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Returns the player to the first level.
    public void Restart()
    {
        SceneManager.LoadScene("Puzzle 1");
    }
}
