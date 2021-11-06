using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }
    public void StartGame2()
    {
        SceneManager.LoadScene("SecondLevel");
    }

    public void StartGame3()
    {
        SceneManager.LoadScene("ThirdLevel");
    }

    public void Exitfromgame()
    {
        Application.Quit();
    }
}
