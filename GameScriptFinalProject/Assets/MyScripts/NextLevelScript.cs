using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    //Written by Kasey. 

    public bool puzzleSolved;

    void Start()
    {

    }

    void Update()
    {

    }

    //Detects if the player has entered the goal tile.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")      //Later add "if win condition is true"
        {
            StartCoroutine(NextLevel());
            Debug.Log("player detected");
        }
    }

    //Transitions to the next scene. 

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.2f);      //Waits 0.2 seconds to allow the player to fully move onto the tile.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
