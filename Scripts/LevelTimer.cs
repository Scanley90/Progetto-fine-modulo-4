using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // se vuoi ricaricare la scena alla sconfitta

public class LevelTimer : MonoBehaviour
{
    public float timeRemaining = 60f; // tempo in secondi
    public bool timerIsRunning = true;
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                // Tempo scaduto
                timeRemaining = 0;
                timerIsRunning = false;
                TimeIsUp();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // per non mostrare -0
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("Tempo: {0:00}:{1:00}", minutes, seconds);
    }

    void TimeIsUp()
    {
        // Qui decidi cosa succede quando scade il tempo:
        Debug.Log("Tempo scaduto! Hai perso!");
        // Puoi ricaricare il livello:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Oppure mostrare un Game Over UI
    }
}

