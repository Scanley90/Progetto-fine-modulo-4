using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Trova lo script PlayerCollector e aggiungi moneta
            PlayerCollector collector = other.GetComponent<PlayerCollector>();
            if (collector != null)
            {
                collector.CollectCoin();
            }

            // Distruggi la moneta raccolta
            Destroy(gameObject);
        }
    }
}

