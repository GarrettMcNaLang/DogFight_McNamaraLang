using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberScript : EnemyBehavior
{
    //Vector for moving
    Vector2 bomberMove = Vector2.down;
    //array of spawnpoints for the bomber enemy prefab
    private GameObject[] BomberSpawns;

    //timer variable for next spawn
    public float NextSpawn;

    //Countdown timer
    private float Countdown;

    public override void Setup()
    {
        Debug.Log("Setup function called");

        BomberSpawns = GameObject.FindGameObjectsWithTag("TopOfScreen");

     

        if(BomberSpawns.Length > 0 )
        {
            Debug.LogFormat("BomberSpawns populated, number of elements  {0}", BomberSpawns.Length);
        }

        Countdown = NextSpawn;

       

      

        
    }

    //CallUntilEnd function

    void Update()
    {
        Countdown -= Time.deltaTime;

        if(Countdown <= NextSpawn)
        {
            SpawnEnemy();

            Countdown = NextSpawn;
        }
    }



    void FixedUpdate()
    {
        eRB.MovePosition(eRB.position + ((bomberMove * speed) * Time.deltaTime));
    }
    //will be called upon the enemy running into the player, or colliding with a projectile
    public override void KillEntity()
    {
        Debug.Log("Function called, initiating kill");
        //should possess the EnemyLives variable from base
        EnemyLives -= 1;

        Debug.Log("Enemy killed, call event to decrease Bomber count");
    }

    //will spawn the enemy at a random gameobjects transform position, 
    //should utilize the awake function in the base class to perform function
    public override void SpawnEnemy()
    {
        Debug.Log("Function called, spawning enemy");

        
        //GameObject SpawnPoint = BomberSpawns[Random.Range(0, BomberSpawns.Length)];

        //Instantiate(this, SpawnPoint.transform);

        //if(quotaismet)

        //return from function
    }
}
