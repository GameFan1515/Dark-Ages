using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public float healthAmount = 100f;
    public Image Pixel_Blood;
    private float opacityLevel = 0f;

    private void Start()
    {
        SetOpacity(0f);
    }


    void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(20);
        }
        if (Input.GetMouseButtonDown(1))
        {
            HealDamage(20);
        }
    }


    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        UpdateDamageVignette();
    }

    public void HealDamage(float damage)
    {
        healthAmount += damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        UpdateDamageVignette();
    }

    private void UpdateDamageVignette()
    {
        opacityLevel = Mathf.Clamp01(1 - healthAmount / 100f);
        Color color = Pixel_Blood.color;
        color.a = opacityLevel;
        Pixel_Blood.color = color;
    }

    private void SetOpacity(float opacity)
    {
        Color color = Pixel_Blood.color;
        color.a = opacity;
        Pixel_Blood.color = color;
    }

}
