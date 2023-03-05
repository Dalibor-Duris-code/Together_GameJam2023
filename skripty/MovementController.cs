using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //functional options
    [Header("Functional Options")]
    [SerializeField] private bool canJump = true;
    [SerializeField] private bool canCrouch = true;

    //rigidbody for characters
    [Header("RigidBody")]
    [SerializeField] private Rigidbody2D rbCharacter;

    //contorls
    [Header("Controls")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode crouchKey = KeyCode.LeftControl;

    //player movement
    [Header("Movement Keys")]
    [SerializeField] private KeyCode moveLeftKey = KeyCode.A;
    [SerializeField] private KeyCode moveRightKey = KeyCode.D;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveSpeedInAir = 2f;

    //jump parameters
    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float gravity = 30f;

    //crouch parameters
    [Header("Crouch Parameters")]
    [SerializeField] private Vector2 standHeight;
    [SerializeField] private Vector2 crouchHeight;
    [SerializeField] private float timeToCrouch = 0.2f;
    [SerializeField] private CapsuleCollider2D CharacterCollider;
    [SerializeField] private CapsuleCollider2D characterCrounchCollider;
    private bool isCrouching = false;

    //crouch parameters
    [Header("Animations")]
    [SerializeField] private Animator animator;

    //what is ground
    [SerializeField] private Transform checkGround;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        characterCrounchCollider.size = new Vector2(0.0001f, 0.0001f);
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        //if can jump then jump
        if (canJump)
        {
            HandleJump();
        }

        //if can crounch then crouch
        if (canCrouch)
        {
            HandleCrouch();
        }

    }

    //check if player is grounded
    bool isGrounded()
    {
        return Physics2D.OverlapCircle(checkGround.position, 0.2f, groundLayer);
    }

    //handle movement
    //in air move slower
    void HandleMovement()
    {

        float moveSp= 0f;
        float moveSpAir = 0f;

        if (Input.GetKey(moveLeftKey))
        {
            moveSp = -moveSpeed;
            moveSpAir = -moveSpeedInAir;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKey(moveRightKey))
        {
            moveSp = moveSpeed;
            moveSpAir = moveSpeedInAir;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (isGrounded())
        {
            animator.SetFloat("speed", Mathf.Abs(moveSp));
            animator.SetBool("inAir", false);
            rbCharacter.velocity = new Vector2(moveSp, rbCharacter.velocity.y);
        }
        else
        {
            animator.SetBool("inAir", true);
            rbCharacter.velocity = new Vector2(moveSpAir, rbCharacter.velocity.y);
        }
    }

    //handle jump
    void HandleJump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded())
        {
            rbCharacter.velocity = new Vector2(rbCharacter.velocity.x, jumpForce);
        }
    }

    //handle crouch
    void HandleCrouch()
    {
        StartCoroutine(CrouchStand());
    }

    //crouch stand coroutine
    IEnumerator CrouchStand()
    {
        if (Input.GetKeyDown(crouchKey))
        {
            isCrouching = true;
            animator.SetBool("isCrouching", isCrouching);
            CharacterCollider.size = crouchHeight;
            characterCrounchCollider.size = new Vector2(0.01f, 0.01f);
            yield return new WaitForSeconds(timeToCrouch);

        }
        if (Input.GetKeyUp(crouchKey))
        {
            isCrouching = false;
            animator.SetBool("isCrouching", isCrouching);
            CharacterCollider.size = standHeight;
            characterCrounchCollider.size = new Vector2(0.0001f, 0.0001f);
            yield return new WaitForSeconds(timeToCrouch);
        }
    }

}
