using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelBuilder  m_LevelBuilder;
    public GameObject m_NextButton;
    private bool m_ReadyForInput;
    public Player m_Player;

    public bool puzzleSolved; //Public bool to let NextLevelScript know when the player has completed the puzzle. - Kasey

    void Start()
    {
        m_NextButton.SetActive(false);

    }
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if (moveInput.sqrMagnitude > .5) //Button pressed or held
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                m_Player.Move(moveInput);
                m_NextButton.SetActive(IsLevelComplete());
            }
        }
        else
        {
            m_ReadyForInput = true;
        }
        
        puzzleSolved = IsLevelComplete();

    }

    
    public void NextLevel()
    {
        m_NextButton.SetActive(false);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Puzzle 1");
    }

    bool IsLevelComplete()
    {
        Box[] boxes = FindObjectsOfType<Box>();
        foreach (var box in boxes)
        {
            if (!box.m_OnCross) return false;
        }

        
        return true;
        m_NextButton.SetActive(true);
    }

    

}

