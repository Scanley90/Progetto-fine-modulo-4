using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Carica la scena del gioco (sostituisci "Livello1" col nome della tua scena di gioco)
        SceneManager.LoadScene("Gamescene");
    }

    public void ExitGame()
    {
        // Esce dal gioco (funziona solo nel build, non nell’editor)
        Debug.Log("Gioco chiuso!");
        Application.Quit();
    }
}

