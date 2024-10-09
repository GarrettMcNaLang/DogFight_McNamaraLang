using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour
{
    public GameObject PlayerPrefab;

   public GameObject PlayerSpawn;

   static private int _BomberNum = 5;

   static public int BomberNum
    {
        get { return _BomberNum; }

        set { _BomberNum = value; }
    }

   static private int _FighterNum = 5;

   static public int FighterNum
    {
        get { return _FighterNum; }

        set { _FighterNum = value; }
    }

    bool isLastRound;

   
    public GameObject Bombers;

    public GameObject Fighters;

    GameObject[] BombersSpawn;

    GameObject[] FightersSpawn;

    void Awake()
    {
        GM.instance.initiateRoundManager += RoundOne;

        GM.instance.Enemykilledevent += EnemyWasKilled;

        BombersSpawn = GameObject.FindGameObjectsWithTag("TopOfScreen");

        //if (BombersSpawn != null)
        //    Debug.Log("Bomber Spawns found");

        FightersSpawn = GameObject.FindGameObjectsWithTag("SidesOfScreen");

        //if (FightersSpawn != null)
        //    Debug.Log("Fighter Spawns found");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void RoundOne()
    {

   
       Instantiate(PlayerPrefab, PlayerSpawn.transform.position, Quaternion.identity); 



        if (BomberNum == 0 && FighterNum == 0)
        {
            ChangeRound();
        }
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

    IEnumerator SpawnedTwo()
    {
        yield return new WaitForSeconds(2);
    }

    public void ChangeRound()
    {
        
        //GM.instance.Changestage Function.


    }

    public void EnemyWasKilled(bool EnemyType)
    {
        if(EnemyType == true)
        {
            FighterNum -= 1;
        }
        else if(EnemyType == false)
        {
            BomberNum -= 1;
        }
    }
}
