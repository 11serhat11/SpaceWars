using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    ScoreBoard scoreBoard;
    GameObject spawn;
    [SerializeField] int scorePoint = 1;
    [SerializeField] int hitPoints = 3;
    void Start()
    {
        AddRigidbody();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        spawn = GameObject.FindWithTag("Spawn");
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    [SerializeField] GameObject vfxBlow; //Blowing Effect
    [SerializeField] GameObject vfxDamage; //Damage Effect
    void OnParticleCollision(GameObject other)
    {
        Damage();
        
    }

    void Damage()
    {
        hitPoints--;
        GameObject vfx = Instantiate(vfxDamage,transform.position,Quaternion.identity);
        vfx.transform.parent = spawn.transform;
        
        if (hitPoints <= 0)
        {
            KillEnemy();
            
        }
    }

    void KillEnemy()
    {
        //creating clone of the vfx at the position of our object
        //and assigning to the variable vfx1
        GameObject vfx = Instantiate(vfxBlow, transform.position, Quaternion.identity);
        vfx.transform.parent = spawn.transform; //clone vfx goes to the folder
        Destroy(gameObject); //destroy the object
        IncreaseScore(); //Increase score when we kill the enemy
    }

    void IncreaseScore()
    {
        scoreBoard.IncreaseScore(scorePoint);
    }
}
