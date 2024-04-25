using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI scoretext;
    public int score;
    private AudioSource bang;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bang = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void increaseScore(int amount){
        score += amount;
        updateScoreText();
        bang.Play();

    }
    public void decreaseScore(int amount){
        score -= amount;
       
        updateScoreText();
        if (score < 0){
            gameManager.EndGame();
        }
    }
    public void updateScoreText(){
        scoretext.text = "Score: " + score;
    }

}
