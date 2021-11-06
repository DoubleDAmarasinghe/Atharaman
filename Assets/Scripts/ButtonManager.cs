using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject map;
    public GameObject StartUpUI;
    public GameObject PauseMenuUI;
    public GameObject SureMenuUIExit;
    public GameObject SureMenuUIRestart;
    public GameObject GameOverUI;
    public GameObject RoundWinUI;
    public Button SprintButton;
    public Button ShowMapButton;

    bool isDone = false;
    bool isDone2 = false;

    // Start is called before the first frame update
    void Start()
    {
        //all false menus in the begining
        map.SetActive(false);
        PauseMenuUI.SetActive(false);
        SureMenuUIExit.SetActive(false);
        SureMenuUIRestart.SetActive(false);
        GameOverUI.SetActive(false);
        RoundWinUI.SetActive(false);
        SprintButton.interactable = false;
        ShowMapButton.interactable = false;

        //all true menus in the begining
        StartUpUI.SetActive(true);

        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
       
        SprintAbilityCheckup();
        ShowMapAbilityCheckup();
        CheckTimeLeftZero();
        RoundWinCheckup();
    }

    //using sprint ability
    public void SprintAbility()
    {
        
        StartCoroutine(IncreaseSpeedForSecond());
        GameObject Player = GameObject.Find("Player");
        PlayerController pc = Player.GetComponent<PlayerController>();
        pc.TCoinCount -= 10;
        pc.TCoinScore.GetComponent<Text>().text = pc.TCoinCount + "/30";
      
        SprintButton.interactable = false;
        isDone = false;

        //btbb.interactable = false;


    }

    //using show map ability
    public void ShowMapAbility()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerController pc = Player.GetComponent<PlayerController>();
        pc.GemCoinCount -= 1;
        pc.GemCoinScore.GetComponent<Text>().text = pc.GemCoinCount + "/2";
        
        ShowMapButton.interactable = false;
        //Destroy(map, 2f);
        StartCoroutine(ShowMapForSeconds());
        isDone2 = false;
       
        //btbb.interactable = false;
        


    }

    //Increase playe's speed for some seconds
    IEnumerator IncreaseSpeedForSecond()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerController pc = Player.GetComponent<PlayerController>();
        pc.walkspeed = 10f;
        GameObject tete = GameObject.Find("ProgressbarScript");
       
        
        yield return new WaitForSeconds(5);
        pc.walkspeed = 5f;

        
    }

    //Show map for some seconds
    IEnumerator ShowMapForSeconds()
    {
        map.SetActive(true);
        yield return new WaitForSeconds(3);
        map.SetActive(false);


    }

    public void StartUpUIPlay()
    {
        StartUpUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
    }

    //Resume button function
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
    }

    //Restart button function
    public void ReStartGame()
    {
       
        SureMenuUIRestart.SetActive(true);
    }

    public void ReTryGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartYes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartNo()
    {
        SureMenuUIRestart.SetActive(false);
    }

    //Exit button function
    public void Exit()
    {
        SureMenuUIExit.SetActive(true);
    }

    public void ExitYes()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitNo()
    {
        SureMenuUIExit.SetActive(false);
    }

    //Checking sprint ability can be use or not
    public void SprintAbilityCheckup()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerController pc = Player.GetComponent<PlayerController>();
        if(pc.TCoinCount >= 10 && !isDone)
        {
            
            SprintButton.interactable = true;
            isDone = true;
        }
        
    }

    //checking show map ability can be use or not 
    public void ShowMapAbilityCheckup()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerController pc = Player.GetComponent<PlayerController>();
        if (pc.GemCoinCount >= 1 && !isDone2)
        {

            ShowMapButton.interactable = true;
            isDone2 = true;
            



        }
    }

    public void CheckTimeLeftZero()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerController pc = Player.GetComponent<PlayerController>();
        if(pc.TimeLeft == 0)
        {
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
        }

    }

    public void RoundWinCheckup()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerController pc = Player.GetComponent<PlayerController>();
        if(pc.GCoinCount == 5)
        {
            Time.timeScale = 0f;
            RoundWinUI.SetActive(true);
        }
    }

}
