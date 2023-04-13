using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    public float Health = 1;
    public GameObject drop;
    public bool dead = false;

    public Material whiteFlash;
    public Material defaultSprite;

    private float flashTimer = 0f;
    public float endFlash = 0.1f;
    private bool flashTimeStart = false;

    public AudioClip breakBox;

    public void TakeDamage(float damage)
    {
        GetComponent<Renderer>().material = whiteFlash;
        flashTimeStart = true;

        Health -= damage;

        if (Health < 0 && dead == false)
        {
            dead = true;
            Die();
        }
    }

    void Die()
    {
        AudioScript.Instance.PlaySound(breakBox);
        Instantiate(drop, transform.position, Quaternion.identity);
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
