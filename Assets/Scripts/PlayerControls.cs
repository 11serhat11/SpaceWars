using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Speed of Ship")]
    [SerializeField] float xSpeed = 10;
    [SerializeField] float ySpeed = 10;
    [Header("Screen Range")]
    [SerializeField] float xRange = 10;
    [SerializeField] float yRange = 3;
    [Header("Rotation")]
    [SerializeField] float pitchPositionFactor = -15;
    [SerializeField] float pitchControlFactor = -10;
    [SerializeField] float yawPositionFactor = -10;
    [SerializeField] float rollControlFactor = -10;
    [SerializeField] GameObject[] lasers;
    

    float xThrow, yThrow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Rotation();
        Fire();
    }

    void Mover()
    {
        xThrow = Input.GetAxis("Horizontal"); //Keyboard values
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * xSpeed;
        float yOffset = yThrow * Time.deltaTime * ySpeed;

        float newX = transform.localPosition.x + xOffset; //Current position + speed
        float newY = transform.localPosition.y + yOffset;

        float rawX = Mathf.Clamp(newX, -xRange - 2, xRange);
        float rawY = Mathf.Clamp(newY, -yRange, yRange + 1.5f);
        transform.localPosition = new Vector3(rawX, rawY, transform.localPosition.z);
    }

    void Rotation()
    {
        //pitch --> while moving up and down  (position + control)
        //yaw   --> changing ship's nose position (just position)
        //roll  --> while moving right and left (just control)
        
        float pitchPosition = transform.localPosition.y * pitchPositionFactor;
        float pitchControl = yThrow * pitchControlFactor;

        float yawPosition = transform.localPosition.x * yawPositionFactor;
        float rollControl = xThrow * rollControlFactor;
        
        float pitch =  pitchPosition + pitchControl ;
        float yaw = yawPosition;
        float roll = rollControl;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }


    void Fire()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            ActivateLasers(true);
        }

        else
        {
            ActivateLasers(false);
        }
            
    }

    private void ActivateLasers(bool activation)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionMod = laser.GetComponent<ParticleSystem>().emission;
            emissionMod.enabled = activation;
        }
    }

}
