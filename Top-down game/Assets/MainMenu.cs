using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip selectSound;
    public AudioClip hoverSound;
    public void NewGame()
    {
        AudioScript.Instance.PlaySound(selectSound);
        GameManager.maxHealth = 50f;
        GameManager.playerHealth = 50f;
        GameManager.speed = 30f;
        GameManager.bulletDamage = 10f;
        GameManager.laserDamage = 0.2f;
        GameManager.hasBomb = false;
        GameManager.hasDash = false;
        GameManager.hasLaser = false;
        GameManager.chests.Clear();

        GameManager.gameTimer = 0f;
        GameManager.gameStart = true;
        GameManager.newGame = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void LoadYourGame()
    {
        SaveFunctions save = GetComponent<SaveFunctions>();
        PlayerData data = SaveSystem.LoadGame();
        AudioScript.Instance.PlaySound(selectSound);
        if (GameManager.gameStart == false)
        {
            GameManager.gameTimer = data.gameTimer;
            GameManager.gameStart = true;
        }
        GameManager.gameStart = true;
        save.LoadGame();
    }

    public void QuitGame()
    {
        Debug.Log("You quit the game, congratulations");
        AudioScript.Instance.PlaySound(selectSound);
        GameManager.gameStart = false;
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        GameManager.gameStart = false;
        AudioScript.Instance.PlaySound(selectSound);
        SceneManager.LoadScene("MainMenu");
    }

    public void OnHover()
    {
        AudioScript.Instance.PlaySound(hoverSound);
    }

}
