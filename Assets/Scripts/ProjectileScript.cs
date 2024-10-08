using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ProjectileScript : MonoBehaviour
{
    //Vector2 for movement
    protected Vector2 ProjectileMove;
    
    //the speed of the projectile
    public float projSpeed;

    //collider for the projectile
    protected Collider2D pCollider;

    //rigidbody of the projectile
    protected Rigidbody2D rb;

    //decides how long an object lasts until death
    public float timeUntilDeath;

    void Awake()
    {
        pCollider = GetComponent<Collider2D>();
        
        if (TryGetComponent<Rigidbody2D>(out rb))
            Debug.Log("rigibody empty");

        //gameObject.layer = LayerMask.NameToLayer("Default");

    }

    //void Update()
    //{
    //    float timer += Time.deltaTime;

    //    if(timer >= timeUntilDeath)
    //    {
    //        DeleteProjectile();
    //    }
    //}
    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + (ProjectileMove) * Time.deltaTime);

        //else if(EntityFired == false)

    }

    public abstract void DetermineProjectileMove();

   

    //on Call, will destroy itself
    protected void DeleteProjectile()
    {
        Destroy(gameObject);
    }

   
    //OnInstantiate/ Constructor

    //receive if it was fired by player or by enemy

    //OnCollide

    //If(Collided with enemy)
    //send message to enemy OnHit

    //if(Collided with Player)
    //send message to enemy onHit
}
