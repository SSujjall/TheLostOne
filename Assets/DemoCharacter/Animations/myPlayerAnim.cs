using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayerAnim : MonoBehaviour
{
    public CharacterController controller;
    private Animator animator;

    public float walkSpeed;
    public float normalSpeed = 12f;
    public float sprintSpeed = 25f;

    public float gravity = -9.81f * 2;

    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool isMoving = Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f;

        //right is the red Axis, foward is the blue axis
        Vector3 move;

        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;


        // *Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            walkSpeed = sprintSpeed;
            move = transform.right * x * 0.5f + transform.forward * z;
        }
        else
        {
            walkSpeed = normalSpeed;
            move = transform.right * x + transform.forward * z;
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("state", true);
            }
            else
            {
                animator.SetBool("state", false);
            }
        }
        controller.Move(move * walkSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}