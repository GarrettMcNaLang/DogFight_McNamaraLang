using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //Vector2 for movement
    Vector2 ProjectileMove;

    //the speed of the projectile
    public float projSpeed;

    //collider for the projectile
    private Collider2D pCollider;

    //rigidbody of the projectile
    private Rigidbody2D rb;

    //decides how long an object lasts until death
    public float timeUntilDeath;

    bool EntityFired;

    private GameObject player;

    

  
    void Awake()
    {
        pCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();


        
    }
   
    void FixedUpdate()
    {

        rb.MovePosition(rb.position + (ProjectileMove) * Time.deltaTime);

        //else if(EntityFired == false)

    }

    //will establish who fired this projectile, based on the argument (which will be an event call that is sent by the 
    //enemy or player)

    public void OnRetrieve(bool whoFired, Vector2 shooterPosition)
    {
     
        gameObject.transform.rotation = Quaternion.identity;

        rb.position = shooterPosition;

        if(whoFired == true)
        {
            ProjectileMove = Vector2.up * projSpeed;

            rb.position += Vector2.up;

        }
        else if(whoFired == false)
        {

              player = GameObject.FindGameObjectWithTag("Player");
              var direction = player.transform.position - transform.position;
               ProjectileMove = new Vector2(direction.x, direction.y).normalized * (projSpeed * 2);

                var rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, rotation + 90);

            rb.position += Vector2.down;
        }

        StartCoroutine(StartCount());
    }

    public void OnReturn()
    {
        
    }
    //public void OnInstantiate(bool whoFired, Vector2 shooterTransform);
    //{
    //    Vector2 POS = gameObject.transfrom.position;

    //    switch (whoFired)
    //    {
    //        //case Player
    //        case true:
                
    //            //Debug.Log("PlayerFire");
    //            ProjectileMove = Vector2.up * projSpeed;


    //            break;

    //        //case Enemy
    //        case false:


               
               
    //            player = GameObject.FindGameObjectWithTag("Player");
    //            var direction = player.transform.position - transform.position;
    //            ProjectileMove = new Vector2(direction.x, direction.y).normalized * (projSpeed * 2);

    //            var rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
    //            transform.rotation = Quaternion.Euler(0, 0, rotation + 90);


    //            Debug.Log("EnemyFired");
    //            break;
    //    }

    //    StartCoroutine(StartCount());
    //}

    //IEnumerator that calls the DeleteProjectile function upon the WaitForSeconds object expiring
    IEnumerator StartCount()
    {
        yield return new WaitForSeconds(timeUntilDeath);
        DeleteProjectile();
    }

    //on Call, will destroy itself
    public void DeleteProjectile()
    {
        //OnReturn();
        gameObject.ReturnToPool();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerController>(out PlayerController player))
        {
            //OnReturn();
            DeleteProjectile();
        }
        else if (collision.transform.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy))
        {
            // OnReturn();

            DeleteProjectile();
        }
    }
    //OnInstantiate/ Constructor

    //receive if it was fired by player or by enemy

    //OnCollide

    //If(Collided with enemy)
    //send message to enemy OnHit

    //if(Collided with Player)
    //send message to enemy onHit
}
