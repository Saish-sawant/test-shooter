using UnityEngine;

public class GunHit : MonoBehaviour
{
    public GameObject impactPrefab;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject impact = Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1f);
        }
    }
}