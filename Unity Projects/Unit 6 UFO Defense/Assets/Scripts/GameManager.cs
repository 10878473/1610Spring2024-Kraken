using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject gameoverText;
    private GameObject quitbutton;

    public bool isgameOver;
    // Start is called before the first frame update
    void Start()
    {        
        gameoverText = GameObject.Find("GameOverText");
        quitbutton = GameObject.Find("Quit");

        isgameOver = false;
        Time.timeScale = 1;//starts game, hides gameover text
        //isgameOver=false;
        gameoverText.SetActive(false);
        quitbutton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndGame(){
        isgameOver = true;
        gameoverText.SetActive(true);
        quitbutton.SetActive(true);
        Time.timeScale = 0;
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
