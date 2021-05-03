using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//OBSOLETE
//USE JAY'S CONTOLLER
//using gamesplusjames tutorial as foundation: youtube.com/watch?v=mbzXIOKZurA
//Written by Ale
public class PlayerController : MonoBehaviour
{
    //all these values made public for easy fine-tuning in editor
    public float moveSpeed = 5f;
    public Transform movePoint;
    public float moveFluidity = 0.05f; //how close the player needs to be to the movePoint in order to accept another input
    public LayerMask collisionLayer;
    public float horizontalTolerance = 0.2f;
    public float verticalTolerance = 0.5f; //how close player needs to be to a tile before detecting collision

    void Start()
    {
        movePoint.parent = null;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= moveFluidity)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), horizontalTolerance, collisionLayer))            
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), verticalTolerance, collisionLayer))
                //if (!Physics2D.OverlapBox(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), new Vector2(verticalTolerance, verticalTolerance), 0f, collisionLayer))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }  
        }
    }

    public bool Move(Vector2 direction)//Avoid ability to move diagonally
    {
        if (Mathf.Abs(direction.x) < 0.5)//Will always set one of the coordinates to 0
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }

        direction.Normalize(); // Makes either x or y = 1;

        if (Blocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
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
}
