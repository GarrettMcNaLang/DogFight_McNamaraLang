using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : ProjectileScript
{
   
    
    // Update is called once per frame

    public override void DetermineProjectileMove()
    {
        ProjectileMove = Vector2.up * projSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy))
        {
            DeleteProjectile();
        }
    }
}
