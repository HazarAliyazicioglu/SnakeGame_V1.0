using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerWall : MonoBehaviour
{
    AudioSource finishAudio;


    // Start is called before the first frame update
    void Start()
    {
        finishAudio = GetComponent<AudioSource>();
        
    }


    public void OpenRestartMenu()
    {
        finishAudio.Play(); 
    }
}
