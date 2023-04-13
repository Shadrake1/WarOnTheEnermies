using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public GameObject explosion;
    public Transform enemyFireSpot1;
    public Transform enemyFireSpot2;
    public Transform enemyFireSpot3;
    public Transform enemyFireSpot4;
    public Transform enemyFireSpotNew1;
    public Transform enemyFireSpotNew2;
    public Transform enemyFireSpotNew3;
    public GameObject wall;

    public GameObject enemyBullet1;
    public GameObject enemyMissle1;
    public GameObject enemyBullet2;
    public GameObject enemyMissle2;
    public GameObject enemyBullet3;
    public GameObject enemyMissle3;


    public HealthBar healthbar;
    public GameObject bossBar;
    public float bossHealth = 80000f;
    private float bulletTimer = 0f;
    public float shootBulletInterval = 1f;
    private float missleTimer = 0f;
    public float shootMissleInterval = 1.5f;

    private float fightStartTimer = 0f;
    private float fightStart = 8f;
    private int currentPhase = 0;

    public AudioClip deadSound;

    public void TakeDamage(float damage)
    {
        if (currentPhase > 0)
        {
            bossHealth -= damage;
            healthbar.SetBossHealth(bossHealth);
        }

        if (bossHealth < 1)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
        {

            if (currentPhase > 0)
            {
                bossBar.SetActive(true);
                bulletTimer += Time.deltaTime;
                missleTimer += Time.deltaTime;

                if (bulletTimer >= shootBulletInterval && currentPhase == 1)
                {
                    ShootBullet();
                    bulletTimer = 0f;
                }

                if (missleTimer >= shootMissleInterval && currentPhase == 1)
                {
                    ShootMissle();
                    missleTimer = 0f;
                }

                if (bulletTimer >= shootBulletInterval && currentPhase == 2)
                {
                    ShootBullet2();
                    bulletTimer = 0f;
                }

                if (missleTimer >= shootMissleInterval && currentPhase == 2)
                {
                    ShootMissle2();
                    missleTimer = 0f;
                }

                if (bulletTimer >= shootBulletInterval && currentPhase == 3)
                {
                    ShootBullet3();
                    bulletTimer = 0f;
                }

                if (missleTimer >= shootMissleInterval && currentPhase == 3)
                {
                    ShootMissle3();
                    missleTimer = 0f;
                }
                
            }

        }

        if (GameManager.bossFightStart == true)
        {
            if (currentPhase == 0)
            {
                rb.AddForce(Vector2.down * 100000);
            }
            wall.transform.position = new Vector3(0.03f, 60.86f, 0f);
            fightStartTimer += Time.deltaTime;
            if (fightStartTimer >= fightStart && currentPhase == 0)
            {
                currentPhase += 1;
            }
        }
        if (bossHealth <= 62000f && bossHealth >= 30000f)
        {
            currentPhase = 2;
        }
        if (bossHealth <= 29999f)
        {
            currentPhase = 3;
        }
    }

    void Die()
    {
        GameManager.gameEnded = true;
        AudioScript.Instance.PlaySound(deadSound);
        bossBar.SetActive(false);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void ShootBullet()
    {
        Instantiate(enemyBullet1, enemyFireSpot1.position, enemyFireSpot1.rotation);
        Instantiate(enemyBullet1, enemyFireSpot2.position, enemyFireSpot2.rotation);
        if (bossHealth <= 72000f)
        {
            Instantiate(enemyBullet1, enemyFireSpotNew1.position, enemyFireSpotNew1.rotation);
        }
    }
    void ShootMissle()
    {
        Instantiate(enemyMissle1, enemyFireSpot3.position, enemyFireSpot3.rotation);
        Instantiate(enemyMissle1, enemyFireSpot4.position, enemyFireSpot4.rotation);
    }

    void ShootBullet2()
    {
        Instantiate(enemyBullet2, enemyFireSpot1.position, enemyFireSpot1.rotation);
        Instantiate(enemyBullet2, enemyFireSpot2.position, enemyFireSpot2.rotation);
        Instantiate(enemyBullet2, enemyFireSpotNew1.position, enemyFireSpotNew1.rotation);
        if (bossHealth <= 49000f)
        {
            Instantiate(enemyBullet2, enemyFireSpotNew2.position, enemyFireSpotNew2.rotation);
        }
    }
    void ShootMissle2()
    {
        Instantiate(enemyMissle2, enemyFireSpot3.position, enemyFireSpot3.rotation);
        Instantiate(enemyMissle2, enemyFireSpot4.position, enemyFireSpot4.rotation);
    }

    void ShootBullet3()
    {
        Instantiate(enemyBullet3, enemyFireSpot1.position, enemyFireSpot1.rotation);
        Instantiate(enemyBullet3, enemyFireSpot2.position, enemyFireSpot2.rotation);
        Instantiate(enemyBullet3, enemyFireSpotNew1.position, enemyFireSpotNew1.rotation);
        Instantiate(enemyBullet3, enemyFireSpotNew2.position, enemyFireSpotNew2.rotation);
        if (bossHealth <= 15000f)
        {
            Instantiate(enemyBullet3, enemyFireSpotNew3.position, enemyFireSpotNew3.rotation);
        }
    }
    void ShootMissle3()
    {
        Instantiate(enemyMissle3, enemyFireSpot3.position, enemyFireSpot3.rotation);
        Instantiate(enemyMissle3, enemyFireSpot4.position, enemyFireSpot4.rotation);
    }

}

namespace bossui
{
    class SetActive
    {
    }
}