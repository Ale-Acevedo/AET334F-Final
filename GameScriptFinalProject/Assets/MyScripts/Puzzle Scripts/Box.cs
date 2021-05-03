using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Jacob
//The graves were boxes at one point, and I didn't want to risk changing an important variable as too many of them rely on "Box", so box = grave

public class Box : MonoBehaviour
{
    public GameObject nextButton; //States the Next Button variable 
    public bool OnCross; //True if box has been pushed on to a cross

    public bool Move(Vector2 direction) //Avoid abiliy to move diagonolally
    {
        if (BoxBlocked(transform.position, direction)) 
        {
            return false; //Box is blocked and cannot be moved
        }
        else
        {
            transform.Translate(direction); //Box not blocked so move it
            TestForOnCross();
            return true;
        }
    }

    bool BoxBlocked(Vector3 position, Vector2 direction) // Boxes blocked by other boxes and walls
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall"); //finds objects with the wall tag

        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true; //box is blocked
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box"); //finds objects with the wall tag

        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
            { 
                return true; //box is blocked
            }
        }

        return false; //do not block box
    }

    void TestForOnCross() //tests if the graves are on the crosses
    {
        GameObject[] crosses = GameObject.FindGameObjectsWithTag("Cross");
        foreach (var cross in crosses)
        {
            if (transform.position.x == cross.transform.position.x && transform.position.y == cross.transform.position.y) //if the grave position is the same as a cross position
            {   //On a cross
                GetComponent<SpriteRenderer>().color = Color.red; //turns the graves red whenever they are moved on a cross
                OnCross = true; //sets OnCross boolean to true
                GameObject.Find("SFXManager").GetComponent<AudioSource>().PlayOneShot(GameObject.Find("SFXManager").GetComponent<SFXManager>().sounds[2]); //plays audio
                return;
            }          
        }      
     }
}

