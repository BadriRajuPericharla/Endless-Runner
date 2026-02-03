using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 8f;        // Auto forward speed
    public float laneChangeSpeed = 10f;    // Smooth lane switch speed
    public float jumpForce = 6f;           // Jump power

    private Rigidbody rb;
    private bool isGrounded = true;

    // Lane positions
    private Transform lane1;
    private Transform lane2;
    private Transform lane3;

    private Transform targetLane;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Find lanes by tags
        lane1 = GameObject.FindGameObjectWithTag("lane1").transform;
        lane2 = GameObject.FindGameObjectWithTag("lane2").transform;
        lane3 = GameObject.FindGameObjectWithTag("lane3").transform;

        // Start always in middle lane
        targetLane = lane2;
    }

    void Update()
    {
        HandleLaneInput();
        MoveToLane();
    }

    void FixedUpdate()
    {
        MoveForwardAlways(); // Runs nonstop
    }

    // ✅ Player always moves forward (never stops)
    void MoveForwardAlways()
    {
        rb.velocity = new Vector3(
            rb.velocity.x,
            rb.velocity.y,
            forwardSpeed
        );
    }

    // ✅ Input only for lane switching + jump
    void HandleLaneInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
            targetLane = lane1;

        if (Input.GetKeyDown(KeyCode.W))
            targetLane = lane2;

        if (Input.GetKeyDown(KeyCode.D))
            targetLane = lane3;

        // Jump with E key
        if (Input.GetKeyDown(KeyCode.E) && isGrounded)
            Jump();
    }

    // ✅ Smooth lane movement (left/middle/right)
    void MoveToLane()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = targetLane.position.x;

        transform.position = Vector3.Lerp(
            transform.position,
            newPosition,
            laneChangeSpeed * Time.deltaTime
        );
    }

    // ✅ Jump Function
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    // ✅ Ground Check
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}


