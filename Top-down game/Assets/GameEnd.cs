using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Rigidbody2D player;

    public Text credits;
    public Text devmessage;
    public Text chestsOpened;
    public Text gameTime;

    private string totalTime;

    public AudioSource bossmusic;
    public AudioSource creditsMusic;

    private float bossDeadTimer = 2f;
    public float creditsActivateTimer = 0f;

    private void Update()
    {
        if (GameManager.gameEnded == true)
        {
            bossmusic.enabled = false;
            creditsActivateTimer += Time.deltaTime;

            if (creditsActivateTimer > bossDeadTimer)
            {
                credits.enabled = true;
                devmessage.enabled = true;
                creditsMusic.enabled = true;

                chestsOpened.enabled = true;
                chestsOpened.text = "Chests opened: " + GameManager.chests.Count + "/ 61";

                totalTime = $"Play Time: {Mathf.Floor(GameManager.gameTimer / 60)}:{Mathf.Floor(GameManager.gameTimer % 60)}";
                gameTime.enabled = true;
                gameTime.text = totalTime;
            }
            
        }

    }
}
