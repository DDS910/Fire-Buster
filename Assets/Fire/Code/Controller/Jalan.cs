using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jalan : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController kontrol;
    public float walkspeed = 4.5f;
    public float runspeed = 7.5f;
    public float gravity = -9.81f;
    private bool isMoving = false;

    //public AudioSource footsteps;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        kontrol.Move(move * walkspeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        kontrol.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            //footsteps.enabled = true;
        }
        else
        {
            //footsteps.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            isMoving = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isMoving = false;
        }
        if (Input.GetKey(KeyCode.LeftShift) && isMoving)
        {
            transform.position += transform.forward * Time.deltaTime * runspeed;
        }

    }
}
