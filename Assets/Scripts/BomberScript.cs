using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberScript : EnemyBehavior
{
    //Vector for moving
    Vector2 bomberMove = Vector2.down;


    public override void Setup()
    {
       
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

        GM.instance.notifyRM(false);

        Debug.Log("Enemy killed, call event to decrease Bomber count");
    }

    public void OnRetrieve(Vector2 enemyspawn)
    {
        eRB.position = enemyspawn;
        
    }
}
