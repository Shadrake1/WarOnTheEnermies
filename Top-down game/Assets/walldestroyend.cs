using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walldestroyend : MonoBehaviour
{
    public Transform wall1;
    public Transform wall2;
    public Transform wall3;
    public Transform wall4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCollision player = GetComponent<PlayerCollision>();
        if (player != null)
        {
            Destroy(wall1);
            Destroy(wall2);
            Destroy(wall3);
            Destroy(wall4);
        }
    }
}
