using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform cameraPosition;
    public GameObject currentRoom;
    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        if (hitinfo.tag == "Cameras")
        {
            cameraPosition.position = new Vector3(hitinfo.transform.position.x, hitinfo.transform.position.y, cameraPosition.position.z);
            currentRoom = hitinfo.gameObject;
        }
        
    }

}


