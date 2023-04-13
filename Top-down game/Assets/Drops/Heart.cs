using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float healing = 20f;
    public HealthBar healthBar;
    public PlayerStats playerStats;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerStats playerHealth = hitInfo.GetComponent<PlayerStats>();
        if (playerHealth != null)
        {
            playerHealth.Heal(healing);
            Destroy(gameObject);
        }
    }
}
