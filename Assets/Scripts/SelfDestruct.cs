using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 3;
    void Start() 
    {
        Destroy(gameObject, timeToDestroy); //after certain amount of time
                                            //our object will destroy itself.
    }
}
