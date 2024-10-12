using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour
{

    [SerializeField]
    private ObjectPoolScript playerPool;

    [SerializeField]
    private ObjectPoolScript FighterPool;

    [SerializeField]
    private ObjectPoolScript BomberPool;

    //public GameObject PlayerPrefab;

   public GameObject PlayerSpawn;

    private int _BomberNum = 5;

   public int BomberNum
    {
        get { return _BomberNum; }

        set { _BomberNum = value;

            GM.instance.ChangeBomberCount(_BomberNum);
            Debug.Log(_BomberNum);
        }
    }

    private int _FighterNum = 5;

    public int FighterNum
    {
        get { return _FighterNum; }

        set { _FighterNum = value;

            GM.instance.ChangeFighterCount(_FighterNum);
            Debug.Log(_FighterNum);
        }
    }

    public int spawnLimit;
    bool isLastRound;

   
    public GameObject Bombers;

    public GameObject Fighters;

    GameObject[] BombersSpawn;

    GameObject[] FightersSpawn;

    enum RoundNumber {One};

    RoundNumber CurrRound;

    bool stillGoing;
    void Awake()
    {
        GM.instance.initiateRoundManager += RoundOne;

        GM.instance.Enemykilledevent += EnemyWasKilled;

        BombersSpawn = GameObject.FindGameObjectsWithTag("TopOfScreen");

        if (BombersSpawn != null)
            Debug.Log("Bomber Spawns found");

        FightersSpawn = GameObject.FindGameObjectsWithTag("SidesOfScreen");

        Debug.Log("RoundManager reporting for duty");

        if (FightersSpawn != null)
           Debug.Log("Fighter Spawns found");
        CurrRound = RoundNumber.One;

       
    }

   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        switch(CurrRound)
        {
            case RoundNumber.One:
                {
                    Debug.Log("Round 1 activated");
                    
                    spawnLimit = 2;
                    break;
                }
            
        }

        if(BomberNum > 0 && FighterNum > 0)
        {
            stillGoing = true;
            
        }
        else
        {
            stillGoing = false;
        }
    }

   
    public void SpawnPlayer()
    {
        var PlayerInstance = playerPool.GetObject();

        PlayerController GetScript = PlayerInstance.GetComponent<PlayerController>();

        GetScript.OnRetrieve(PlayerSpawn);
    }

    public void RoundOne()
    {
        SpawnPlayer();

        Debug.Log("In Round 1 program");

        StartCoroutine(RoundOneWorking());

        // RoundSpawn();

        if (BomberNum == 0 && FighterNum == 0)
        {
            ChangeRound();
        }



    }

    IEnumerator RoundOneWorking()
    {
        

        while (stillGoing)
        {
            for(int i = 0; i < spawnLimit; i++)
            {
                var Bomber = BomberPool.GetObject();
                BomberScript BomberInstance = Bomber.GetComponent<BomberScript>();
                BomberInstance.OnRetrieve(BombersSpawn[Random.Range(0, BombersSpawn.Length)].transform.position);

               // Instantiate(Bombers, BombersSpawn[Random.Range(0, BombersSpawn.Length)].transform.position, Quaternion.identity);
                Debug.Log("Should've spawned a bomber");

                var Fighter = FighterPool.GetObject();
                FighterScript FighterInstance = Fighter.GetComponent<FighterScript>();
                FighterInstance.OnRetrieve(FightersSpawn[Random.Range(0, FightersSpawn.Length)].transform.position);

                //Instantiate(Fighters, FightersSpawn[Random.Range(0, FightersSpawn.Length)].transform.position, Quaternion.identity);

                Debug.Log("Should've spawned a fighter");
                yield return new WaitForSeconds(5);
            }
            
          yield return null;

        }

        Debug.Log("This shouldn't run");
       
    }

    public void RoundSpawn()
    {

       

        //int MaxEnemyOnScreen = 4;

        //int numberSpawn = 0;

        //while(MaxEnemyOnScreen >= numberSpawn) {

        //    GameObject BomberSpawnPoint = BombersSpawn[Random.Range(0, BombersSpawn.Length)];

        //    GameObject FighterSpawnPoint = FightersSpawn[Random.Range(0, FightersSpawn.Length)];

        //    Instantiate(Bombers, BomberSpawnPoint.transform.position, Quaternion.identity);
        //    numberSpawn++;


        //    Instantiate(Fighters, FighterSpawnPoint.transform.position, Quaternion.identity);
        //    numberSpawn++;

        //    StartCoroutine(SpawnedTwo());
        //}



        //if (BomberNum == 0 && FighterNum == 0)
        //{
        //    return;
        //}
    }

    IEnumerator SpawnedTwo(int seconds)
    {
        Debug.Log("Spawned two, now waiting");
        yield return new WaitForSeconds(seconds);
    }

    public void ChangeRound()
    {
        if (isLastRound)
        {
            Debug.Log("Victory Screen condition");
        }
        //GM.instance.Changestage Function.


    }

    public void EnemyWasKilled(bool EnemyType)
    {
        if(EnemyType == true)
        {
            Debug.Log("Fighter was killed");
            FighterNum -= 1;
        }
        else if(EnemyType == false)
        {
            Debug.Log("Bomber was killed");
            BomberNum -= 1;
        }
    }
}
