using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    public void setMaxHealth(int maxHealth){
        slider.value = maxHealth;
        
        fill.color =  gradient.Evaluate(1f);
    }
    public void setHealth(int currentHealth){
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
