using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeBar : MonoBehaviour
{
    [SerializeField] private Image _fillableLifebar;

    public void DisplayLife(float percentageLife)
    {
        _fillableLifebar.fillAmount = Mathf.Clamp01(percentageLife);
    }
}
