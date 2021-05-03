using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Written by Pres and Ale
// Class to handle player healthbar 
// Referenced Wayra Codes tutorial: https://www.youtube.com/watch?v=NE5cAlCRgzo
public class PlayerHealthbar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 100.0f;
    Player player; 

    void Start()
    {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<Player>(); //added by Ale
    }

    void Update()
    {
        currentHealth = player.health; //edited by Ale
        healthBar.fillAmount = currentHealth / maxHealth; //edited by Ale
    }
}
