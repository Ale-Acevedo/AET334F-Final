using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Written by Pres and Ale

/* Class to handle player healthbar */
// Referenced Wayra Codes tutorial: https://www.youtube.com/watch?v=NE5cAlCRgzo
public class PlayerHealthbar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 100.0f;

    // Later script that handles player damage and health
    //NewPlayerController player; //added by Ale
    Player player; //switch back and forth between my script and Jay's

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<Player>(); //added by Ale
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.health; //edited by Ale
        healthBar.fillAmount = currentHealth / maxHealth; //edited by Ale
    }
}
