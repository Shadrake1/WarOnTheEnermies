using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    public float timer = 0;
    public float disappear = 1;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > disappear)
        {
            Destroy(gameObject);
        }
    }
}
