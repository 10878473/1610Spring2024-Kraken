using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition; //gets screen position of mouse
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);//Shoots a beam from camera to mouse point
        if (Physics.Raycast(ray, out RaycastHit hitData)){
            worldPosition = hitData.point;
        }
        transform.position = worldPosition;
    
    }
}

