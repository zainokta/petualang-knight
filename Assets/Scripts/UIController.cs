using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public static UIController instance = null;
    private Color now;
    private Color fadeIn;
    private float duration = 0.15f;

    public Button dashButton;
    public Button potionButton;
    public Slider hpSlider;
    public Text gameover;

    private void Awake()
    {
        hpSlider.maxValue = PlayerPrefsManager.GetPlayerMaxHealth();
        dashButton.interactable = GameManager.instance.dashUnlock;
        if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start () {
        now = new Color(gameover.color.r, gameover.color.g, gameover.color.b, gameover.color.a);
        fadeIn = new Color(gameover.color.r, gameover.color.g, gameover.color.b, 1f);
    }

    public void FadeIn()
    {
        if (GameManager.instance.fading == true)
        {
            gameover.color = Color.Lerp(now, fadeIn, duration);
            duration += 0.2f * Time.deltaTime;
        }

        if (duration >= 1.0f)
        {
            duration = 1.0f;
        }
    }

    void Update () {
        if (dashButton.image.fillAmount <= 1)
        {
            dashButton.image.fillAmount += GameManager.instance.dashCooldown * Time.deltaTime;
        }
        if (potionButton.image.fillAmount <= 1)
        {
            potionButton.image.fillAmount += GameManager.instance.potionCooldown * Time.deltaTime;
        }

        hpSlider.value = PlayerPrefsManager.GetPlayerHealth();
        hpSlider.maxValue = PlayerPrefsManager.GetPlayerMaxHealth();
        CheckIfGameOver();
        FadeIn();
    }
    void CheckIfGameOver()
    {
        if (PlayerPrefsManager.GetPlayerHealth() <= 0)
        {
            gameover.gameObject.SetActive(true);
            dashButton.interactable = false;
            potionButton.interactable = false;
            GameManager.instance.fading = true;
        }
    }
}
