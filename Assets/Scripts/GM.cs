using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GM : MonoBehaviour
{

    public static bool NotStarted;
    
    //public static event Action ChangeRoundNumber = delegate { };

    //singleton format
    public static GM instance;

    
    void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);

       NotStarted = true;

        //Debug.Log("Game Manager reporting for duty");


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



 
    //will spawn projectiles
   
   
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

 
    public delegate void EndGame();

    public event EndGame Endgame;

    public void EndgameFunction()
    {
        Debug.Log("in GM function to end game");
        Endgame();
        
    }

    public delegate void GameOverEvent();

    public event GameOverEvent GameOver;

    public void PlayerDied()
    {
        GameOver();
    }

    public void ResetGame()
    {
        NotStarted = true;

        

        Debug.Log("Reset game function was called");
        var objects = FindObjectsOfType<MonoBehaviour>().OfType<IObjectPoolNotifier>();

        foreach (var obj in objects)
        {
            Debug.Log(obj);
            //obj.ReturnThisObject();

            GameObject currObj = ((MonoBehaviour)obj).gameObject;

            currObj.ReturnToPool();
        }


    }

   

}
