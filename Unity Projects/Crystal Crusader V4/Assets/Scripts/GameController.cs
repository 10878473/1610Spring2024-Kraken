using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //UI manager, Takes input from buttons, hides, and shows gameoverscreen
    public GameObject gameovertext;
    public GameObject quitbutton;
    public PlayerController PlayerController;
    void Start()
    {
        Time.timeScale = 1;

        PlayerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        gameovertext.SetActive(false);
        quitbutton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.hp <= 0){
            Time.timeScale = 0;
            gameovertext.SetActive(true);
            quitbutton.SetActive(true);

        }
    }
    void QuitGame(){
        Application.Quit();
    }
}
