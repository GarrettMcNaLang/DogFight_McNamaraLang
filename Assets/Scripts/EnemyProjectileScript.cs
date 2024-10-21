using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class EnemyProjectile : ProjectileScript,IObjectPoolNotifier
{


    
    bool isDisable;

    public GameObject player;

    public int timeUntilDeath;

    private float timer = 0f;

    //Vector2 for movement
    Vector2 ProjectileMove;

    //the speed of the projectile
    public float projSpeed;


    private void OnEnable()
    {
        isDisable = false;

        if(!isDisable)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            var direction = player.transform.position - transform.position;
            ProjectileMove = new Vector2(direction.x, direction.y).normalized * (projSpeed * 2);

            var rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotation + 90);

            
        }

       
    }

    void Update()
    {
        
            timer += Time.deltaTime;

            if (timer >= timeUntilDeath)
            {
                DeleteProjectile();
            }
        
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
    private void OnDisable()
    {
        isDisable = true;

        timer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.TryGetComponent<PlayerController>(out PlayerController player))
        {
            // OnReturn();

            DeleteProjectile();
        }
        else if(collision.transform.TryGetComponent<PlayerProjectile>(out PlayerProjectile projectile))
        {
            DeleteProjectile();
        }
    }

    public override void DeleteProjectile()
    {
        Debug.Log("Returning enemy projectile");
        gameObject.ReturnToPool();
    }

    public void OnEnqueuedToPool()
    {
        Debug.Log("Enemy Projectile returned to pool");
    }

    public void OnCreatedOrDequeuedFromPool(bool created)
    {
        Debug.Log("Enemy Projectile created");
    }

    public void ReturnThisObject()
    {
        gameObject.ReturnToPool();
    }

}
