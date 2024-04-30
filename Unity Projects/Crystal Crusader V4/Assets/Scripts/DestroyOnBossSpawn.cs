using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBossSpawn : MonoBehaviour
{
    public ScoreManager ScoreManager;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = GameObject.Find("ManagersGoHere").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.BossTime){
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }
    }
}
