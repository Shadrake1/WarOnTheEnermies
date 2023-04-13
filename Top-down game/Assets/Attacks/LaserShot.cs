using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    public float speed = 40f;
    public Rigidbody2D rb;

    //public AudioClip hitEnemy;
    public AudioClip shootLaser;

    void Start()
    {
        rb.velocity = transform.up * speed;
        //AudioScript.Instance.PlaySound(shootLaser);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(GameManager.laserDamage);
            //AudioScript.Instance.PlaySound(hitEnemy);
            Destroy(gameObject);
        }
        BossScript boss = hitInfo.GetComponent<BossScript>();
        if (boss != null)
        {
            boss.TakeDamage(GameManager.laserDamage);
            Destroy(gameObject);
        }

        MissleScript missle = hitInfo.GetComponent<MissleScript>();
        if (missle != null)
        {
            missle.TakeDamage(GameManager.laserDamage);
            //AudioScript.Instance.PlaySound(hitEnemy);
            Destroy(gameObject);
        }

        BoxScript chest = hitInfo.GetComponent<BoxScript>();
        if (chest != null)
        {
            chest.TakeDamage(GameManager.laserDamage);
            //AudioScript.Instance.PlaySound(hitEnemy);
            Destroy(gameObject);
        }

        CrateScript box = hitInfo.GetComponent<CrateScript>();
        if (box != null)
        {
            box.TakeDamage(GameManager.bulletDamage);
            //AudioScript.Instance.PlaySound(hitEnemy);
        }

        if (hitInfo.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
