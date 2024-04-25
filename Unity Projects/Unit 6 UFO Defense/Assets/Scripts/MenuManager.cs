using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public int scenetoload;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(){
        SceneManager.LoadScene(scenetoload);
        Debug.Log("Game started");
        
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Game Quit");

    }
}
