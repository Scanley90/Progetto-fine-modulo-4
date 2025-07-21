using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject winPanel;    // Pannello vittoria da collegare nell'Inspector
    public GameObject losePanel;   // Pannello sconfitta da collegare nell'Inspector

    private bool levelEnded = false;  // Per evitare di richiamare più volte le funzioni

    // Chiamalo quando il giocatore vince il livello
    public void LevelComplete()
    {
        if (levelEnded) return;
        levelEnded = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;  // Ferma il gioco
    }

    // Chiamalo quando il giocatore perde (vita zero o tempo scaduto)
    public void LevelFailed()
    {
        if (levelEnded) return;
        levelEnded = true;
        losePanel.SetActive(true);
        Time.timeScale = 0f;  // Ferma il gioco
    }

    // Bottone per tornare al menu principale
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;  // Riattiva il gioco
        SceneManager.LoadScene("MainMenu");  // Assicurati che si chiami davvero così
    }

    // Bottone per ricaricare il livello attuale
    public void RetryLevel()
    {
        Time.timeScale = 1f;  // Riattiva il gioco
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // ❌ RIMOSSE le chiamate LevelComplete e LevelFailed
    }
}