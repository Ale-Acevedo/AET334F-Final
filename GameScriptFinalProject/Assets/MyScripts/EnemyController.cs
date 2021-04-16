using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code referenced from this video: https://www.youtube.com/watch?v=dy8hkDmygRI
//Written by Kasey.

public class EnemyController : MonoBehaviour
{
    //private Animator myAnim;
    private GameObject target;
    [SerializeField]
    private float speed;
    //private float range;

    // Start is called before the first frame update
    void Start()
    {
        //myAnim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
