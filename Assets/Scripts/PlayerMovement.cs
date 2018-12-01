using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //editor fields
    [SerializeField]
    private float moveSpeed; //speed at which the player moves, multiplied by the input axis
    [SerializeField]
    private float movementConstraint; //limits the player's horizontal movement
    
    //private variables
    private float horizontalInput; //input value taken from the horizontal input axis [Control stick + Keyboard]
    private Rigidbody2D PlayerRigidbody; //player rigidbody for physics calculation

    //animation variables
    private bool isFacingLeft = true; //determines which direction the character is facing
    private Animator playerAnimator; //references the animator component

	// Use this for initialization
	void Start () 
	{
        PlayerRigidbody = GetComponent<Rigidbody2D>(); //initializes the rigidbody component
        playerAnimator = GetComponent<Animator>(); //initializes the animator component
	}
	
	// Update is called once per frame
	void Update () 
	{
        GetInput();
        UpdateAnimatorVariables();
        Flip();
	}

    //For performing physics calculations
    private void FixedUpdate()
    {
        Move();
    }

    //functions

    //Moves the player object according to input within its constraints
    void Move()
    {
        PlayerRigidbody.velocity = new Vector2(horizontalInput * moveSpeed, 0); //move the player

        if (Mathf.Abs(transform.position.x) > movementConstraint) //if the player is outside its constraint limits
        {
            if (transform.position.x < 0) //if the position is negative (to the left)
            {
                transform.position = new Vector2(-movementConstraint, transform.position.y); //sets the position to the left extreme
            }
            else //else the position is positive (to the right)
            {
                transform.position = new Vector2(movementConstraint, transform.position.y); //sets the positino to the right extreme
            }
        }
        
    }

    //recieves input from the horizontal axis, both keyboard and controller
    void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    //flips the sprite if facing the wrong way
    void Flip()
    {
        if (isFacingLeft && PlayerRigidbody.velocity.x > 0)
        {
            isFacingLeft = false;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        if (!isFacingLeft && PlayerRigidbody.velocity.x < 0)
        {
            isFacingLeft = true;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }

    //updates the variables in the animator using local variables
    void UpdateAnimatorVariables()
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(PlayerRigidbody.velocity.x)); //sets the animator variable speed to the character's x velocity
    }
}
