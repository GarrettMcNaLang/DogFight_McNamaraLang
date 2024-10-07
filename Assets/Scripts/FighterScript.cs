using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FighterScript : EnemyBehavior
{
    //will spawn at a random location
    //will move towards a specific point offscreen
    //will shoot three projectiles at the player's last known location

    //3 points past the bottom of the screen that will be chosen randomly for the enemy to move to 
    private GameObject[] Destinations;
    //the upper middle of the screen
    private GameObject[] ConstantDestination;
    
    //reference used for collisions
    public GameObject Player;

    //a randomly selected gameObject from the Destinations array
    GameObject endPosition;

    GameObject ConstPosition;

    //Direction from the enemy rigibody to any relevant location
    Vector2 Direction;

    //the position of the middle vector
    Vector2 constantDestinationVector;

    //the position of the rigibody
    Vector2 EnemyPosition;

    //location of the randomly selected endposition position
    Vector2 endPositionVector;

    public GameObject Projectile;

   
    bool middle;
    bool reachedMiddle
    {
        get
        {
            return reachedMiddle;
        }

        set
        {
            reachedMiddle = value;

            if(!reachedMiddle)
            {
                AttackEvent();
                
            }
            
        }
    }

    

    public override void Setup()
    {
        //retrieves all ends for the array
        Destinations = GameObject.FindGameObjectsWithTag("EMoveTowards");

        //checks if it's full
        if (Destinations != null)
            Debug.LogFormat("Array filled, full of {0} elements", Destinations.Length);
        
        //gets the constantDestination position gameObject
        ConstantDestination = GameObject.FindGameObjectsWithTag("ConstantLocation");

        if (ConstantDestination != null)
            Debug.LogFormat("Array filled, full of {0} elements", ConstantDestination.Length);
        //randomly selects a gameobject from the array
        endPosition = Destinations[UnityEngine.Random.Range(0, Destinations.Length)];

        ConstPosition = ConstantDestination[UnityEngine.Random.Range(0, ConstantDestination.Length)];
        //retrieves player object
        Player = GameObject.Find("Player");

        //checks if it's full
        if (Player != null)
            Debug.Log("Player object is full");

       //gets the inital position for the rigibody, used for distance and movement calculations
        EnemyPosition = eRB.position;

        //position of randomly selected end position
        endPositionVector = endPosition.transform.position;

        //position of ConstantDestination object
        constantDestinationVector = ConstPosition.transform.position;

        //direction from enemy position to middle destination
        Direction = (constantDestinationVector - EnemyPosition).normalized;
    }
    // Update is called once per frame
    void Update()
    {
      
        if(Vector2.Distance(EnemyPosition, constantDestinationVector) < 1f)
        {
            
        }
        
        //calculates the distance between the Enemy and the middle destination
       
        // Debug.Log(Distance);

       

            

    }

    public bool CheckDistance()
    {
       var Distance = Vector2.Distance(EnemyPosition, constantDestinationVector);

        if (Distance > 1f)
            return true;
        else
        Direction = (endPositionVector - EnemyPosition).normalized;
        Physics.SyncTransforms();
        return true;
    }

    void FixedUpdate()
    {
        //cast raycast toward player location

        


        eRB.MovePosition(eRB.position + (speed * Time.deltaTime * Direction));

        //eRB.MovePosition(eRB.position + (speed * Time.deltaTime * FighterMove));

        

    }

   

    public void AttackEvent()
    {

        
        Vector2 position = this.transform.position;


            //GM.instance.SpawnProjectile(false, position);

            GM.instance.CallSpawnProjectile(false, position);
      

       
        

    }
  

    public override void KillEntity()
    {
        Debug.Log("Fighter Down, decreasingenemy");

        EnemyLives -= 1;
    }

   

    //EnemyMove

    //OnHit

    //ShootEvent


}
