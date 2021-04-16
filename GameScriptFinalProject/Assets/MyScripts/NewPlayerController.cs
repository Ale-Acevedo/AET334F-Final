using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{

    private bool isMoving; //Check if player is moving already
    private Vector3 origPos, targetPos; //Position declarations for IEnumerator
    private float timeToMove = 0.2f; //"Movespeed"
    public float colCheck = 1f; //Raycast distance

    void Update()
    {
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
}
