using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerLaserShoot laserShoot;
    public BombPlace bombPlace;
    public DashScript dashScript;

    public GameObject player;
    public Transform playerPosition;
    public Text infoText;
    private string infoText2;
    public Image textbg;
    public AudioSource song;

    private float uiTimer = 0f;
    public float uiTimerEnd = 5f;
    private bool uitimerStart = false;
    private bool info2 = false;

    public AudioClip itemGet;

    public AudioClip rumbleApproach;

    private void Start()
    {
        laserShoot.enabled = false;
        bombPlace.enabled = false;
        dashScript.enabled = false;

        if (GameManager.setSpawn == true)
        {
            playerPosition.position = GameManager.spawnPosition;
            GameManager.setSpawn = false;
            if (GameManager.doorSave == true)
            {
                SaveFunctions save = GetComponent<SaveFunctions>();
                save.SaveGame();
                GameManager.doorSave = false; 
            }

        }

    }

    private void Update()
    {
        if (GameManager.hasBomb == true)
        {
            bombPlace.enabled = true;
        }
        if (GameManager.hasDash == true)
        {
            dashScript.enabled = true;
        }
        if (GameManager.hasLaser == true)
        {
            laserShoot.enabled = true;
        }

        if (uitimerStart == true)
        {
            uiTimer += Time.deltaTime;
            if (uiTimer > uiTimerEnd)
            {
                if (info2 == true)
                {
                    uiTimer = 0f;
                    info2 = false;
                    infoText.text = infoText2;
                }
                else
                {
                    infoText.enabled = false;
                    textbg.enabled = false;
                    uiTimer = 0f;
                    uitimerStart = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {

        LaserGet laserGet = hitinfo.GetComponent<LaserGet>();
        if (laserGet != null)
        {
            GameManager.hasLaser = true;
            textbg.enabled = true;
            infoText.enabled = true;
            infoText.text = "LASER GET!";
            uitimerStart = true;
            info2 = true;
            infoText2 = "HOLD RIGHT CLICK TO SHOOT";
            AudioScript.Instance.PlaySound(itemGet);

            Destroy(hitinfo.gameObject);
        }
        bombget bombGet = hitinfo.GetComponent<bombget>();
        if (bombGet != null)
        {
            GameManager.hasBomb = true;
            textbg.enabled = true;
            infoText.enabled = true;
            infoText.text = "BOMB GET!";
            uitimerStart = true;
            info2 = true;
            infoText2 = "PRESS SPACE OR MIDDLE MOUSE TO SHOOT";

            AudioScript.Instance.PlaySound(itemGet);

            Destroy(hitinfo.gameObject);
        }
        dashget dashget = hitinfo.GetComponent<dashget>();
        if (dashget != null)
        {
            GameManager.hasDash = true;
            textbg.enabled = true;
            infoText.enabled = true;
            infoText.text = "DASH GET!";
            uitimerStart = true;
            info2 = true;
            infoText2 = "PRESS SHIFT TO DASH, EVEN OVER PITS";

            AudioScript.Instance.PlaySound(itemGet);

            Destroy(hitinfo.gameObject);
        }

        LoadingInfo door = hitinfo.GetComponent<LoadingInfo>();
        if (door != null)
        {
            GameManager.doorSave = true;
            GameManager.bombCount = 0;
            GameManager.setSpawn = true;
            GameManager.spawnPosition = door.destination;

            SceneManager.LoadScene(door.sceneName);
        }

        SaveTrigger saveTrigger = hitinfo.GetComponent<SaveTrigger>();
        if (saveTrigger != null)
        {
            SaveFunctions save = GetComponent<SaveFunctions>();
            save.SaveGame();
        }

        fightTrigger fighttrigger = hitinfo.GetComponent<fightTrigger>();
        if (fighttrigger != null)
        {
            song.enabled = true;
            AudioScript.Instance.PlaySound(rumbleApproach);
            GameManager.bossFightStart = true;
            Destroy(hitinfo.gameObject);
        }


    }
}
