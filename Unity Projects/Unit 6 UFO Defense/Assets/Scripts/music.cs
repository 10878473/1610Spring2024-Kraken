using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public AudioSource gameMusic;
    // Start is called before the first frame update
    void Start()
    {
        gameMusic = GetComponent<AudioSource>();
        gameMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndMusic(){
        gameMusic.Stop();
    }
}
