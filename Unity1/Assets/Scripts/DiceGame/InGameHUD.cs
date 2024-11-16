using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameHUD : MonoBehaviour
{
    [SerializeField] private Image Healthbar;
    public float currentHealth = 25f;
    public float maxHealth = 50f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnHealthChange(currentHealth, maxHealth);
        }

        

        
    }
    public void OnHealthChange(float currentHealth, float maxHealth)
    {
        Healthbar.fillAmount = currentHealth / maxHealth;
    }
}
