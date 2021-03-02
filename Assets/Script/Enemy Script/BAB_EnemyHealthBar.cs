using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAB_EnemyHealthBar : MonoBehaviour
{

    public Slider slider;

    // Mets à jour la vie des ennemis au max
    public void SetEnemyMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Mets à jour la vie des ennemis
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
