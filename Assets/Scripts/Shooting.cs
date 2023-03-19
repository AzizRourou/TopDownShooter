using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 5f;
    public bool isShooting=false;

    void Update()
    {
        if (isShooting)
        {
            if (!Input.GetMouseButton(0))
            {
                isShooting = false;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                isShooting = true;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
    }
}
