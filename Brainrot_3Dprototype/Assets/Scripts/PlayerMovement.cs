using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //This finds the rigidbody component on the game object this script is attached to
        rb.freezeRotation = true; //This will freeze the rigidbodys rotation when the scene starts
    }

    private void Update()
    {
        //Ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); //Shoots a raycast below the player to see if it hits the ground

        PlayerInput(); //Calls the player movement function at every frame
        SpeedControl();

        //Handling drag
        if (grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlayerInput() //This function will get the input of the player to determine what buttons will make the player move
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //Calculating the movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; //This insures that the player will always move in the direction that they are looking

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force); //Makes the movement a bit faster and more consistent
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //Limit the velocity if needed
        if (flatVel.magnitude > moveSpeed) //If the player is moving faster than the assigned movement speed
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; //This calculates what the players max speed would be
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z); //Applies said max speed here
        }
    }
}
