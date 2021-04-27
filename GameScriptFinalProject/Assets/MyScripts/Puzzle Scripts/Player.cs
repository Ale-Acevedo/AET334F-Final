using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool isInvincible = false;
    public float health = 100f;
    public float drainRate = 0.01f;
    [SerializeField]
    private float iFrameDuration;
    public float colCheck = 1f; //Raycast distance
    public GameObject colManager;
    private int walkTick = 0;

    public bool Move(Vector2 direction)//Avoid ability to move diagonally

    {

        if (Blocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);

            GameObject.Find("SFXManager").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("SFXManager").GetComponent<SFXManager>().footsteps[walkTick]); //access SFXManager footstep array
            walkTick += 1;
            if(walkTick == 4) //cycle through array
            {
                walkTick = 0;
            }

            return true;
        }




    }

    bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
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

    private IEnumerator IFrames()
    {
        isInvincible = true;
        Debug.Log("IFrames on");

        yield return new WaitForSeconds(iFrameDuration); //prevent health decay for specified time

        isInvincible = false;
        Debug.Log("IFrames off");
    }

    private void FixedUpdate()
    {
        health -= 1f * drainRate;
    }

    public void LoseHealth(int amount)
    {
        if (isInvincible) return; //return immediately if invincible, negating damage

        health -= amount;

        GameObject.Find("SFXManager").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("SFXManager").GetComponent<SFXManager>().sounds[3]);

        if (health <= 0) //trigger death event
        {
            health = 0;
            SceneManager.LoadScene("LoseScreen");
            return;
        }

        StartCoroutine(IFrames());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (!isInvincible)
            {
                LoseHealth(10);
            }
        }

        if (other.gameObject.tag == "Collectable")
        {
            colManager.GetComponent<CollectableManager>().colGet();
            GameObject.Find("SFXManager").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("SFXManager").GetComponent<SFXManager>().sounds[0]);
            Destroy(other.gameObject);
            
        }
    }
}
