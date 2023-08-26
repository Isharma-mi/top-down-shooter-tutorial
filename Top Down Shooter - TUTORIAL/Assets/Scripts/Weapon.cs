using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    #region Variables
    [SerializeField] float fireForce = 20.0f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    #endregion Variables

    public void Fire()
    {
        // Spawns bullet at end of weapon
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Makes bullet shoot 
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
