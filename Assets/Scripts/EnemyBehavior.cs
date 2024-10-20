using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract and override
public abstract class EnemyBehavior : MonoBehaviour
{

   
   

    //[HideInInspector]
    protected Rigidbody2D eRB;

    [SerializeField]
    protected float speed;

    //Each enemy will have one life, and if they are hit by a projectile from the player, they are killed
    protected int _EnemyLives = 1;

    

    protected int EnemyLives
    {
        get { return _EnemyLives; }

        set
        {
            _EnemyLives = value;

           
            if (_EnemyLives <= 0)
            {
                Debug.Log("Initiate Enemy Death");
               
                gameObject.ReturnToPool();
                
            }
                
        }
    }
    public virtual void Awake()
    {
        

        //if (eCollider == null)
        //    Debug.Log("Awake function isn't making inheriters access collider");

        eRB = GetComponent<Rigidbody2D>();

        //if (eRB == null)
        //    Debug.Log("Awake function isn't making inheriters access rigidbodies");

       
        


    }
   
    //kills the enemy on collision
    public abstract void KillEntity();

    public abstract void KillEntityNoPlayer();

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerController>(out PlayerController player))
        {
            Debug.Log("player touched enemy entity");

            KillEntity();

            Debug.Log("inititate playerDeath function using player object");


        }
        else if(collision.transform.TryGetComponent<PlayerProjectile>(out PlayerProjectile projectile)) {


            Debug.Log("projectile has hit enemy entity");

            KillEntity();

            Debug.Log("call event to decrease number of targets to destroy");


        }
    }


 
   

  
  


}
