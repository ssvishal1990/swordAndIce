using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    public void setMaxValue(int maxHealth){
        slider.value = maxHealth;
        
        fill.color =  gradient.Evaluate(1f);
    }
    public void setCurrentValue(int currentHealth){
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
