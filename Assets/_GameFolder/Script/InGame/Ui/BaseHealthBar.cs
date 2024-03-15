using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseHealthBar : MonoBehaviour
{
    [SerializeField] protected Image avatar;
    [SerializeField] protected Image healthBarFill;

    public void UpdateAvatar(Sprite newAvatar)
    {
        avatar.sprite = newAvatar;
    }

    public void UpdateHealthBar(float health)
    {
        healthBarFill.fillAmount = health;
    }

    public void UpdateUI(BaseHumanRig humanRig)
    {
        UpdateAvatar(humanRig.GetAvatar);
        UpdateHealthBar(humanRig.GetCurHpPercent);
    }
}