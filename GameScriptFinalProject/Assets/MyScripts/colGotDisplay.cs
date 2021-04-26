using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colGotDisplay : MonoBehaviour
{
    [SerializeField] GameObject colManager; //serialized to check for proper functionality in editor
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        colManager = GameObject.Find("ColManager"); //locate manager
        text = GetComponent<Text>(); //get text component
    }

    // Update is called once per frame
    void Update()
    {
        text.text = colManager.GetComponent<CollectableManager>().colGot.ToString(); //get colGot int from manager instance, convert to string, update text
    }
}
