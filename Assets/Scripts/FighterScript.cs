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
    bool isVisible;
    bool isDisabled;

    private ObjectPoolScript NosePool;
    
    //will spawn at a random location
    //will move towards a specific point offscreen
    //will shoot three projectiles at the player's last known location
    
    //3 points past the bottom of the screen that will be chosen randomly for the enemy to move to 
    private GameObject[] Destinations;
    //the upper middle of the screen
    private GameObject[] ConstantDestination;
    
    

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

    bool goToMiddle = false;

  
    bool reachedMiddle
    {
        get
        {
            return reachedMiddle;
        }

        set
        {
            reachedMiddle = value;

            if(goToMiddle)
            {
                AttackEvent();
                
            }
            
        }
    }

    
   

    void OnEnable()
    {
        isDisabled = false;

        if (!isDisabled)
        {
            NosePool = gameObject.GetComponentInChildren<ObjectPoolScript>();

            Destinations = GameObject.FindGameObjectsWithTag("EMoveTowards");

            ConstantDestination = GameObject.FindGameObjectsWithTag("ConstantLocation");

            Debug.Log("IsEnabled");
            // NewMidpointandEndpoint();
            endPosition = Destinations[UnityEngine.Random.Range(0, Destinations.Length)];

            ConstPosition = ConstantDestination[UnityEngine.Random.Range(0, ConstantDestination.Length)];
            //gets the inital position for the rigibody, used for distance and movement calculations

            EnemyPosition = eRB.position;
            //position of randomly selected end position
            endPositionVector = endPosition.transform.position;

            //position of ConstantDestination object
            constantDestinationVector = ConstPosition.transform.position;

            //direction from enemy position to middle destination
            Direction = (constantDestinationVector - EnemyPosition).normalized;
        }

      
    }

    void OnDisable()
    {
        isDisabled = true;
    }

    public void NewMidpointandEndpoint()
    {
        Debug.Log("In Midpoint and Endpoint generator");
       
    }



    void Update()
    {
        if (!isDisabled)
        {
            EnemyPosition = eRB.position;

            if (!goToMiddle && Vector2.Distance(EnemyPosition, constantDestinationVector) < 1f)
            {
                Direction = (endPositionVector - EnemyPosition).normalized;


                Physics.SyncTransforms();

                Debug.Log("Changing Direction");

                AttackEvent();
                goToMiddle = true;
            }
        }
       

    }

  
    void FixedUpdate()
    {
        
        if(!isDisabled){
            eRB.MovePosition(eRB.position + (speed * Time.deltaTime * Direction));
        }

    }

   

    public void AttackEvent()
    {

        //GM.instance.SpawnProjectile(false, position);

        NosePool.GetObject();

            //GM.instance.CallSpawnProjectile(false, position);

    }
  

    public override void KillEntity()
    {
        Debug.Log("Fighter Down, decreasingenemy");

        EnemyLives -= 1;

        GM.instance.notifyRM(true);

    }


    void OnBecameVisible()
    {
        isVisible = true;


    }

    void OnBecameInvisible()
    {
        isVisible = false;


        if (!isVisible)
        {
            //StartCoroutine(WaitThenKill());

            gameObject.ReturnToPool();

            Debug.Log("Object destroyed");
        }



    }
}
