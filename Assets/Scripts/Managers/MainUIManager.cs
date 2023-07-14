using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public static MainUIManager Instance;
    public Image healthBar;
    public Image staminaBar;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateHealthBar(float health)
    {
        var barRectTransform = healthBar.transform as RectTransform;
        barRectTransform.sizeDelta = new Vector2(health, barRectTransform.sizeDelta.y);
    }

    public void UpdateStaminaBar(float stamina)
    {
        var barRectTransform = staminaBar.transform as RectTransform;
        barRectTransform.sizeDelta = new Vector2(stamina, barRectTransform.sizeDelta.y);
    }

}
