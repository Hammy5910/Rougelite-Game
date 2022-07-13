using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRigidBody : MonoBehaviour
{
    public float moveSpeed = 6f;

    float horizontalMovement;
    float verticalMovement;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement * moveSpeed + transform.right * horizontalMovement * moveSpeed;

        Debug.Log($"Move Direction{moveDirection}");
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection, ForceMode.Acceleration);
    }
}
