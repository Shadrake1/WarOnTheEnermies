using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserShoot : MonoBehaviour
{
    public Transform laserFireSpot1;
    public Transform laserFireSpot2;
    public GameObject laserPrefab;

    public AudioClip laserSound;
    void Update()
    {
        if (Input.GetButton("Fire2") && GameManager.gameIsPaused == false)
        {
            LaserShoot();
        }
    }
    void LaserShoot()
    {
        Instantiate(laserPrefab, laserFireSpot1.position, laserFireSpot1.rotation);
        Instantiate(laserPrefab, laserFireSpot2.position, laserFireSpot2.rotation);
    }
}

