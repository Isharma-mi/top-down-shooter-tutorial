using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthBarSlider;
    public Gradient healthBarGradient;
    public Image fill;

    // Sets max value of health bar and makes health equal to it
    public void SetMaxHealth(int maxHealth)
    {
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = maxHealth;

        //Makes health bar green when full
        fill.color = healthBarGradient.Evaluate(1.0f);
    }

    // Changes health value
    public void UpdateHealth(int health)
    {
        healthBarSlider.value = health;

        // Sets color of healthbar based off how much health is left
        fill.color = healthBarGradient.Evaluate(healthBarSlider.normalizedValue);
    }
}
