using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Kasey.

public class WinLoseScreen : MonoBehaviour
{
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
