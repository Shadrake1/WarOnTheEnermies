using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleScript : MonoBehaviour
{
    public Transform player;
    public GameObject currentRoom;
    public Rigidbody2D rb;
    public float speed = 3f;
    public float damage = 30f;
    public float health = 30f;

    public Material whiteFlash;
    public Material defaultSprite;

    private float flashTimer = 0f;
    public float endFlash = 0.1f;
    private bool flashTimeStart = false;

    public float explosionForce = 700f;
    public int blastSize = 5;

    public int explosionVisualSize = 5;
    public GameObject explosionEffect;

    public AudioClip missleLaunch;
    public AudioClip missleExplode;
    private void Start()
    {
        rb.velocity = transform.up * speed;
        AudioScript.Instance.PlaySound(missleLaunch);
    }

    public void TakeDamage(float damageTaken)
    {
        GetComponent<Renderer>().material = whiteFlash;
        flashTimeStart = true;

        health -= damageTaken;
        if (health < 1)
        {
            Detonate();
        }
    }


    private void OnCollisionEnter2D(Collision2D hitinfo)
    {
        Detonate();
    }

    public void Detonate()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        AudioScript.Instance.PlaySound(missleExplode);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastSize);
        foreach (Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce((rb.transform.position - transform.position) * explosionForce, ForceMode2D.Impulse);
                //Debug.DrawRay(transform.position, rb.transform.position - transform.position * explosionForce, Color.red, 10);
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
            CrateScript box = nearbyObject.GetComponent<CrateScript>();
            if (box != null)
            {
                box.TakeDamage(damage);
            }
            LaserShot laser = nearbyObject.GetComponent<LaserShot>();
            if (laser != null)
            {
                Destroy(laser);
            }

        }
        Destroy(gameObject);

    }

    private void Update()
    {
        if (flashTimeStart == true)
        {
            flashTimer += Time.deltaTime;

            if (flashTimer >= endFlash)
            {
                GetComponent<Renderer>().material = defaultSprite;
                flashTimeStart = false;
                flashTimer = 0f;
            }
        }
    }
}