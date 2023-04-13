using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveFunctions : MonoBehaviour
{
    public Text infoText;
    public Image textbg;

    private float uiTimer = 0f;
    public float uiTimerEnd = 2.5f;
    private bool uitimerStart = false;

    public void SaveGame ()
    {
        SaveSystem.SaveGame(this);

        textbg.enabled = true;
        infoText.enabled = true;
        infoText.text = "GAME SAVED!";
        uitimerStart = true;
    }
    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadGame();

        GameManager.bulletDamage = data.bulletDamage;
        GameManager.laserDamage = data.laserDamage;
        GameManager.playerHealth = data.playerHealth;
        GameManager.maxHealth = data.maxHealth;
        GameManager.speed = data.speed;
        GameManager.hasBomb = data.hasBomb;
        GameManager.hasDash = data.hasDash;
        GameManager.hasLaser = data.hasLaser;

        GameManager.chests = data.chestsOpened;
        GameManager.target = data.targetsBroken;

        SceneManager.LoadScene(data.currentLevel);

        GameManager.setSpawn = true;
        GameManager.spawnPosition = new Vector2(data.position[0], data.position[1]);

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
    }
}
