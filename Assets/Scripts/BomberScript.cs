using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberScript : EnemyBehavior, IObjectPoolNotifier
{
    bool isVisible;
    bool isDisabled;
    //Vector for moving
    Vector2 bomberMove = Vector2.down;


    public void OnEnqueuedToPool()
    {

    }

    public void OnCreatedOrDequeuedFromPool(bool created)
    {

    }

    public void ReturnThisObject()
    {
        gameObject.ReturnToPool();
    }

    void FixedUpdate()
    {
        if(!isDisabled)
        {
            eRB.MovePosition(eRB.position + ((bomberMove * speed) * Time.deltaTime));
        }
       
    }

    private void OnEnable()
    {
        isDisabled = false;
    }

    private void OnDisable()
    {
        isDisabled = true;
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

    void OnBecameVisible()
    {
        isVisible = true;


    }

    void OnBecameInvisible()
    {
        isVisible = false;


        if (!isVisible)
        {
            //StartCoroutine(WaitThenKill());

            KillEntityNoPlayer();

            Debug.Log("Object destroyed");
        }



    }

    public override void KillEntityNoPlayer()
    {
        
        gameObject.ReturnToPool();
    }
}
