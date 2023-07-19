using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    public void UpdateHealthBar(float h, float maxH)
    {
        //var barRectTransform = healthBar.transform as RectTransform;
        //barRectTransform.sizeDelta = new Vector2(100 *
        //    (h / maxH), barRectTransform.sizeDelta.y);
    }

    public void UpdateStaminaBar(float s, float maxS)
    {
        //var barRectTransform = staminaBar.transform as RectTransform;
        //barRectTransform.sizeDelta = new Vector2(100 * (s / maxS),
        //    barRectTransform.sizeDelta.y);
    }

}
