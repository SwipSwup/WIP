using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int maxDistance = 100;
    public Vector3 targetPos;


    private void Awake()
    {
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, targetPos - transform.forward * 10f);
        transform.position += targetPos - transform.position * 0.2f;
        if (Vector3.Distance(targetPos, transform.position) < 1f)
            Destroy(gameObject);
    }
}
