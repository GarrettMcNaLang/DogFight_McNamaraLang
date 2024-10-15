using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : ProjectileScript
{
    public override void OnRetrieve()
    {

    }

    public override void OnReturn()
    {

    }

    public override void DetermineProjectileMove()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
       if (collision.transform.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy))
        {
            // OnReturn();

            DeleteProjectile();
        }
    }
    //// Update is called once per frame

    //public override void DetermineProjectileMove()
    //{
    //    ProjectileMove = Vector2.up * projSpeed;
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.transform.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy))
    //    {
    //        DeleteProjectile();
    //    }
    //}
}
