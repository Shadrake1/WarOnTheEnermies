using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsScript : MonoBehaviour
{
    public Transform warpDestination;
    public Transform player;

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        PlayerCollision enterWarp = hitinfo.GetComponent<PlayerCollision>();
        if (enterWarp != null)
        {
            player.position = warpDestination.position;
        }

    }

}
