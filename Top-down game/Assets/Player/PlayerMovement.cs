using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timer = 0f;

    public Text infoText;
    public Image textbg;

    public AudioClip statup;

    private float uiTimer = 0f;
    public float uiTimerEnd = 5f;
    private bool uitimerStart = false;

    void FixedUpdate()
    {
        if (GameManager.isDashing == false)
        {
            if (Input.GetKey("w"))
            {
                rb.AddForce(Vector2.up * GameManager.speed);
            }
            if (Input.GetKey("s"))
            {
                rb.AddForce(Vector2.down * GameManager.speed);
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(Vector2.left * GameManager.speed);
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(Vector2.right * GameManager.speed);
            }
        }

        if (uitimerStart == true)
        {
            uiTimer += Time.deltaTime;
            if (uiTimer > uiTimerEnd)
            {
                infoText.enabled = false;
                textbg.enabled = false;
                uiTimer = 0f;
                uitimerStart = false;
            }
        }


        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Speedup speedup = hitinfo.GetComponent<Speedup>();
        if (speedup != null)
        {
            GameManager.speed += 8f;

            textbg.enabled = true;
            infoText.enabled = true;
            infoText.text = "SPEED UP!";
            uitimerStart = true;

            AudioScript.Instance.PlaySound(statup);

            Destroy(hitinfo.gameObject);
        }

        waterScript water = hitinfo.GetComponent<waterScript>();
        if (water != null)
        {
            GameManager.speed = GameManager.speed / 2;
        }
    }

    private void OnTriggerExit2D(Collider2D hitinfo)
    {
        waterScript water = hitinfo.GetComponent<waterScript>();
        if (water != null)
        {
            GameManager.speed = GameManager.speed * 2;
        }
    }

}
