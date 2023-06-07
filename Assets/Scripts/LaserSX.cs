using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSX : MonoBehaviour
{
void Update()
{
    if (Input.GetMouseButton(0)) // 0 represents the left mouse button
    {
        // Check if the fire sound is not already playing
        if (!GetComponent<AudioSource>().isPlaying)
        {
            // Play the fire sound
            GetComponent<AudioSource>().Play();
        }
    }
    else
    {
        // Stop the fire sound when the left mouse button is released
        
    }
}


}
