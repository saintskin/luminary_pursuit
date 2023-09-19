using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 moveDirection;
    public float moveSpeed = 5.0f;

    [Header("Animation")]
    public Animator playerAnimator;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Input from the new Input System.
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Calculate movement direction based on camera orientation.
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        moveDirection = forward * moveInput.y + right * moveInput.x;
        moveDirection.Normalize();

        // Apply movement.
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Play movement animations.
        if (playerAnimator != null)
        {
            float moveMagnitude = moveDirection.magnitude;
            playerAnimator.SetFloat("MoveSpeed", moveMagnitude);
        }
    }
}