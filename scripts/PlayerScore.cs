using UnityEngine;
using System.Collections.Generic;

public class PlayerScore : MonoBehaviour
{
    private int score = 0;                     // Variabele voor score
    private List<int> coins = new List<int>(); // Lijst voor munten

    void Start()
    {
        // Loop: toon 3x een startbericht
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Spel begint!");
        }
    }

    void Update()
    {
        // If-statement: check of score >= 50
        if (score >= 50)
        {
            Debug.Log("Je hebt gewonnen!");
        }

        // Test: druk op spatie om een munt toe te voegen
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCoin(10); // Roep functie AddCoin() aan en geef als argument 10 punten mee
        }
    }

    // Functie om een munt toe te voegen
    void AddCoin(int coinValue)
    {
        coins.Add(coinValue);       // Voeg munt toe aan lijst
        score += coinValue;         // Verhoog score met de waarde van coinValue
        Debug.Log("Munt gepakt! Score: " + score);
        Debug.Log("Aantal munten: " + coins.Count);
    }
}
