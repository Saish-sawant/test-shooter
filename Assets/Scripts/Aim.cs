
using UnityEngine;

public class Aim : MonoBehaviour
{
    // Start is called before the first frame update
   
   public GameObject impactPrefab;
    WeaponPick weaponPick;
   
   private void Start() {
    weaponPick=GetComponent<WeaponPick>();
   }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

   void Shoot()
   {
        RaycastHit hit;

      if ( Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit))
      {
        Debug.Log(hit.transform.name);
        if (weaponPick.currentWeapon !=null && hit.collider.CompareTag("Target"))
        {
          GameObject impact = Instantiate(impactPrefab, hit.point, Quaternion.FromToRotation(Vector3.up,hit.normal));
        Destroy(impact, 2f);
        }
        
      }
   }
}
