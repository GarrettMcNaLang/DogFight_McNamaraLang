using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyProjectile : ProjectileScript
{
    bool isDisable;

    public GameObject player;

    public int timeUntilDeath;

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

        //StartCoroutine(StartCount(timeUntilDeath));
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.TryGetComponent<PlayerController>(out PlayerController player))
        {
            // OnReturn();

            DeleteProjectile();
        }
    }



}
