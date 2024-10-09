using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Slider anxietySlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.05f;
    private void Start()
    {
        health = maxHealth;
    }
    public void UpdateHealthbar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
    void Update()
    {
        if (slider.value != health)
        {
            slider.value = health;
        }
        if(slider.value != anxietySlider.value)
        {
            anxietySlider.value = Mathf.Lerp(anxietySlider.value, health, lerpSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(10);
        }
    }
    void takeDamage(float damage)
    {

        health -= damage;
    }
}