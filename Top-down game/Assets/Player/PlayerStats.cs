using UnityEngine.UI;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject explosion;
    public GameObject gameOverScreen;

    public Material whiteFlash;
    public Material defaultSprite;

    public Rigidbody2D player;

    public HealthBar healthBar;

    public Text infoText;
    public Image textbg;

    private float uiTimer = 0f;
    public float uiTimerEnd = 5f;
    private bool uitimerStart = false;

    private float flashTimer = 0f;
    public float endFlash = 0.1f;
    private bool flashTimeStart = false;

    public AudioClip statup;

    public bool isPaused = false;


    private void Start()
    {
        healthBar.SetMaxHealth(GameManager.maxHealth);
        healthBar.SetHealth(GameManager.playerHealth);
        GameManager.gameStart = true;
        if (GameManager.newGame == true)
        {
            textbg.enabled = true;
            infoText.enabled = true;
            infoText.text = "WASD TO MOVE, LEFT-CLICK TO SHOOT";
            uitimerStart = true;
            uiTimerEnd = 5f;
            GameManager.newGame = false;
        }
    }
    public void TakeDamage(float damage)
    {
        GameManager.playerHealth -= damage;
        healthBar.SetHealth(GameManager.playerHealth);

        GetComponent<Renderer>().material = whiteFlash;
        flashTimeStart = true;

        if (GameManager.playerHealth < 1 && GameManager.gameEnded == false)
        {
            Die();
        }
    }

    public void Heal (float healing)
    {
        GameManager.playerHealth += healing;

        if (GameManager.playerHealth > GameManager.maxHealth)
        {
            GameManager.playerHealth = GameManager.maxHealth;
        }
        healthBar.SetHealth(GameManager.playerHealth);
    }
    void Die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        gameOverScreen.SetActive(true);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Killbox killbox = hitinfo.GetComponent<Killbox>();
        if (killbox != null && GameManager.isDashing == false)
        {
            Die();
        }

        healthplus healthplus = hitinfo.GetComponent<healthplus>();
        if (healthplus != null)
        {
            GameManager.maxHealth += 10f;
            GameManager.playerHealth = GameManager.maxHealth;
            healthBar.SetMaxHealth(GameManager.maxHealth);
            healthBar.SetHealth(GameManager.playerHealth);

            textbg.enabled = true;
            infoText.enabled = true;
            infoText.text = "HEALTH UP!";
            uitimerStart = true;
            uiTimerEnd = 2.5f;

            AudioScript.Instance.PlaySound(statup);

            Destroy(hitinfo.gameObject);
        }

        bulletstrengthplus bulletstrengthplus = hitinfo.GetComponent<bulletstrengthplus>();
        if (bulletstrengthplus != null)
        {
            GameManager.bulletDamage += 3.5f;

            textbg.enabled = true;
            infoText.enabled = true;
            infoText.text = "SHOT STRENGTH UP!";
            uitimerStart = true;
            uiTimerEnd = 2.5f;

            AudioScript.Instance.PlaySound(statup);

            Destroy(hitinfo.gameObject);
        }

        laserstrengthplus laserstrengthplus = hitinfo.GetComponent<laserstrengthplus>();
        if (laserstrengthplus != null)
        {
            GameManager.laserDamage += 0.1f;

            textbg.enabled = true;
            infoText.enabled = true;
            infoText.text = "LASER STRENGTH UP!";
            uitimerStart = true;
            uiTimerEnd = 2.5f;

            AudioScript.Instance.PlaySound(statup);

            Destroy(hitinfo.gameObject);
        }

    }

    private void Update()
    {

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

        if (GameManager.gameStart == true)
        {
            GameManager.gameTimer += Time.deltaTime;
        }
    }
}
