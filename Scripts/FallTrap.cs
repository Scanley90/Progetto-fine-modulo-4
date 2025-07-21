using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player è caduto! Ricarico livello...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

