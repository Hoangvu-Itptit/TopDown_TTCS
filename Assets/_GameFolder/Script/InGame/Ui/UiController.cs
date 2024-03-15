using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [Header("Joystick"), Space(10)] public Joystick moveDirJst;
    public Joystick shootDirJst;

    [Header("Health Bar"), Space(10)] public PlayerHealthBar playerHealthBar;
    public EnemyHealthBar enemyHealthBar;

    [Header("Select Panel"), Space(10)] public GameObject settingPanel;

    [Header("Button Select Panel"), Space(10)]
    public Image healthPotionBtnBg;

    public Image reloadingBulletBtnBg;

    public static UiController Instance;

    void Awake()
    {
        Instance = this;
    }

    public void ActiveEnemyHeathBar(bool isActive)
    {
        enemyHealthBar.gameObject.SetActive(isActive);
    }

    public void UpdatePlayerAvatar(Sprite avatarSprite)
    {
        playerHealthBar.UpdateAvatar(avatarSprite);
    }

    public void UpdatePlayerHealthBar(float health)
    {
        playerHealthBar.UpdateHealthBar(health);
    }

    public void UpdatePlayerNumberBullet(string number)
    {
        playerHealthBar.UpdateNumberBullet(number);
    }

    public void UpdateUIEnemy(BaseEnemy baseEnemy)
    {
        enemyHealthBar.UpdateUI(baseEnemy);
    }

    public void BtnListener_OpenSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    public void BtnListener_HealthPotion()
    {
        if (healthPotionBtnBg.fillAmount < 0.99f) return;
        GameController.Instance.player.Heal(10);
        StartCoroutine(Reload(10f, healthPotionBtnBg));
    }

    public void BtnListener_ReloadingBullet()
    {
        if (reloadingBulletBtnBg.fillAmount < 0.99f) return;
        GameController.Instance.player.ReloadBullet(rateOfFire =>
            StartCoroutine(Reload(rateOfFire, reloadingBulletBtnBg)));
    }

    IEnumerator Reload(float rate, Image btnBg)
    {
        btnBg.fillAmount = 0;
        while (btnBg.fillAmount < 1)
        {
            btnBg.fillAmount += Time.deltaTime / rate;
            yield return new WaitForSeconds(Time.deltaTime / rate);
        }
    }
}