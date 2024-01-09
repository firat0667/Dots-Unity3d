using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPopup : MonoBehaviour
{
    private void OnEnable()
    {
        transform.parent = null;
    }
    private float destoyTimer = 1f;

    private void Update()
    {
        float moveSpeed = 2f;
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        destoyTimer-=Time.deltaTime;
        if(destoyTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
