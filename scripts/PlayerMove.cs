using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public ScoreManager scoreManager;

    void Start()
    {
        Debug.Log("Snelheid: " + speed);
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(moveX, 0, moveZ));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            if (scoreManager != null)
            {
                scoreManager.AddScore(10);
            }
            else
            {
                Debug.LogError("ScoreManager is niet gekoppeld!");
            }

            Destroy(other.gameObject);
        }
    }
}
