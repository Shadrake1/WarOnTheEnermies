using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float timer = 0f;
    public float detonateInterval = 3f;
    public float speed = 3f;
    public float damage = 50f;
    public float explosionForce = 700f;
    public int blastSize = 5;

    public int explosionVisualSize = 5;
    public Rigidbody2D rb;

    public GameObject explosionEffect;

    public AudioClip explosionSound;
    public AudioClip shootBomb;

    private void Start()
    {
        rb.velocity = transform.up * speed;
        AudioScript.Instance.PlaySound(shootBomb);
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > detonateInterval)
        {
            Detonate();
        }

    }

    private void OnCollisionEnter2D(Collision2D hitinfo)
    {
        if (hitinfo.collider.tag == "Missle")
        {
            Detonate();
        }
        
    }

    public void Detonate() 
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        AudioScript.Instance.PlaySound(explosionSound);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastSize);
        foreach (Collider2D nearbyObject in colliders)
        {
            BombScript bombScript = nearbyObject.GetComponent<BombScript>();
            if (bombScript != null)
            {

            }
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.AddForce(transform.position - rb.transform.position * explosionForce);
                }
            PlayerStats playerHealth = nearbyObject.GetComponent<PlayerStats>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Enemy enemy = nearbyObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            BossScript boss = nearbyObject.GetComponent<BossScript>();
            if (boss != null)
            {
                boss.TakeDamage(GameManager.bulletDamage);
            }
            BoxScript chest = nearbyObject.GetComponent<BoxScript>();
            if (chest != null)
            {
                chest.TakeDamage(damage);
            }
            CrateScript box = nearbyObject.GetComponent<CrateScript>();
            if (box != null)
            {
                box.TakeDamage(damage);
            }

            rockscript rock = nearbyObject.GetComponent<rockscript>();
            if (rock != null)
            {
                Destroy(nearbyObject.gameObject);
            }
            LaserShot laser = nearbyObject.GetComponent<LaserShot>();
            if (laser != null)
            {
                Destroy(laser);
            }

        }

        GameManager.bombCount -= 1;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Bullet bullet = hitinfo.GetComponent<Bullet>();
        if (bullet != null)
        {
            Detonate();
        }
        MissleScript missle = hitinfo.GetComponent<MissleScript>();
        if (missle != null)
        {
            Detonate();
        }
        Killbox killbox = hitinfo.GetComponent<Killbox>();
        if (killbox != null)
        {
            GameManager.bombCount -= 1;
            Destroy(gameObject);
        }
    }


}
