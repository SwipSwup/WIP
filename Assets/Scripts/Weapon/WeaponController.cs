using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponStats stats;
    [SerializeField] private Transform muzzleEnd;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            //Debug.DrawRay(muzzleEnd.position, transform.right * 100f);
            if(Physics.Raycast(transform.position, transform.right, out hit, 100f))
            {
                Debug.Log("pew");
                GameObject go_bullet = Instantiate(bullet, muzzleEnd.position, muzzleEnd.rotation);
                go_bullet.GetComponent<Bullet>().targetPos = hit.point;
            } else
            {
                GameObject go_bullet = Instantiate(bullet, muzzleEnd.position, muzzleEnd.rotation);
                go_bullet.GetComponent<Bullet>().targetPos = transform.position + transform.right * stats.maxRange;
            }
        }
    }

    private void FireWeapon()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(muzzleEnd.position, .05f);
    }
}
