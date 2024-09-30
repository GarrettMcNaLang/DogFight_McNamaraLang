using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberScript : EnemyBehavior
{
    //Vector for moving
    Vector2 bomberMove;
    //array of spawnpoints for the bomber enemy prefab
    public GameObject[] BomberSpawns;

    public override void Setup()
    {

        SpawnEnemy();

        EnemyMove();

        
    }

    //CallUntilEnd function



    //will move the bomber enemy in a downward direction
    //This overriden function should be the one called in the base class awake
    public override void EnemyMove()
    {
        bomberMove = Vector2.down;

        eRB.MovePosition(eRB.position + (bomberMove * speed) * Time.fixedDeltaTime);
    }

    //will be called upon the enemy running into the player, or colliding with a projectile
    public override void KillEntity()
    {
        //should possess the EnemyLives variable from base
        EnemyLives -= 1;

        Debug.Log("Enemy killed, call event to decrease Bomber count");
    }

    //will spawn the enemy at a random gameobjects transform position, 
    //should utilize the awake function in the base class to perform function
    public override void SpawnEnemy()
    {
       GameObject SpawnPoint = BomberSpawns[Random.Range(0, BomberSpawns.Length)];

        Instantiate(this, SpawnPoint.transform);

        //if(quotaismet)

        //return from function
    }
}
