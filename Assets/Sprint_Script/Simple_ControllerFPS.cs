using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_ControllerFPS : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkspeed;
    public float sprintspeed;
    public float stepHeight;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Stamina")]
    public Stamina_Bar staminaBar;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask Ground;
    bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode SprintKey = KeyCode.LeftShift;
    public KeyCode Crouch = KeyCode.LeftControl;
    public KeyCode Setting = KeyCode.Tab;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;
    private float originalMass;
    private float jumpOriginal;
    public SettingInGame settingScript;
    


    public MovementStates State;
    public enum MovementStates
    {
        walking,
        running,
        jumping,
        crouching,
        standing
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        startYScale = transform.localScale.y;

        //stepRayupper.transform.position = new Vector3(stepRayupper.transform.position.x, stepH, stepRayupper.transform.position.z);
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);
        MyInput();
        SpeedControl();
        stateHandler();

        //Debug.Log("Grounded: " + grounded);

        if (staminaBar.stamina <= 0)
        {
            moveSpeed = walkspeed;
        }

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(JumpReset), jumpCooldown);
        }

        //Start Crouch
        if (Input.GetKeyDown(Crouch))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        //Stop Crouch
        if (Input.GetKeyUp(Crouch))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }

        //Setting
        if (Input.GetKeyDown(Setting))
        {
            settingScript.showSetting();
        }
    }

    private void stateHandler()
    {
        //Crouching
        if(grounded && Input.GetKey(Crouch))
        {
            State = MovementStates.crouching;
            moveSpeed = crouchSpeed;
        }
        
        //running
        else if(grounded && Input.GetKey(SprintKey) && (horizontalInput != 0 || verticalInput != 0))
        {
            State = MovementStates.running;
            moveSpeed = sprintspeed;
        }

        //walking
        else if (grounded && (horizontalInput != 0 || verticalInput != 0))
        {
            State = MovementStates.walking;
            moveSpeed = walkspeed;
        }

        else if (grounded && (horizontalInput == 0 || verticalInput == 0))
        {
            State = MovementStates.standing;
        }

        //Jumping
        else
        {
            State = MovementStates.jumping;
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // On Slope
        if (OnSLope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if(rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }

        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

        rb.useGravity = !OnSLope();
    }

    private void SpeedControl()
    {
        //limiting speed on slope
        if (OnSLope() && !exitingSlope)
        {
            if(rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }
        }
        
        // limiting speed on ground or in air
        Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatvel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatvel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        exitingSlope = true;
        
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void JumpReset()
    {
        readyToJump = true;

        exitingSlope = false;
    }

    private bool OnSLope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false; 
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    public void SetWalkSpeed(float newSpeed)
    {
        walkspeed = newSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stair"))
        {
            jumpOriginal = jumpForce;
            originalMass = rb.mass;
            rb.mass = originalMass * stepHeight;
            jumpForce = jumpOriginal * 0.25f;
            

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stair"))
        {
            jumpForce = jumpOriginal;
            rb.mass = originalMass;
        }
    }
}


