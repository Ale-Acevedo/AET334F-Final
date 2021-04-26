using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSlider : MonoBehaviour
{
    public void UpdateAudioSlider()
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().UpdateSound();
    }
}
