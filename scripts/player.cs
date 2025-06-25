using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject coinPrefab;

    void Start()
    {
        // Spawn 30 munten
        for (int i = 0; i < 30; i++)
        {
            float randomX = Random.Range(-10f, 10f);
            Vector3 spawnPos = new Vector3(randomX, 0.5f, 0f);
            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
    }
}
