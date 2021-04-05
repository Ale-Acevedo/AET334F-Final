using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using gamesplusjames tutorial: youtube.com/watch?v=mbzXIOKZurA
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public float moveFluidity = 0.05f; //how close the player needs to be to the movePoint in order to accept another input
    public LayerMask collisionLayer;
    public float horizontalTolerance = 0.2f;
    public float verticalTolerance = 0.5f; //how close player needs to be to a tile before detecting collision

    // Start is called before the first frame update
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

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), verticalTolerance, collisionLayer))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }

        }

    }
}