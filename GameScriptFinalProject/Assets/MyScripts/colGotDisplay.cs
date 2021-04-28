using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Written by Ale

public class colGotDisplay : MonoBehaviour
{
    [SerializeField] GameObject colManager; //serialized to check for proper functionality in editor
    private Text text;

    void Start()
    {
        colManager = GameObject.Find("ColManager"); //locate manager
        text = GetComponent<Text>(); //get text component
    }

    void Update()
    {
        text.text = colManager.GetComponent<CollectableManager>().colGot.ToString(); //get colGot int from manager instance, convert to string, update text
    }
}