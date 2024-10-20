using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerProjectile : ProjectileScript
{

    public int timeUntilDeath;

    private float timer = 0f;

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
    }


    public override void DeleteProjectile()
    {
        Debug.Log("player projectile returned");
       gameObject.ReturnToPool();
    }


}
