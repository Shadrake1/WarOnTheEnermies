using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform enemyFireSpot;

    public GameObject explosion;

    public GameObject currentRoom;

    public GameObject enemyBullet;
    public GameObject enemyBulletRef;

    public Material whiteFlash;
    public Material defaultSprite;

    private float flashTimer = 0f;
    public float endFlash = 0.1f;
    private bool flashTimeStart = false;

    public float Health = 100;
    private float timer = 0f;
    public float shootInterval = 1f;
    public float timeDelay = -1f;

    public AudioClip deadClip;

    public void TakeDamage (float damage)
    {
        if (currentRoom == player.GetComponent<PlayerCamera>().currentRoom)
        {
            Health -= damage;

            GetComponent<Renderer>().material = whiteFlash;
            flashTimeStart = true;

            if (Health < 1)
            {
                Die();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        if (hitinfo.tag == "Cameras")
        {
            currentRoom = hitinfo.gameObject;

        }
        Killbox killbox = hitinfo.GetComponent<Killbox>();
        if (killbox != null)
        {
            Die();
        }

    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 diff = player.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            if (currentRoom == player.GetComponent<PlayerCamera>().currentRoom)
            {
                timer += Time.deltaTime;

                if (timer >= shootInterval)
                {
                    Shoot();
                    timer = 0f;
                }
            }
            else
            {
                timer = timeDelay;
            }

            if (timer >= shootInterval && currentRoom == player.GetComponent<PlayerCamera>().currentRoom)
            {
                Shoot();
                timer = 0f;
            }
        }

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

    void Die()
    {
        AudioScript.Instance.PlaySound(deadClip);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void Shoot()
    {
        Instantiate(enemyBullet, enemyFireSpot.position, enemyFireSpot.rotation);
    }

}
