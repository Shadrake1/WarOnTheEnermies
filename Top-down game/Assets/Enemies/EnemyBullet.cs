using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;

    public GameObject currentRoom;

    public AudioClip hitPlayer;
    public AudioClip shootBullet;

    void Start()
    {
        rb.velocity = transform.up * speed;
        AudioScript.Instance.PlaySound(shootBullet);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)


    {
        PlayerStats playerHealth = hitInfo.GetComponent<PlayerStats>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            AudioScript.Instance.PlaySound(hitPlayer);
            Destroy(gameObject);
        }

        CrateScript box = hitInfo.GetComponent<CrateScript>();
        if (box != null)
        {
            box.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (hitInfo.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
