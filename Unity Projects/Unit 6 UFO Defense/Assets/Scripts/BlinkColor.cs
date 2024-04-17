using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkColor : MonoBehaviour
{
    public Color startColor = Color.white;
    public Color endColor = Color.black;
//    [range(0,10)]
    public float speed = 1;
    Renderer ren;
    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ren.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed,1));
    }
}
