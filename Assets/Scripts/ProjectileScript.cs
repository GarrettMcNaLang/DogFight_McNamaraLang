using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ProjectileScript : MonoBehaviour
{
    

    //rigidbody of the projectile
    protected Rigidbody2D rb;

    //decides how long an object lasts until death
  
   
 
    

  
    void Awake()
    {
       
        rb = GetComponent<Rigidbody2D>();

        //StartCoroutine(StartCount(timeUntilDeath));

    }

    private void Update()
    {
        
    }



    protected IEnumerator StartCount(int timeUntilDeath)
    {
        yield return new WaitForSeconds(timeUntilDeath);
        DeleteProjectile();
    }

    //on Call, will destroy itself
    protected void DeleteProjectile()
    {
       
        gameObject.ReturnToPool();
    }

   
    //OnInstantiate/ Constructor

    //receive if it was fired by player or by enemy

    //OnCollide

    //If(Collided with enemy)
    //send message to enemy OnHit

    //if(Collided with Player)
    //send message to enemy onHit
}
