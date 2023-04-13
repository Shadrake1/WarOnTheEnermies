using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public static float sliderVolume;

    public GameObject pauseMenu;

    public AudioClip pauseSound;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        sliderVolume = volume;
    }
    public void Start()
    {
        slider.value = sliderVolume;
    }
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (GameManager.gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        AudioScript.Instance.PlaySound(pauseSound);
        Time.timeScale = 1f;
        GameManager.gameIsPaused = false;
        GameManager.gameStart = true;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        AudioScript.Instance.PlaySound(pauseSound);
        Time.timeScale = 0f;
        GameManager.gameIsPaused = true;
        GameManager.gameStart = false;
    }
    public void UnFreeze()
    {
        GameManager.gameIsPaused = false;
        Time.timeScale = 0f;
    }
}
