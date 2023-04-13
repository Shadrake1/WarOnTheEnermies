using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Transform fireSpot;
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GameManager.gameIsPaused == false)
        {
            Shoot();
        }
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, fireSpot.position, fireSpot.rotation);
    }
}
