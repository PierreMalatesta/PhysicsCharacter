using UnityEngine;
using TMPro;

public class CharacterMover : MonoBehaviour
{
    public float speed = 10;
    public float jumpVelocity = 10;

    CharacterController cc;
    [SerializeField] Vector2 moveInput = new Vector2();
    bool jumpInput;
    [SerializeField] Vector3 velocity;
    [SerializeField] bool isGrounded;

    Transform cam;

    Animator animator;

    bool hasInput;

    //to crouch
    float originalHeight;
    public float reducedHeight;

    // Start is called before the first frame update 
    void Start()
    {
        cc = GetComponent<CharacterController>();
        cam = Camera.main.transform;

        animator = GetComponent<Animator>();

        originalHeight = cc.height;

    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        //left shift makes us walk
        if (Input.GetKey(KeyCode.LeftShift))
            moveInput.y *= 0.05f;

        jumpInput = Input.GetButton("Jump");
        hasInput = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        animator.SetFloat("Forwards", Mathf.Abs(moveInput.y));
        animator.SetFloat("Turn", moveInput.x);
        animator.SetBool("Jump", !isGrounded);
        //play the animation backwards
        animator.SetFloat("Sense", moveInput.y < 0 ? -1 : 1);


        //Crouch
        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch();
            animator.SetBool("Crouch", true);
        }

        else if (Input.GetKeyUp(KeyCode.C))
        {
            GoUp();
            animator.SetBool("Crouch", false);
        }
    }



    void FixedUpdate()
    {
        Vector3 camForward = cam.forward;
        camForward.y = 0;
        camForward.Normalize();

        // player movement using WASD or arrow keys 
        Vector3 delta = (moveInput.x * cam.right + moveInput.y * camForward) * speed;

        if (isGrounded || hasInput)
        {
            velocity.x = delta.x;
            velocity.z = delta.z;
        }

        //face away from the camera at all times
        transform.forward = camForward;

        // check for jumping 
        if (jumpInput && isGrounded)
            velocity.y = jumpVelocity;

        // check if we've hit ground from falling. If so, remove our velocity 
        if (isGrounded && velocity.y < 0)
            velocity.y = 0;

        // apply gravity after zeroing velocity so we register as grounded still 
        velocity += Physics.gravity * Time.fixedDeltaTime;

        if (!isGrounded)
            hitDirection = Vector3.zero;

        // slide objects off surfaces they're hanging on to 
        if (moveInput.x == 0 && moveInput.y == 0)
        {
            Vector3 horizontalHitDirection = hitDirection;
            horizontalHitDirection.y = 0;
            float displacement = horizontalHitDirection.magnitude;
            if (displacement > 0)
                velocity -= 0.2f * horizontalHitDirection / displacement;
        }

        cc.Move(velocity * Time.fixedDeltaTime);
        isGrounded = cc.isGrounded;
    }

    public Vector3 hitDirection;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitDirection = hit.point - transform.position;
    }

    //Method to reduce height
    void Crouch()
    {
        cc.height = reducedHeight;
        cc.center = reducedHeight * Vector3.up;
    }

    //Method to reset height
    void GoUp()
    {
        cc.height = originalHeight;
        cc.center = originalHeight * 0.5f * Vector3.up;
    }
}