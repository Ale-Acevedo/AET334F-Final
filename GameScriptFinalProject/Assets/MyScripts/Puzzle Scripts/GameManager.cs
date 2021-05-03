using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Jacob & Ale
public class GameManager : MonoBehaviour
{
    public LevelBuilder  levelBuilder; //Not Applicable
    public GameObject nextButton; //Next Level Button that will appear after certain requirements are met
    private bool ReadyForInput; //Boolean 
    public Player player; //Player variable
    private bool fxToggle = true; //Boolean to prevent fx overlap in update 
    public bool puzzleSolved; //Public bool to let NextLevelScript know when the player has completed the puzzle. - Kasey

    void Start()
    {
        nextButton.SetActive(false); //ensures that the Next Level button will not activate when the level begins 

    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //establishes movement
        moveInput.Normalize(); //sets movement input to exact values (1)

        if (moveInput.sqrMagnitude > .5) //If button pressed or held, to this certain magnitude or above, move an exact value in any direction
        {
            if (ReadyForInput)
            {
                ReadyForInput = false;
                player.Move(moveInput);
                //nextButton.SetActive(IsLevelComplete());
            }
        }
        else
        {
            ReadyForInput = true;
        }
        
        puzzleSolved = IsLevelComplete();

        if (puzzleSolved && fxToggle)
        {
            GameObject.Find("SFXManager").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("SFXManager").GetComponent<SFXManager>().sounds[4]); //plays oneshot on completion
            fxToggle = false; //fxToggle is set to false to prevent constant playing
        }
    }

    
    public void NextLevel()
    {
        nextButton.SetActive(false); //sets Next Level button to false
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Puzzle 1"); //Loads Puzzle 1 again, or "resets" the scene
    }

    bool IsLevelComplete()
    {
        Box[] boxes = FindObjectsOfType<Box>();
        foreach (var box in boxes)
        {
            if (!box.OnCross) return false; //if boxes are not on crosses, level is not complete, and Next Level button does not show
        }

        
        return true;
        nextButton.SetActive(true); //boxes are on crosses, so the level is complete; Next Level button appears (this was replaced with the yellow heart by Ale and Kasey somehow)
    }

    

}

