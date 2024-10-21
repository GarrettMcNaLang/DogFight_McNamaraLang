using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerProjectile : ProjectileScript, IObjectPoolNotifier
{

    public int timeUntilDeath;

    private float timer = 0f;

    //Vector2 for movement
    Vector2 ProjectileMove;

    //the speed of the projectile
    public float projSpeed;

    bool isDisable;

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

    private void OnEnable()
    {
        isDisable = false;
        
        if(!isDisable)
        {
            gameObject.transform.rotation = Quaternion.identity;

            ProjectileMove = Vector2.up * projSpeed;

            
        }
      
    }

    private void OnDisable()
    {
        isDisable = true;

        timer = 0;
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

    void Update()
    {
       
            
            timer += Time.deltaTime;
            
            if (timer >= timeUntilDeath)
            {
                DeleteProjectile();
            }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
       if (collision.transform.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy))
        {
            // OnReturn();

            DeleteProjectile();
        }
       else if(collision.transform.TryGetComponent<EnemyProjectile>(out EnemyProjectile Eproj)){

            DeleteProjectile();
        }
    }


    public override void DeleteProjectile()
    {
        Debug.Log("player projectile returned");
       gameObject.ReturnToPool();
    }


}
