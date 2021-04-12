using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Class to handle player healthbar */
// Referenced Wayra Codes tutorial: https://www.youtube.com/watch?v=NE5cAlCRgzo
public class PlayerHealthbar : MonoBehaviour
{
    private Image healthbar;
    public float currentHealth;
    private float maxHealth = 100.0f;

    // Later script that handles player damage and health
    // PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // currentHealth = player.health;
        healthbar.fillAmount = currentHealth / maxHealth;
    }
}
