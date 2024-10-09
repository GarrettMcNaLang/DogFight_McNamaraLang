using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{

    private int _MaxEnemiesOnScreen = 4;

    public int maxEnemiesOnScreen {

        get { return _MaxEnemiesOnScreen; }

        set { _MaxEnemiesOnScreen = value;

        }
        }

    private int _playerHP = 3;

    public int PlayerHP
    {
        get { return _playerHP; }

        set
        {
            _playerHP = value;

            Debug.LogFormat("Player HP = {0}", _playerHP);

            if (_playerHP <= 0)

                Debug.Log("Install Player Death");

            Destroy(gameObject);
        }
    }



    //singleton format
    public static GM instance;

    CombatManager reference;
    void Awake()
    {
        instance = this;
        
        DontDestroyOnLoad(gameObject);

        reference = GameObject.Find("CombatObj").GetComponent<CombatManager>();

        Debug.Log("Game Manager reporting for duty");
    }

    private void OnEnable()
    {
        SpawnProjectile += reference.CreateProjectile;
       
    }

    //will spawn projectiles
    public delegate void ProjectileSpawner(bool whoFired, Vector2 shooterTransform);

    public event ProjectileSpawner SpawnProjectile;


    public void CallSpawnProjectile(bool whoFired, Vector2 shooterTransform)
    {
        Debug.Log("Entity that Fired: " + ((whoFired == true) ? " player" : "enemy"));

        

        SpawnProjectile(whoFired, shooterTransform);
    }

    public delegate void StartGame();

    public event StartGame initiateRoundManager;

    public void StartRoundManager()
    {
        initiateRoundManager();
    }

   
    public delegate void EnemyKilledEvent(bool diditHappen);

    public event EnemyKilledEvent Enemykilledevent;

    public void notifyRM(bool notification)
    {
        if (Enemykilledevent != null) 
            Enemykilledevent(notification);
    }

    public delegate void SetUpRound();

    public event SetUpRound RoundInstance;

    

    public delegate void PlayerDeath();

    public event PlayerDeath PlayerDeathEvent;

   
    //Spanws (Enemies and Players

    //EnemyCount in Wave (Get Set)

    //Enums for each wave

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //SetWave (enum Waves)

    //Set enemy count to different values according to Wave value
}
