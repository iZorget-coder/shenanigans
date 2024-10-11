using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Slider anxietySlider;
    public float maxHealth = 100f;
    public float currentplayerhealth = 100f;
    public float health;
    private float lerpSpeed = 0.05f;

    [SerializeField] private Image bloodImage = null;
    [SerializeField]private Image hurtimage = null;
    [SerializeField] private float hurtTmer = 0.1f;

    [SerializeField] private GameObject gameOverPanel = null;

    private void Start()
    {
        health = maxHealth;
        currentplayerhealth = maxHealth;
       // UpdateHealthbar(currentplayerhealth, maxHealth);
        bloodImage.enabled = false;
    }
    public void UpdateHealthbar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
    void Update()
    {
        if (slider.value != currentplayerhealth / maxHealth)
        {
            slider.value = Mathf.Lerp(slider.value, currentplayerhealth / maxHealth, lerpSpeed);
        }
        if (anxietySlider.value != slider.value)
        {
            anxietySlider.value = slider.value;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(10);
        }
        if (currentplayerhealth <= 0)
        {
            TriggerGameOver();
        }
    }
    void takeDamage(float damage)
    {

        currentplayerhealth -= damage;
        currentplayerhealth = Mathf.Clamp(currentplayerhealth, 0, maxHealth);

        // Flash hurt effect and update health bar
        StartCoroutine(HurtFlash());
        UpdateHealthbar(currentplayerhealth, maxHealth);

        // Update health-related UI effects like the blood splatter
        UpdateHealthEffects();
    }

    IEnumerator HurtFlash()
    {
        hurtimage.enabled = true;
        yield return new WaitForSeconds(hurtTmer);
        hurtimage.enabled= false;
    }
    void UpdateHealthEffects()
    {
        // Adjust the transparency of bloodImage based on health
        Color splatterAlpha = bloodImage.color;
        splatterAlpha.a = 1 - (currentplayerhealth / maxHealth);  // Blood becomes more visible as health decreases
        bloodImage.color = splatterAlpha;

        // Activate bloodImage if health is very low
        if (currentplayerhealth <= 0)
        {
            bloodImage.enabled = true;
        }
    }
    void TriggerGameOver()
    {
        // Show game over panel when health reaches 0
        gameOverPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}