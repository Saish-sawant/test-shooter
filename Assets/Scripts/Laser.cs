using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequiredComponent (typeof (LineRenderer))]
public class Laser : MonoBehaviour
{
   private LineRenderer lineRenderer;
   
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer=GetComponent<LineRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
      lineRenderer.SetPosition(0,transform.position);
      RaycastHit laserHit;

       if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out laserHit))
       {
        if(laserHit.collider)
        {
          lineRenderer.SetPosition(1,laserHit.point);
        }
       }
        else
        {
          lineRenderer.SetPosition(1,Camera.main.transform.forward*5000);
        }

       
       
    }
}
