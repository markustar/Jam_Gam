using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Transform mainCameraTransform;

    [Header("Movement Properties")]
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10.0f;

    [Header("Jumping Properties")]
    public float jumpForce = 8.0f;
    public float groundCheckDistance = 0.2f;
    public float jumpCooldown = 5.0f; // Set the cooldown duration

    private bool isGrounded;
    private bool canJump = true; // Variable to track if the player can jump

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Check for ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        // Handle movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveInput = new Vector3(horizontalInput, 0f, verticalInput);
        Vector3 cameraForward = mainCameraTransform.forward;
        cameraForward.y = 0; // Keep the direction horizontal

        Vector3 moveDirection = Quaternion.LookRotation(cameraForward) * moveInput;
        Move(moveDirection);

        // Handle rotation
        RotatePlayer();

        // Handle jumping with cooldown
        if (isGrounded && Input.GetButtonDown("Jump") && canJump)
        {
            Jump();
        }
    }

    private void Move(Vector3 moveDirection)
    {
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    private void RotatePlayer()
    {
        Vector3 lookDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (lookDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canJump = false; // Disable jumping
        Invoke("EnableJump", jumpCooldown); // Enable jumping after the cooldown
    }

    private void EnableJump()
    {
        canJump = true; // Enable jumping
    }
}
