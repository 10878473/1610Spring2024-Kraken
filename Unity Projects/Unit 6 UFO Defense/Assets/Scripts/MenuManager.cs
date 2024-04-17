using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public bool GameStarted;

    // Start is called before the first frame update
    void Start()
    {
        GameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame(){
        GameStarted = false;
        
        
    }
    void QuitGame(){
        Application.Quit();
    }
}
