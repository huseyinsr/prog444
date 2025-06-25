using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Referentie naar Rigidbody
    private Rigidbody rb;

    // Snelheid van bewegen moveSpeed type float
    public float moveSpeed = 7f;

    // Kracht van sprong jumpForce type float
    public float jumpForce = 10f;

    // Check of speler op de grond staat
    private bool isGrounded = true;

    void Start()
    {
        // Haal Rigidbody component op van het gameobject
        rb = GetComponent<Rigidbody>();
        Debug.Log("Speler klaar!");
    }

    void Update()
    {
        // Beweging met pijltjestoetsen
        float move = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(move * moveSpeed, rb.linearVelocity.y, 0);
        rb.linearVelocity = movement;

        // Simpele Sprong met spatie , gebruik rigidbody
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Springen!");
            isGrounded = false;
        }
    }

    // Detecteer wanneer speler weer op de grond komt
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
