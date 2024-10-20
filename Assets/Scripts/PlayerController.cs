using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    private ObjectPoolScript ProjPool;

    private int _playerHP = 3;

    public int PlayerHP
    {
        get { return _playerHP; }

        set
        {
            _playerHP = value;

            GM.instance.ChangePlayerHealth(PlayerHP);
            Debug.LogFormat("Player HP = {0}", _playerHP);

            if (_playerHP <= 0)
            {
                GM.instance.ChangePlayerHealth(0);
                
                gameObject.ReturnToPool();
                Debug.Log("Install Player Death");
            }
               

           
        }
    }
    //speed variable
    public float speed;

    //RG2D
    Rigidbody2D rb;

    //collider2D

    Collider2D pCollider;
    //Input Axis'

    Vector2 CardinalMovement;
    bool LeftClick;

    //playerHP (Get and Set)

    
   
    Camera gamePlayCamera;


    void Awake()
    {
        //reference to Rigibody2D
        rb = GetComponent<Rigidbody2D>();

        //
        pCollider = GetComponent<Collider2D>();

        gamePlayCamera = GameObject.Find("GameplayCamera").GetComponent<Camera>();

        ProjPool = gameObject.GetComponentInChildren<ObjectPoolScript>();

        
    }
    // Start is called before the first frame update
    void Start()
    {
        GM.instance.ChangePlayerHealth(PlayerHP);
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

       StayInLimits();

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

        ProjPool.GetObject();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<EnemyBehavior>(out EnemyBehavior anyEnemy))
        {
            Debug.Log("Hit by Enemy, subtract 1 health");

            PlayerHP -= 1;
        }

        else if(collision.gameObject.TryGetComponent<EnemyProjectile>(out EnemyProjectile projectile))
        {
            Debug.Log("hit by enemy projectile");

            PlayerHP -= 1;
        }
    }


    public void StayInLimits()
    {

       
        Vector3 CurrPosition = gamePlayCamera.WorldToViewportPoint(transform.position);

        CurrPosition.x = Mathf.Clamp01(CurrPosition.x);

        CurrPosition.y = Mathf.Clamp01(CurrPosition.y);

        transform.position = Camera.main.ViewportToWorldPoint(CurrPosition);
        //StayinLimits

        //Stay within these viewport coordinates

        //try it without colliders
    }


}
