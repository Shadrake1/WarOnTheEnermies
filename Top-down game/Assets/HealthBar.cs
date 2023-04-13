using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text currentHealth;
    public Text maximumHealth;

    public void SetMaxHealth(float maxhealth)
    {
        slider.maxValue = maxhealth;
        maximumHealth.text = maxhealth.ToString();

    }
    public void SetHealth(float health)
    {
        slider.value = health;
        currentHealth.text = health.ToString();
    }

    public void SetBossHealth(float bossHealth)
    {
        slider.value = bossHealth;
    }
}
