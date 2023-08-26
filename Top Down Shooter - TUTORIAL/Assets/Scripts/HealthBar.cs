using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthBarSlider;

    // Sets max value of health bar and makes health equal to it
    public void SetMaxHealth(int maxHealth)
    {
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = maxHealth;
    }

    // Changes health value
    public void UpdateHealth(int health)
    {
        healthBarSlider.value = health;
    }
}
