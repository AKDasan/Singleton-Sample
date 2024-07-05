using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public static Stamina Instance { get; private set; }   // Instance tanımı

    public float player_Stamina = 100f;

    private void Awake()
    {
        // Instance kontrolü
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (player_Stamina > 100) { player_Stamina = 100f; }
        if (player_Stamina < 0)   { player_Stamina = 0; }
    }

    // Stamina arttırma ve azaltma fonksiyonları
    public void IncreaseStamina(float value)
    {
        player_Stamina += value;
    }

    public void DecreaseStamina(float value)
    {
        player_Stamina -= value;
    }
}
