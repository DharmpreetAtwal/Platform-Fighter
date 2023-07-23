using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public static MainUIManager Instance;
    public Image healthBar;
    public Text healthText;
    public Image staminaBar;
    public Text staminaText;

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
        var barRectTransform = healthBar.transform as RectTransform;
        barRectTransform.sizeDelta = new Vector2(100 *
            (h / maxH), barRectTransform.sizeDelta.y);
        healthText.text = "HP: " + (int)h;
    }

    public void UpdateStaminaBar(float s, float maxS)
    {
        var barRectTransform = staminaBar.transform as RectTransform;
        barRectTransform.sizeDelta = new Vector2(100 * (s / maxS),
            barRectTransform.sizeDelta.y);
        staminaText.text = "STM: " + (int)s;
    }

    public void MoveDefaultLayer(GameObject obj)
    {
        obj.layer = 0;
    }

    public void MovePlatformCollisionLayer(GameObject obj)
    {
        obj.layer = 3;
    }

    public void MoveProjectileLayer(GameObject obj)
    {
        obj.layer = 6;
    }

    //public void MovePlatformlessPlayerLayer(GameObject obj)
    //{
    //    obj.layer = 7;
    //}

}
