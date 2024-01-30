using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Component references
    // TODO: create variable to store rigidbody of player (2D)
    Rigidbody2D rb;
    // TODO: create variable storing the Animator


    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;

    //TODO: keep track of current horizontal movement direction
    float direction = 0f;

    //keep track of if the player is on the ground
    bool isGrounded = false;

    //TODO: keep track of which direction player is facing
    bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Get references to the rigidbody and animator attached to the current GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Pass in the proper direction that the player should move in
        Move(direction);

        // TODO: check conditions needed to flip player, and if so, flip player
        if((isFacingRight && direction == -1) || (!isFacingRight && direction == 1))
            Flip();
    }

    void OnJump()
    {
        //if player is on the ground, jump
        //if (isGrounded)
        Jump();
    }

    private void Jump()
    {
        // TODO: change y velocity of player
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    void OnMove(InputValue moveVal)
    {
        // TODO: store direction input and store it to global variable
        float movDirection = moveVal.Get<float>();
        direction = movDirection;
    }

    private void Move(float x)
    {
        // TODO: change x velocity of player
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        // TODO: Here, we can handle animation transitioning logic
    }

    private void Flip()
    {
        // TODO: flip local scale of player and change global variable that stores which direction player is facing
        isFacingRight = !isFacingRight;
        Vector2 newLocalScale = transform.localScale;
        newLocalScale.x *= -1f;
        transform.localScale = newLocalScale;
    }

    // TODO: Week 3's assignment needs a couple of extra functions here...

    void OnCollisionEnter2D(Collision2D collider) {
        Debug.Log("Colliding");
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Triggered");
        if (collider.gameObject.CompareTag("Collectible"))
        {
            Destroy(collider.gameObject);
        }
            
    }
}
