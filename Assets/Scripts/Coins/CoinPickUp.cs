using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    GameSessionController gameSessionController;

    private void Start()
    {
        gameSessionController = FindObjectOfType<GameSessionController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && other.name == "Player"){
            gameSessionController.increementScore(10);
            Destroy(gameObject);
        }
    }
}
