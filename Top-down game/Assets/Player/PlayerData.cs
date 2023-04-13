using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public float playerHealth;
    public float maxHealth;
    public float speed;
    public float bulletDamage;
    public float laserDamage;
    public bool hasDash;
    public bool hasBomb;
    public bool hasLaser;

    public float[] position;
    public float gameTimer;

    public List<int> chestsOpened;
    public List<int> targetsBroken;

    public string currentLevel;


    public PlayerData (SaveFunctions player)
    {
        playerHealth = GameManager.playerHealth;
        maxHealth = GameManager.maxHealth;
        speed = GameManager.speed;
        bulletDamage = GameManager.bulletDamage;
        laserDamage = GameManager.laserDamage;
        hasDash = GameManager.hasDash;
        hasBomb = GameManager.hasBomb;
        hasLaser = GameManager.hasLaser;

        gameTimer = GameManager.gameTimer;

        chestsOpened = GameManager.chests;
        targetsBroken = GameManager.target;

        currentLevel = SceneManager.GetActiveScene().name;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
