using UnityEngine;
using UnityEngine.SceneManagement;

// Written by Presley
// Class to handle game scene changes and order 
public class SceneHandler : MonoBehaviour
{  
    // Loads new scene based on object that called it
    public void SceneByObjectName()
    {
        SceneManager.LoadScene(this.name);
    }

    // Quits game
    public void Quit()
    {
        Application.Quit();
    }
}
