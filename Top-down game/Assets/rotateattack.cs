using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateattack : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform player;
    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 diff = player.position - transform.position;
            diff.Normalize();


            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }
}
