using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
  
    //speed variable
    public float speed;

    //RG2D
    Rigidbody2D rb;

    //Input Axis'

    Vector2 CardinalMovement;
    bool LeftClick;

    //playerHP (Get and Set)

    private int _playerHP = 3;

    public int PlayerHP 
    { 
        get { return _playerHP; }

        set { _playerHP = value;

            if (_playerHP <= 0)

                Debug.Log("Install Player Death");
        }
    }

    void Awake()
    {
        //reference to Rigibody2D
        rb = GetComponent<Rigidbody2D>();

        //
    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //A Vector2 that represents the vertical and horizontal movements of the player

        CardinalMovement = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;

        LeftClick |= Input.GetMouseButtonDown(0);

        if(LeftClick)
        {
            AttackEvent();
        }
        LeftClick = false;

    }

    //movement using Rigibody2D

    void FixedUpdate()
    {
        //utilizes MovePosition to move in both vertical and horizontal axis', multiplied by speed and Time.deltaTime
        rb.MovePosition(rb.position + (speed * Time.deltaTime * CardinalMovement));

        
    }

    public void AttackEvent()
    {
        Debug.Log("Player Has Fired");

        //if(Mouse1)
        //AttackEvent

        //1.InstantiateProjectile
        //2.bool: PlayerFired = true
        //2.send it in "forward" (player position and upward) direction
        //bool: if timer is complete repeat steps 1 and 2


        //send call to event in projectile script
    }


    public void OnHit()
    {
        //OnHit

        //subtract 1 from player health
        //send message to MenuManager to subtract one player icon for lives.
        //cue brief immortality

    }

    public void StayInLimits()
    {
        
        //StayinLimits

        //Stay within these viewport coordinates

        //try it without colliders
    }


}
