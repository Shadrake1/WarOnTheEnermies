using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlace : MonoBehaviour
{
    public GameObject bomb;
    public Transform bombspot;
    void Update()
    {
        if (Input.GetButtonDown("Fire3") && GameManager.bombCount < 3 && GameManager.gameIsPaused == false)
        {
            Instantiate(bomb, bombspot.position, bombspot.rotation);
            GameManager.bombCount += 1;
        }
    }
}
