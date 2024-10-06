using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    GameObject MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Time.timeScale = 0.0f;
        MainMenu = GameObject.Find("MainMenu");

        MainMenu.SetActive(true);
    }
    public void StartGame()
    {
        GameObject MainUI = GameObject.Find("MainUI");


        ActivatePanel(MainUI);
        DeactivatePanel(MainMenu);

        Time.timeScale = 1.0f;
    }

    public void ActivatePanel(GameObject Panel)
    {

    }

    public void DeactivatePanel(GameObject Panel)
    {

    }

    public void InstructionsScreen()
    {

    }

    public void ExitGame()
    {

    }
    public void PauseScreen()
    {

    }

    public void VictoryScreen()
    {

    }

    public void ReturnToMain()
    {

    }

    public void ChangeRoundValues()
    {
       
    }
}
