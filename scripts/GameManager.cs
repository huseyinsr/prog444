using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variabelen
    public float speed = 5f;         // Snelheid van bewegen
    public float timeLeft = 20f;     // Overgebleven tijd
    private int score = 0;           // Score van speler

    void Update()
    {
        // Beweging met Vector3, Time.deltaTime en Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Aftellen van tijd
        timeLeft -= Time.deltaTime;

        // Als tijd op is: Game Over
        if (timeLeft <= 0)
        {
            Debug.Log("Game Over! Eindscore: " + score);
            enabled = false; // Schakelt Update uit
            return;          // Stopt de rest van de code
        }

        // Toon resterende tijd en score (afgerond)
        Debug.Log("Tijd over: " + Mathf.Ceil(timeLeft) + " sec | Score: " + score);
    }

    // Trigger bij aanraking van coin
    private void OnTriggerEnter(Collider other)
    {
        // Check of object een coin is (tag == "Coin")
        if (other.CompareTag("Coin"))
        {
            score += 10;
            Debug.Log("Munt gepakt! +10 punten");
            Destroy(other.gameObject);
        }
    }
}

