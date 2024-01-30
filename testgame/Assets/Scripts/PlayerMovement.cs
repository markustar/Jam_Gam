using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Transform mainCameraTransform;

    [Header("Movement Properties")]
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10.0f; // New property for rotation speed

    [Header("Jumping Properties")]
    public float jumpForce = 8.0f;
    public float groundCheckDistance = 0.2f;

    private bool isGrounded;
    private bool canJump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveInput = new Vector3(horizontalInput, 0f, verticalInput);
        Vector3 cameraForward = mainCameraTransform.forward;
        cameraForward.y = 0;

        Vector3 moveDirection = Quaternion.LookRotation(cameraForward) * moveInput;
        Move(moveDirection);



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


    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canJump = false;
        Invoke("EnableJump", 5.0f);
    }

    private void EnableJump()
    {
        canJump = true;
    }
}
