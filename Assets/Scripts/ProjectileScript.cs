using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    Vector2 ProjectileMove;

    public float projSpeed;

    public Collider2D pCollider;

    public Rigidbody2D rb;

    private float timer;

    public float timeUntilDeath;

    void Awake()
    {
        pCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        OnInstantiate(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProjectileMove = Vector2.up * projSpeed;
    }

    void FixedUpdate()
    {
        
    }

    //will establish who fired this projectile, based on the argument (which will be an event call that is sent by the 
    //enemy or player)
    public void OnInstantiate(bool whoFired)
    {
        switch(whoFired)
        {
            //case Player
            case true:
                Debug.Log("PlayerFire");
                break;

            //case Enemy
            case false:

                Debug.Log("EnemyFired");
                break;
        }
    }

    IEnumerator StartCount()
    {
        yield break;
    }
    //OnInstantiate/ Constructor

    //receive if it was fired by player or by enemy

    //OnCollide

    //If(Collided with enemy)
    //send message to enemy OnHit

    //if(Collided with Player)
    //send message to enemy onHit
}
