using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI valueText;
    public void UpdateBar(int currenValue, int maxValue )
    {
        fillBar.fillAmount = (float)currenValue /(float )maxValue;
        valueText.text = currenValue.ToString()+ " / " +maxValue.ToString();
    }
    
} 
