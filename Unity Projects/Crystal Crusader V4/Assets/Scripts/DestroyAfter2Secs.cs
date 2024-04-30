using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter2Secs : MonoBehaviour
{
    private bool deletethis;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake(){
        StartCoroutine("TimedDelete");
    }

    // Update is called once per frame
    void Update()
    {
       if (deletethis)
       {
        Destroy(gameObject);
       } 
    }
    IEnumerator TimedDelete(){
        yield return new WaitForSeconds(2);
        deletethis = true;
    }
}
