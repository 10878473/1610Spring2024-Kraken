using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoretext;
    public GameObject bossText;
    public bool BossTime;
    private bool flashBossText;
    private bool bossTextFlashing;
    public GameObject Boss; 
    public GameObject bossHPText;       
    // Start is called before the first frame update
    void Start()
    {
        bossHPText.SetActive(false);
        Boss.SetActive(false);

        bossText.SetActive(false);
        BossTime = false;
        score = 0;
        increaseScore(100);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (bossTextFlashing)
        {
            if (flashBossText){
                bossText.SetActive(!bossText.activeInHierarchy);
                flashBossText = false;
                StartCoroutine("textCooldown");

            }
        }
        
    }
    public void increaseScore(int amount){
        score += amount;
        updateScoreText();
        if (score > 200)
        {
            bossHPText.SetActive(true);
            Boss.SetActive(true);
            BossTime = true; // this will stop enemies from spawning, and blow up all enemies currently on the stage.
            bossTextFlashing = true; 
            StartCoroutine("flashingCooldown");
        }
        //bang.Play();

    }
    public void decreaseScore(int amount){
        score -= amount;
       
        updateScoreText();
        if (score < 0){
            //gameManager.EndGame();
        }
    }
    public void updateScoreText(){
        scoretext.text = "Score: " + score;
    }
    IEnumerator textCooldown(){
        yield return new WaitForSeconds(1);
        flashBossText = true;
    }
    
    IEnumerator flashingCooldown(){
        yield return new WaitForSeconds(4);
        bossTextFlashing = false;
    }
}
