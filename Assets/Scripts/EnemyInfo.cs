using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour {

    //editor-exposed fields
    [SerializeField]
    private float moveSpeed; //multiplicative speed of movement
    [SerializeField]
    public int hitsToDefeat; //how many papers it takes to finish this enemy
    [SerializeField]
    private int pointValue; //point value for defeating this enemy
    [SerializeField]
    private float timeToDeathAfterHit; //time between dying and being destroyed

    //local variables
    private BoxCollider2D enemyCollider; //references the object's collider
    private GameManager gameManager; //References the scene's GameManager script
    private AudioSource enemyAudioSource; //references the object's audio source

    //find the game manager
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); //finds the gamemanager and sets its reference on awake
    }

    //Reference of Basic AI code
    public SteeringBehaviors _behaviors;
    private MovingAgent _agent;

    //public accessors for the AI calculations
    public float MaxSpeed;
    public float MaxForce;
    public float Mass;

    public Vector2 Direction;
    public Vector2 Location;
    public Vector2 Heading;

    private Vector2 _homeLoc;


    // Use this for initialization
    void Start () 
	{
        enemyAudioSource = GetComponent<AudioSource>(); //initializes the enemy's audio source
        this._agent = new MovingAgent(this, SteeringBehaviors.PathFollow, this._homeLoc);
        this.Location = this._homeLoc;
        enemyCollider = this.GetComponent<BoxCollider2D>(); //initalizes the collider
        GrabNodes();
        this._behaviors = SteeringBehaviors.PathFollow;
	}

    [SerializeField]
    private GameObject parentNode;

    private void GrabNodes()
    {
        //Debug.Log(parentNode.GetComponentsInChildren<Transform>()[0].position);
        //get the list of children and their locations
        this._agent.PassNodes(parentNode.GetComponentsInChildren<Transform>());
    }

    private void FixedUpdate()
    {
        //Updates AI's calculations
        _agent.UpdateForces();

        //Updates Heading as it is needed for AI calculations for next Update frame
        this.Heading = this.Direction.normalized;

        //Updates Location based on AI calculations
        this.transform.position = this.Location;
    }

    //when collided with
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) //checks whether the collision is a projectile
        {
            takeDamage(); //takes damage if so
        }
    }

    //reduces the number of hits the enemy can take, then sees if the enemy is dead or not. If it is dead, deactivates the collider and scores before destroying the object
    private void takeDamage()
    {
        hitsToDefeat--; //decreases the enemy's health
        if (hitsToDefeat == 0) //checks if the enemy has no hits left
        {
            //death code
            enemyCollider.enabled = false; //disables the collider
            //TODO: Insert animation code
            gameManager.Score += pointValue; //adds the enemy's point value to the total score
            gameManager.PlayKaChingSound(); //plays the ka-ching sound from the gamemanager
            Destroy(this.gameObject, timeToDeathAfterHit); //destroys the enemy after a short time
        }
    }

    internal void SetHomeLoc(Vector3 position)
    {
        this._homeLoc = position;
    }
}
