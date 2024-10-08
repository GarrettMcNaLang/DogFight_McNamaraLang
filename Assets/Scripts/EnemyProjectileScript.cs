using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectile : ProjectileScript
{
    GameObject player;

    Vector2 direction;

   void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        direction = player.transform.position - transform.position;
    }
    
    

    

                

   

  public override void DetermineProjectileMove()
   {
        ProjectileMove = new Vector2(direction.x, direction.y).normalized * projSpeed;

        var rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);


        Debug.Log("EnemyFired");
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerController>(out PlayerController player))
        {
            DeleteProjectile();
        }
      
    }

}
