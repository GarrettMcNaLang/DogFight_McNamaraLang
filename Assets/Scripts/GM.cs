using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    //singleton format
    public static GM instance;


    void Awake()
    {
        instance = this;
        if (instance)
        {
            DestroyImmediate(instance);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {

       
    }

    //will spawn projectiles
    public delegate void ProjectileSpawner(bool whoFired, Vector2 shooterTransform);

    public event ProjectileSpawner SpawnProjectile;

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
