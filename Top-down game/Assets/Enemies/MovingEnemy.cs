using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform point1;
    public Transform point2;
    public float speed = 30f;

    private int direction = 1;
    private float position = 0;

    void Start()
    {
        point1.SetParent(null);
        point2.SetParent(null);
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(point1.position, point2.position, position);
        position += speed * Time.deltaTime * direction;
        position = Mathf.Clamp(position, 0, 1);
        if (position <= 0 || position >= 1)
            direction *= -1;
    }
}

