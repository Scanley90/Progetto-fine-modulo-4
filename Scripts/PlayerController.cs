using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    [Header("Ground Check")]
    public Transform groundCheck;        // l'empty sotto i piedi
    public float groundDistance = 0.3f;  // raggio della sfera per controllare
    public LayerMask groundLayer;        // assegna il Layer Ground nell'Inspector

    [Header("Camera")]
    public Transform playerCamera;       // la camera come figlio del player o come oggetto separato
    public float mouseSensitivity = 2f;
    public float verticalLookLimit = 80f;

    private Rigidbody rb;
    private bool isGrounded;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;  // blocca il mouse al centro
        Cursor.visible = false;
    }

    void Update()
    {
        // === Movimento orizzontale ===
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Vector3 velocity = move * moveSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        // === Controllo salto ===
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

       

        // Controllo se sono a terra
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // === Rotazione camera ===
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);

        // ruota la camera in verticale
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // ruota il player in orizzontale
        transform.Rotate(Vector3.up * mouseX);
    }

    void OnDrawGizmosSelected()
    {
        // per vedere la sfera del ground check in scena
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }
}
