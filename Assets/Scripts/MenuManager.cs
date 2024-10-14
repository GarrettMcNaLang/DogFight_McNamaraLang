using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    

    GameObject MainMenu;

    GameObject MainUI;

    GameObject Stage;

    GameObject CanvasRef;

    GameObject pauseScreen;

    GameObject instructions;

    public TextMeshProUGUI bomberText;

    public TextMeshProUGUI fighterText;

    public TextMeshProUGUI playerLives;

    bool EscAxis;

    roundManager RMreference;

    GameObject PlayerRef;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EscAxis |= Input.GetKey(KeyCode.Escape);

        if(EscAxis )
        {
            PauseScreen();
        }
        EscAxis = false;

       
    }

    private void OnEnable()
    {
        GM.instance.Playerhealthtransmit += ChangeHealth;

        GM.instance.Fightertransmit += ChangeFighterCount;

        GM.instance.Bombertransmit += ChangeBomberCount;

        GM.instance.Changestage += ChangeRoundNum;
    }

    private void OnDisable()
    {
        GM.instance.Playerhealthtransmit -= ChangeHealth;

        GM.instance.Fightertransmit -= ChangeFighterCount;

        GM.instance.Bombertransmit -= ChangeBomberCount;

        GM.instance.Changestage -= ChangeRoundNum;
    }

    private void Awake()
    {

        
        Time.timeScale = 0.0f;
        CanvasRef = GameObject.Find("Canvas");

        MainMenu = CanvasRef.transform.Find("MainMenu").gameObject;

        MainUI = CanvasRef.transform.Find("MainUI").gameObject;

        Stage = CanvasRef.transform.Find("Stage").gameObject;

        pauseScreen = CanvasRef.transform.Find("PauseMenu").gameObject;

        instructions = CanvasRef.transform.Find("Instructions").gameObject;

      

        if (MainMenu == null)
            Debug.Log("MainMenuEmpty");


     


       
        Debug.Log("MenuManager Reporting for duty");
        MainMenu.SetActive(true);
    }

   
    public void StartGame()
    {
        

        GM.instance.StartRoundManager();

        ActivatePanel(MainUI);
        DeactivatePanel(MainMenu);

        Time.timeScale = 1.0f;
        // ChangeUI();

        Debug.Log("has left function");
        
    }

    public void ChangeHealth(int NewHealth)
    {
        playerLives.text = "Player Lives: " + NewHealth;
    }

    public void ChangeBomberCount(int Newbomber)
    {
        bomberText.text = "Bombers: " + Newbomber;

    }

    public void ChangeFighterCount(int NewFighter)
    {
        fighterText.text = "Fighters: " + NewFighter;

    }

    public void ChangeRoundNum(int newRoundNum)
    {
        var StageText = Stage.transform.Find("Stage Insert").GetComponent<TextMeshProUGUI>();


        Stage.SetActive(true);


        StageText.text = "Stage " + newRoundNum;

       

        StartCoroutine(WaitAndCheck());

        
    }




    IEnumerator WaitAndCheck()
    {
        Debug.Log("Will Waait then start game");
        //counting to until avaialabe
        yield return new WaitForSeconds(5);

        Stage.SetActive(false);
       

    }

    public void ActivatePanel(GameObject Panel)
    {
        if(Panel == null)
        {
            Debug.Log("No argument given in Activate Panel");
        }
        Panel.SetActive(true);
    }

    public void DeactivatePanel(GameObject Panel)
    {
        Panel.SetActive(false);
    }

    public void InstructionsScreen()
    {
       


        ActivatePanel(instructions);
        DeactivatePanel(MainMenu);
    }

    public void ExitGame()
    {
        Debug.Log("ExitingGame and uncoupling events");
        Application.Quit();
    }
    public void PauseScreen()
    {
        
        ActivatePanel(pauseScreen);

        Time.timeScale = 0.0f;

        
    }

    public void Resume()
    {

        Debug.Log("Should unpause");
        DeactivatePanel(pauseScreen);

        Time.timeScale = 1.0f;
    }

    public void VictoryScreen()
    {
        GameObject victory = GameObject.Find("VictoryScreen");

        ActivatePanel(victory);
    }

    public void ReturnToMain()
    {
        ActivatePanel(MainMenu);
        DeactivatePanel(instructions);
        DeactivatePanel(pauseScreen);

    }

   
}
