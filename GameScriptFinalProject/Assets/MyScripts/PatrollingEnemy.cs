using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code referenced from this video: https://www.youtube.com/watch?v=8eWbSN2T8TE
//Code referenced from MJ's blog: https://meganlaurajohns.blogspot.com/2019/03/patrolling-enemy-tutorial.html
//Written by Kasey.

public class PatrollingEnemy : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int currentMoveSpot;

    public GameObject ghast;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        ghast.transform.position = Vector2.MoveTowards(ghast.transform.position, moveSpots[currentMoveSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(ghast.transform.position, moveSpots[currentMoveSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;

                currentMoveSpot++;

                if (currentMoveSpot >= moveSpots.Length)
                {
                    currentMoveSpot = 0;
                }
            } 
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}

