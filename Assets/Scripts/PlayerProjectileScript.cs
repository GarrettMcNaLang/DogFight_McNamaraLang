using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerProjectile : ProjectileScript
{

    public int timeUntilDeath;

    //Vector2 for movement
    Vector2 ProjectileMove;

    //the speed of the projectile
    public float projSpeed;

    bool isDisable;

    private void OnEnable()
    {
        isDisable = false;
        
        if(!isDisable)
        {
            gameObject.transform.rotation = Quaternion.identity;

            ProjectileMove = Vector2.up * projSpeed;
        }
       //StartCoroutine(StartCount(timeUntilDeath));
    }

    private void OnDisable()
    {
        isDisable = true;
    }

    void FixedUpdate()
    {
        if (!isDisable)
        {
            rb.MovePosition(rb.position + (ProjectileMove) * Time.deltaTime);
            Debug.Log(ProjectileMove);


        }
        

        //else if(EntityFired == false)

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
       if (collision.transform.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy))
        {
            // OnReturn();

            DeleteProjectile();
        }
    }
  
}
