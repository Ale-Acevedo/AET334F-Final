using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Kasey
public class NextLevelScript : MonoBehaviour
{
    private GameManager gameManager;
    public Sprite colorHeart;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.puzzleSolved == true) //Checks if the player has solved the puzzle
        {
            ChangeSprite();
        }
    }

    //Detects if the player has entered the goal tile.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameManager.puzzleSolved == true) //Checks if the player has solved the puzzle
        {
            if (other.tag == "Player")      
            {
                StartCoroutine(NextLevel());
            }
        }
        else //If the player has not solved the puzzle, they won't be able to go to the next level
        {
            //Debug.Log("unsolved");
        }
    }

    //Transitions to the next scene. 
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.2f); //Waits 0.2 seconds to allow the player to fully move onto the tile.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Changes the sprite to a colored heart
    void ChangeSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = colorHeart;
    }
}
