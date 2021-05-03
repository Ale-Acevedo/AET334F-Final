using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Jacob and Ale

public class Player : MonoBehaviour
{
    private bool isInvincible = false; //boolean that sets the player to not invincible when false, invincible when true
    public float health = 100f; //sets the player health
    public float drainRate = 0.01f; //sets the player's health's drain rate
    [SerializeField] private float iFrameDuration; //Sets the duration of invincibility frames
    public float colCheck = 1f; //Raycast distance
    public GameObject colManager; //Collectable Manager
    private int walkTick = 0; //walkTick integer for crawling through walk SFX array

    private void Start()
    {
        colManager = GameObject.Find("ColManager"); //Establishes collectable manager
    }

    public bool Move(Vector2 direction)//Avoid ability to move diagonally
    {
        if (Blocked(transform.position, direction))
        {
            return false; //If the player tries to move in the direction of a wall, they will be blocked and cannot move that direction
        }
        else
        {
            transform.Translate(direction); //Move a certain direction
            GameObject.Find("SFXManager").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("SFXManager").GetComponent<SFXManager>().footsteps[walkTick]); //Access SFXManager footstep array
            walkTick += 1;
            if(walkTick == 4) //Cycle through array
            {
                walkTick = 0;
            }

            return true;
        }
    }

    bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall"); //Finds objects tagged with "Wall"

        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box"); //If objects are tagged with "Box", and if player moves the box in an area not tagged with "Wall" or "Box", then move the box in that direction
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
            {
                Box bx = box.GetComponent<Box>();

                if (bx && bx.Move(direction))
                {
                    GameObject.Find("SFXManager").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("SFXManager").GetComponent<SFXManager>().sounds[1]);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        return false;
    }

    private IEnumerator IFrames() //Invincibility Frames
    {
        isInvincible = true; //Player will not take repeated damage from remaining in enemy trigger while active
        Debug.Log("IFrames on");
        yield return new WaitForSeconds(iFrameDuration); //Prevents health decay for specified time
        isInvincible = false;
        Debug.Log("IFrames off");
    }

    private void FixedUpdate()
    {
        health -= 1f * drainRate; //Player slowly loses health overtime
    }

    public void LoseHealth(int amount)
    {
        if (isInvincible) 
        { 
            return; //return immediately if invincible, negating damage
        } 

        health -= amount;
        GameObject.Find("SFXManager").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("SFXManager").GetComponent<SFXManager>().sounds[3]);

        if (health <= 0) //Trigger death event
        {
            health = 0;
            SceneManager.LoadScene("LoseScreen"); //Loads the gameover screen
            return;
        }

        StartCoroutine(IFrames());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy") //If the player touches an NPC tagged as "enemy":
        {
            if (!isInvincible) //If the player is NOT invincible from Iframes
            {
                LoseHealth(10); //Player loses health
            }
        }

        if (other.gameObject.tag == "Collectable") //if the player collides with an object with the collectable tag:
        {
            colManager.GetComponent<CollectableManager>().colGet(); //Fetch the collectable manager
            GameObject.Find("SFXManager").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("SFXManager").GetComponent<SFXManager>().sounds[0]); //Play sound effect
            Destroy(other.gameObject); //Destroy the game object
        }
    }
}
