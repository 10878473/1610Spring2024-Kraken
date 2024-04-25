using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject gameoverText;
    private GameObject quitbutton;
    public AudioSource badBang;
    public bool isgameOver;
    public music musicplayer;
    // Start is called before the first frame update
    void Start()
    {        
        musicplayer = GameObject.Find("MusicManager").GetComponent<music>();
        badBang = gameObject.GetComponent<AudioSource>();
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
        badBang.Play();
        musicplayer.EndMusic();
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
