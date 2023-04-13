using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public Transform player;
    public GameObject currentRoom;

    public AudioClip gethitBullet;
    public AudioClip shootBullet;
    public AudioClip hitWood;

    void Start()
    {
        rb.velocity = transform.up * speed;
        AudioScript.Instance.PlaySound(shootBullet);
    }


    private void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.tag == "Cameras")
        {
            currentRoom = hitInfo.gameObject;

        }
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(GameManager.bulletDamage);
            AudioScript.Instance.PlaySound(gethitBullet);
            Destroy(gameObject);
        }
        BossScript boss = hitInfo.GetComponent<BossScript>();
        if (boss != null)
        {
            boss.TakeDamage(GameManager.bulletDamage);
            Destroy(gameObject);
        }

        BoxScript chest = hitInfo.GetComponent<BoxScript>();
        if (chest != null)
        {
            chest.TakeDamage(GameManager.bulletDamage);
            AudioScript.Instance.PlaySound(hitWood);
            Destroy(gameObject);
        }

        CrateScript box = hitInfo.GetComponent<CrateScript>();
        if (box != null)
        {
            box.TakeDamage(GameManager.bulletDamage);
            Destroy(gameObject);
        }

        MissleScript missle = hitInfo.GetComponent<MissleScript>();
        if (missle != null)
        {
            missle.TakeDamage(GameManager.bulletDamage);
            AudioScript.Instance.PlaySound(gethitBullet);
            Destroy(gameObject);
        }

        BombScript bombScript = hitInfo.GetComponent<BombScript>();
        if (bombScript != null)
        {
            Destroy(gameObject);
        }


        if (hitInfo.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
