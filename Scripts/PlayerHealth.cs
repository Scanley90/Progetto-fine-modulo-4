using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Per usare Slider

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public Slider healthSlider; // Trascina qui la tua barra salute (lo Slider)

    private LevelManager levelManager;

    void Start()
    {
        currentHealth = maxHealth;
        levelManager = FindObjectOfType<LevelManager>();

        // Imposta lo slider all'inizio
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vita attuale: " + currentHealth);

        // Aggiorna la barra UI
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player morto!");
        if (levelManager != null)
        {
            levelManager.LevelFailed();
        }
    }
}