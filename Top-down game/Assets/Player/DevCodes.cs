using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCodes : MonoBehaviour
{
    

    void Update()
    {
        if (Input.GetKey("q"))
        {
            GameManager.hasBomb = true;
            GameManager.hasDash = true;
            GameManager.hasLaser = true;
            GameManager.speed = 110;
            GameManager.laserDamage = 0.5f;
            GameManager.maxHealth = 250;
            GameManager.playerHealth = 250;
            GameManager.bulletDamage = 45f;
            
        }
        if (Input.GetKey("e"))
        {
            GameManager.hasBomb = true;
            GameManager.hasDash = true;
            GameManager.hasLaser = true;
            GameManager.speed = 110;
            GameManager.laserDamage = 0.7f;
            GameManager.maxHealth = 390;
            GameManager.playerHealth = 390;
            GameManager.bulletDamage = 52f;

        }
        if (Input.GetKey("m"))
        {
            SaveFunctions save = GetComponent<SaveFunctions>();
            save.SaveGame();
        }
        if (Input.GetKey("l"))
        {
            SaveFunctions save = GetComponent<SaveFunctions>();
            save.LoadGame();
        }
    }
}
