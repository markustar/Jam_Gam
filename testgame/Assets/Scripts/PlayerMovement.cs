using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Transform mainCameraTransform;

    [Header("Movement Properties")]
    public float moveSpeed = 5.0f;
    public float sprintSpeed = 10.0f; // Sprint speed
    
    [Header("Jumping Properties")]
    public float jumpForce = 8.0f;
    public float groundCheckDistance = 0.2f;

    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCameraTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveInput = new Vector3(horizontalInput, 0f, verticalInput);
        Vector3 cameraForward = mainCameraTransform.forward;
        cameraForward.y = 0;

        Vector3 moveDirection = Quaternion.LookRotation(cameraForward) * moveInput;

        // Sprinting when holding the "Shift" key
        float currentMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
        Move(moveDirection.normalized * currentMoveSpeed * Time.fixedDeltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Move(Vector3 moveDirection)
    {
        Vector3 movement = moveDirection;
        rb.MovePosition(transform.position + movement);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Invoke("EnableJump", 5.0f);
    }
}
