using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int bombCount = 0;
    public static float bulletDamage = 10f;
    public static float laserDamage = 0.2f;
    public static float playerHealth = 50f;
    public static float maxHealth = 50f;

    public static float speed = 30f;
    public static float dashSpeed = 6000f;

    public static bool hasBomb = false;
    public static bool hasDash = false;
    public static bool hasLaser = false;
    public static bool isDashing = false;

    public static Vector2 spawnPosition;
    public static bool setSpawn = false;

    public static List<int> chests = new List<int>();
    public static List<int> target = new List<int>();


    public static bool gameStart = false;
    public static float gameTimer = 0f;

    public static bool gameEnded = false;

    public static bool newGame = false;

    public static bool bossFightStart = false;

    public static bool doorSave = false;

    public static bool gameIsPaused = false;

    private void Update()
    {

    }

}
