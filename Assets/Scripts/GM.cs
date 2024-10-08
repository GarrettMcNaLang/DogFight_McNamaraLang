using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    //singleton format
    public static GM instance;

    CombatManager reference;
    void Awake()
    {
        instance = this;
        
        DontDestroyOnLoad(gameObject);

        reference = GameObject.Find("CombatObj").GetComponent<CombatManager>();
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

    public void CallRoundManager()
    {
        initiateRoundManager();
    }

    public delegate void EnemyKilledEvent(bool diditHappen);

    public event EnemyKilledEvent _EnemyKilledEvent;

    public void notifyRM(bool notification)
    {
        if (_EnemyKilledEvent != null) 
            _EnemyKilledEvent(notification);
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
