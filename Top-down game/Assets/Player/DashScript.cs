using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform player;
    public float timer = 0f;

    public AudioClip dashSound;
    void FixedUpdate()
    {
        if (Input.GetKey("left shift") && GameManager.isDashing == false && GameManager.gameIsPaused == false)
        {
            Dash();
        }
        if (GameManager.isDashing == true)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 0.5)
        {
            timer = 0;
            GameManager.isDashing = false;
        }
    }
    void Dash ()
    {
        GameManager.isDashing = true;
        AudioScript.Instance.PlaySound(dashSound);
        rb.AddForce(transform.up * GameManager.dashSpeed);
    }
}
