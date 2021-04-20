using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code referenced from this video: https://www.youtube.com/watch?v=dy8hkDmygRI
//Written by Kasey.

public class EnemyController : MonoBehaviour
{
    private GameObject target;
    [SerializeField]
    private float speed;

    //Finds the player gameobject within the scene
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        FollowPlayer();
    }

    //Tracks and follows the player's location
    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
