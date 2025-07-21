using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorUnlocker : MonoBehaviour
{
    public static DoorUnlocker Instance;
    public bool isUnlocked = false;

    [Header("Porta da sbloccare")]
    public GameObject doorObject;            // Oggetto visivo della porta
    public Collider blockingCollider;        // Il collider fisico che blocca (non trigger)

    [Header("UI Vittoria")]
    public TextMeshProUGUI winText;          // Scritta YOU WIN nel Canvas

    void Awake()
    {
        Instance = this;
    }

    // Chiamato dal tuo sistema monete quando hai tutte le monete
    public void UnlockDoor()
    {
        isUnlocked = true;
        Debug.Log("✅ Porta sbloccata! Ora puoi attraversarla.");
    }

    // Trigger messo davanti alla porta
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isUnlocked)
        {
            Debug.Log("🎉 YOU WIN!");

            // Disattiva il collider fisico della porta per permettere il passaggio
            if (blockingCollider != null)
            {
                blockingCollider.enabled = false;
            }

            // Mostra la scritta UI
            if (winText != null)
            {
                winText.gameObject.SetActive(true);
            }

            // Puoi anche fermare il tempo
            Time.timeScale = 0f;
        }
    }
}
