using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem fireEffect;
    void OnCollisionEnter(Collision other) {
        
        Boom();
        Restart();
    }

    void Boom()
    {
        
        fireEffect.Play();
        GetComponent<AudioSource>().Play();
    }

    void Restart()
    {
        GetComponent<PlayerControls>().enabled = false;
        Invoke("StartAgain",1);
    }

    void StartAgain()
    {
        SceneManager.LoadScene(0);
    }
}
