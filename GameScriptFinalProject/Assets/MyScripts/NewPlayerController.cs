using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//OBSOLETE, USE JAY'S CONTROLLER
//Writtem by Ale
public class NewPlayerController : MonoBehaviour
{
    private bool isMoving; //Check if player is moving already
    private Vector3 origPos, targetPos; //Position declarations for IEnumerator
    private float timeToMove = 0.2f; //"Movespeed"
    public float colCheck = 1f; //Raycast distance
    public GameObject colManager;
    public float health = 100f;
    private bool isInvincible = false;
    [SerializeField] private float iFrameDuration;
    public float drainRate = 0.01f;

    void Update()
    {
        if(colManager == null)
        {
            Debug.Log("colManager missing");
            colManager = GameObject.Find("ColManager");
        }
        int layerMask = 1 << 8; //Bit-shifting mask to Collision layer

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f && !isMoving) //Only accepts max input values when player is not moving
        {
            if (Physics2D.Raycast(transform.position, new Vector2(Input.GetAxisRaw("Horizontal"), 0f), colCheck, layerMask)) //Checks for collision 1 tile ahead
            {
                Debug.Log("bonk_H");
            }
            else
            {
                StartCoroutine(MovePlayer(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f))); //Initiate coroutine for player movement
            }
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f && !isMoving)
        {
            if (Physics2D.Raycast(transform.position, new Vector2(0f, Input.GetAxisRaw("Vertical")), colCheck, layerMask))
            {
                Debug.Log("bonk_V");
            }
            else
            {
                StartCoroutine(MovePlayer(new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f)));
            }
        }

        if (health <= 0){
            SceneManager.LoadScene("LoseScreen");
        }
    }

    private void FixedUpdate()
    {
        health -= 1f * drainRate;
    }

    //Section based on Comp-3 Interactive Tutorial: youtube.com/watch?v=AiZ4z4qKy44
    private IEnumerator MovePlayer(Vector3 direction) //Move player with input direction
    {
        isMoving = true; //Keep player from moving in-between
        float elapsedTime = 0; //Begin counting time elapsed during movement
        origPos = transform.position; //Track start and goal positions
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove)); //Smoothly interpolate between both points relative to elapsed time and "movespeed"
            elapsedTime += Time.deltaTime;
            yield return null; //Coroutine yield statement
        }

        transform.position = targetPos; //Force player in grid to correct offsets
        isMoving = false; //Allow player movement again
    }

    //based on Aleksandr Hovhannisyan's blog post: aleksandrhovhannisyan.com/blog/invulnerability-frames-in-unity/
    private IEnumerator IFrames()
    {
        isInvincible = true;
        Debug.Log("IFrames on");
        yield return new WaitForSeconds(iFrameDuration); //prevent health decay for specified time
        isInvincible = false;
        Debug.Log("IFrames off");
    }

    public void LoseHealth(int amount)
    {
        if (isInvincible) 
        {
            return; //return immediately if invincible, negating damage
        } 
        
        health -= amount;

        if (health <= 0) //trigger death event
        {
            health = 0;
            SceneManager.LoadScene("LoseScreen");
            return;
        }

        StartCoroutine(IFrames()); //if player has health remaining, run IFrames
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            if (!isInvincible) //check to make sure player is not invincible during enemy collision
            {
                LoseHealth(10);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject);
            colManager.GetComponent<CollectableManager>().colGet(); //call colGet function from manager
        }
    }
}
