using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code referenced from this video: https://www.youtube.com/watch?v=8eWbSN2T8TE
//Written by Kasey.

public class PatrollingEnemy : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int currentMoveSpot;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        currentMoveSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[currentMoveSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[currentMoveSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                currentMoveSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            } 
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}

