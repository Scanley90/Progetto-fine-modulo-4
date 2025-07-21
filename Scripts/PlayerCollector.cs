using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // se usi TextMeshPro

public class PlayerCollector : MonoBehaviour
{
    public int totalCoins;   // numero totale di monete nel livello
    public int currentCoins; // quante ne abbiamo raccolte

    public TextMeshProUGUI coinsText; // 👈 Trascina qui il tuo CoinsText dal Canvas

    void Start()
    {
        // Conta automaticamente quante monete ci sono nella scena
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        currentCoins = 0;

        UpdateUI();
    }

    // Chiamato da Coin quando raccogli una moneta
    public void CollectCoin()
    {
        currentCoins++;
        Debug.Log("Moneta raccolta! Totale: " + currentCoins + "/" + totalCoins);

        UpdateUI();

        if (currentCoins >= totalCoins)
        {
            DoorUnlocker.Instance.UnlockDoor();
        }
    }

    void UpdateUI()
    {
        if (coinsText != null)
        {
            coinsText.text = "Monete: " + currentCoins + "/" + totalCoins;
        }
    }
}