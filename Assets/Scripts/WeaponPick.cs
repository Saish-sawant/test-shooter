using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPick : MonoBehaviour
{
   public Transform equipPosition;
   public float distance =10f;
   public GameObject currentWeapon;
   GameObject wp; 
   public GameObject Laser;
   Aim aim;
   
   bool canGrab;

   private void Start() {
    aim=GetComponent<Aim>();
   }
    
    private void Update() 
    {
      CheckWeapon();

      if (canGrab)
      {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentWeapon!=null)
            {Drop();}
        PickUp();
        }
       }
       
        if( currentWeapon!=null)
      {
        if(Input.GetKeyDown(KeyCode.Q))
       {
         Drop();
       }
      }

    }
    
      private void CheckWeapon()
   {
    RaycastHit hit;

    if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,distance))
    {
        if(hit.transform.tag=="Can Grab")
        {
            Debug.Log("grab it hard");
            canGrab=true;
            wp = hit.transform.gameObject;
        }

        else
        canGrab=false;
    }
   }

   private void PickUp()
   {
    Laser.SetActive(true);
    currentWeapon=wp;
    currentWeapon.transform.position=equipPosition.position;
    currentWeapon.transform.parent=equipPosition;
    currentWeapon.transform.localEulerAngles=new Vector3(0f,0f,0f);
    currentWeapon.GetComponent<Rigidbody>().isKinematic= true;
   }

   private void Drop()
   {
    Laser.SetActive(false);
    currentWeapon.transform.parent=null;
    currentWeapon.GetComponent<Rigidbody>().isKinematic=false;
    currentWeapon=null;
   }
}
