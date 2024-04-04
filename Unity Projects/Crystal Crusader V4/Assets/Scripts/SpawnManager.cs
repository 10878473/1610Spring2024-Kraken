using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] meteors;
    public GameObject spiker;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(meteors[Random.Range(0,meteors.Length)], pointInZone(),Random.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 pointInZone(){
        Vector3 point = new Vector3(Random.insideUnitCircle.x * 40, Random.insideUnitCircle.y * 25, Random.Range(400,500));
        return point;
    }
    //Spawn area X/Y -150 to 150 Z 400-500
    
    
}
