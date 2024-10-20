using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour
{


    //public GameObject PlayerPrefab;
    public ObjectPoolScript PlayerPool;

    
    private int _BomberNum;

   public int BomberNum
    {
        get { return _BomberNum; }

        set { _BomberNum = value;

          GM.instance.ChangeBomberCount(BomberNum);
            //Debug.Log(_BomberNum);

            if (BomberNum <= 0)
                GM.instance.ChangeBomberCount(0);
        }
    }

    private int _FighterNum;

    public int FighterNum
    {
        get { return _FighterNum; }

        set { _FighterNum = value;

            GM.instance.ChangeFighterCount(FighterNum);
            //Debug.Log(_FighterNum);

            if (FighterNum <= 0)
                GM.instance.ChangeFighterCount(0);
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

    

    private void OnEnable()
    {
        GM.instance.initiateRoundManager += ChooseRound;

        GM.instance.Enemykilledevent += EnemyWasKilled;

        
    }

    private void OnDisable()
    {
        GM.instance.initiateRoundManager -= ChooseRound;

        GM.instance.Enemykilledevent -= EnemyWasKilled;
    }
    void Awake()
    {
     

        BombersSpawn = GameObject.FindGameObjectsWithTag("TopOfScreen");

    

        FightersSpawn = GameObject.FindGameObjectsWithTag("SidesOfScreen");

       
        CurrRound = RoundNumber.One;


        GM.instance.ChangeFighterCount(FighterNum);

        GM.instance.ChangeBomberCount(BomberNum);
       
    }

   
   

    // Update is called once per frame
    void Update()
    {
       

        if(BomberNum > 0 || FighterNum > 0)
        {
            stillGoing = true;
            
        }
        else
        {
            Debug.Log("should call victory screen function");
            stillGoing = false;
        }
    }


    public void ChooseRound()
    {
        switch (CurrRound)
        {
            case RoundNumber.One:
                {
                    //Debug.Log("Round 1 activated");
                   
                    spawnLimit = 2;

                    BomberNum = 0;
                    FighterNum = 0;
                    isLastRound = true;
                    RoundOne();
                    break;
                }

        }
    }
   
    public void SpawnPlayer()
    {
        //Debug.Log("Spawning player");

        var PlayerInstance = PlayerPool.GetObject();

       

    }

    public void RoundOne()
    {
        
        StartCoroutine(SetRoundNum(1));

        

        SpawnPlayer();

        //Debug.Log("In Round 1 program");

       
        StartCoroutine(RoundOneWorking());

        // RoundSpawn();

        //if (BomberNum < 0 && FighterNum < 0)
        //{
        //    Debug.Log("Should have called function when no enemies are there");
        //    ChangeRound(isLastRound);
        //}



    }

    IEnumerator SetRoundNum(int RoundNum)
    {
        //Debug.Log("Changing Round Number");

        GM.instance.SetRoundUI(RoundNum);

        yield return new WaitForSeconds(5);
    }

    IEnumerator RoundOneWorking()
    {
        yield return new WaitForSeconds(5);

        Debug.Log("Code has reached Round 1");

        while (stillGoing)
        {
            for(int i = 0; i < spawnLimit; i++)
            {
                var BomberSpawn = BombersSpawn[Random.Range(0, BombersSpawn.Length)].GetComponent<ObjectPoolScript>(); ;

                BomberSpawn.GetObject();
               // Instantiate(Bombers, BombersSpawn[Random.Range(0, BombersSpawn.Length)].transform.position, Quaternion.identity);
                Debug.Log("Should've spawned a bomber");

                var FighterSpawn = FightersSpawn[Random.Range(0, FightersSpawn.Length)].GetComponent<ObjectPoolScript>();

                FighterSpawn.GetObject();
              

                //Instantiate(Fighters, FightersSpawn[Random.Range(0, FightersSpawn.Length)].transform.position, Quaternion.identity);

                Debug.Log("Should've spawned a fighter");
                yield return new WaitForSeconds(5);
            }
            
          yield return null;

        }

        ChangeRound(isLastRound);
        Debug.Log("This shouldn't run");
       

    }


    public void ChangeRound(bool DetermineRoundOrScreen)
    {
        if (isLastRound)
        {
            Debug.Log("Victory Screen condition");
            GM.instance.EndgameFunction();
        }
        else if(!isLastRound)
        {
            Debug.Log("Inititate next round");
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
