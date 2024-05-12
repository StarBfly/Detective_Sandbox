using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _chrController;

    [Header("Movement:")]
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float gravity = 9.81f;
    private float _velocityY = 0f;
    [SerializeField] private AudioSource _Step;

    void Start()
    {
        _chrController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        VisualizeCursor();
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float currentSpeed = _speed;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Debug.Log($"Horizontal Input: {horizontalInput}");
        // Debug.Log($"Vertical Input: {verticalInput}");


        if (!_chrController.isGrounded)
        {
            _velocityY -= gravity;
        }
        Vector3 direction = new Vector3(horizontalInput, _velocityY, verticalInput);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= 2.0f;
        }

        Vector3 velocity = direction * currentSpeed;
        velocity = transform.TransformDirection(velocity);
        _chrController.Move(velocity * Time.deltaTime);
    }


    IEnumerator StepsSound()
    {
        _Step.Play();
        yield return new WaitForSeconds(1);
    }

    private void VisualizeCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

}


