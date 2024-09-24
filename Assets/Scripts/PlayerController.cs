using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //speed variable
    public float speed;

    //RG2D
    Rigidbody2D rb;

    //Input Axis'

    float vAxis;

    float xAxis;

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

    // Start is called before the first frame update
    void Start()
    {
        //RB2D
    }

    // Update is called once per frame
    void Update()
    {
        //Input Axis'
    }

    //movement using Rigibody2D

    //if(Mouse1)
    //AttackEvent
    
    //1.InstantiateProjectile
    //2.bool: PlayerFired = true
    //2.send it in "forward" (player position and upward) direction
    //bool: if timer is complete repeat steps 1 and 2
    

    //send call to event in projectile script

    //OnHit

    //subtract 1 from player health
    //send message to MenuManager to subtract one player icon for lives.
    //cue brief immortality

    //StayinLimits

    //Stay within these viewport coordinates

    //try it without colliders

}
