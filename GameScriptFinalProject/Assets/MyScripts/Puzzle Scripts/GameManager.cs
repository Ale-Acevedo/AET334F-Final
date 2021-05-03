using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Jacob
//Note: Anything with SFX manager and fxToggle was written by Ale, so I'm not 100% sure how it works, I'll do my best to explain it though

public class GameManager : MonoBehaviour
{
    public LevelBuilder  m_LevelBuilder; //Not Applicable
    public GameObject m_NextButton; //Next Level Button that will appear after certain requirements are met
    private bool m_ReadyForInput; //Boolean 
    public Player m_Player; //Player variable
    private bool fxToggle = true; //Boolean that sets FX toggle on when true, or when level is not complete 

    public bool puzzleSolved; //Public bool to let NextLevelScript know when the player has completed the puzzle. - Kasey

    void Start()
    {
        m_NextButton.SetActive(false); //ensures that the Next Level button will not activate when the level begins 

    }
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //establishes movement
        moveInput.Normalize(); //sets movement input to exact values (1)
        if (moveInput.sqrMagnitude > .5) //If button pressed or held, to this certain magnitude or above, move an exact value in any direction
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                m_Player.Move(moveInput);
                //m_NextButton.SetActive(IsLevelComplete());
            }
        }
        else
        {
            m_ReadyForInput = true;
        }
        
        puzzleSolved = IsLevelComplete();

        if (puzzleSolved && fxToggle)
        {
            GameObject.Find("SFXManager").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("SFXManager").GetComponent<SFXManager>().sounds[4]); //if puzzle is solved, play different music/sound effectts
            fxToggle = false; //fxToggle is set to false when level is complete
        }
    }

    
    public void NextLevel()
    {
        m_NextButton.SetActive(false); //sets Next Level button to false
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
        m_NextButton.SetActive(true); //boxes are on crosses, so the level is complete; Next Level button appears (this was replaced with the yellow heart by Ale and Kasey somehow)
    }

    

}

