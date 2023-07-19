using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.SocialPlatforms.Impl;

public class Food : MonoBehaviour
{
    AudioSource Audio;

    public BoxCollider2D GridArea;


    private void Start()
    {
        RandomizedPosition();
        Audio = GetComponent<AudioSource>();
    }


    private void RandomizedPosition() 
    {
        Bounds bounds = this.GridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
    
        this.transform.position = new Vector3(Mathf.Round(x) , Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            Audio.Play();
            RandomizedPosition();
            
        }
    }

}
