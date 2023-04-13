using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject switchWall;
    public int targetID;

    public AudioClip breakTarget;

    private void Start()
    {
        if (GameManager.target.Contains(targetID))
        {
            Destroy(switchWall);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        LaserShot laser = hitinfo.GetComponent<LaserShot>();
        if (laser != null)
        {
            GameManager.target.Add(targetID);
            AudioScript.Instance.PlaySound(breakTarget);
            Destroy(switchWall);
            Destroy(gameObject);
        }
    }
}
