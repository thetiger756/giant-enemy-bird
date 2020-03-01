using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //the motor that drives our player
    public CharacterController controller;

    public float speed = 4f;
    [HideInInspector] public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    [HideInInspector] public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Jump.performed += ctx => Jump();

        controls.Gameplay.Shoot.performed += ctx => GameObject.Find("Cannon").GetComponent<Cannon>().Shoot();

        controls.Gameplay.Pause.performed += ctx => GameObject.Find("Canvas").GetComponent<PauseMenu>().PressPause();

        //controls.Gameplay.MenuUp.performed += ctx => 

        //controls.Gameplay.MenuDown.performed += ctx => 
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
