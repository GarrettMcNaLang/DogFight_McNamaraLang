using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    //public static event Action ChangeRoundNumber = delegate { };

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


    private int _MaxEnemiesOnScreen = 4;

    public int maxEnemiesOnScreen
    {

        get { return _MaxEnemiesOnScreen; }

        set
        {
            _MaxEnemiesOnScreen = value;

        }
    }

    [SerializeField]
    private ObjectPoolScript BomberPool;

    [SerializeField]
    private ObjectPoolScript FighterPool;

    [SerializeField]
    private ObjectPoolScript ProjectilePool;

    [SerializeField]
    private ObjectPoolScript PlayerPool;



    private void OnEnable()
    {

        SpawnProjectile += reference.CreateProjectile;
    }

    private void OnDisable()
    {
        SpawnProjectile -= reference.CreateProjectile;
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

    public delegate void ChangeStage(int RoundNum);

    public event ChangeStage Changestage;

    public void SetRoundUI(int RoundNum)
    {
        Changestage(RoundNum);
    }
   
    public delegate void EnemyKilledEvent(bool diditHappen);

    public event EnemyKilledEvent Enemykilledevent;

    public void notifyRM(bool notification)
    {
        if (Enemykilledevent != null) 
            Enemykilledevent(notification);
    }

    public delegate void PlayerHealthTransmit(int PHealth);

    public event PlayerHealthTransmit Playerhealthtransmit;

    public void ChangePlayerHealth(int PlayerHealth)
    {
        Playerhealthtransmit(PlayerHealth);
    }

    public delegate void BomberTransmit(int Bombers);

    public event BomberTransmit Bombertransmit;

    public void ChangeBomberCount(int BomberCount)
    {
        Bombertransmit(BomberCount);
    }

    public delegate void FighterTransmit(int Fighters);

    public event FighterTransmit Fightertransmit;

    public void ChangeFighterCount(int Fighters)
    {
        Fightertransmit(Fighters);
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
