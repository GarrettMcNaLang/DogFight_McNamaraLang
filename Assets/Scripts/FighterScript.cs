using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FighterScript : EnemyBehavior
{
    //will spawn at a random location
    //will move towards a specific point offscreen
    //will shoot three projectiles at the player's last known location

    //3 points past the bottom of the screen that will be chosen randomly for the enemy to move to 
    private GameObject[] Destinations;

    public GameObject Player;

    Vector2 FighterMove;


    GameObject endPosition;

    


    public override void Setup()
    {
        Destinations = GameObject.FindGameObjectsWithTag("EMoveTowards");

        if (Destinations != null)
            Debug.LogFormat("Array filled, full of {0} elements", Destinations.Length);

        Player = GameObject.Find("Player");

        if (Player != null)
            Debug.Log("Player object is full");

        endPosition = Destinations[Random.Range(0, Destinations.Length)];



        FighterMove = new Vector2(endPosition.transform.position.x - eRB.position.x, endPosition.transform.position.y - eRB.position.y).normalized;
    }
    // Update is called once per frame
    void Update()
    {
        

       
    }

    void FixedUpdate()
    {
        //cast raycast toward player location


        eRB.MovePosition(eRB.position + (speed * Time.deltaTime * FighterMove));


        
    }


    public void AttackEvent()
    {
        //instantiate projectiles and wait for a few seconds
    }
  

    public override void KillEntity()
    {
        
    }

   
    //EnemyMove

    //OnHit

    //ShootEvent


}
