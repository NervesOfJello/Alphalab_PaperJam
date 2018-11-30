using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This goes on each instance of the paper projectile created.
public class ProjectileBehaviour : MonoBehaviour
{
    // The rigidbody on this object.
    private Rigidbody2D body;


    // The speed at which the paper is launched forward.
    [SerializeField]
    private float launchSpeed;

    // The torque added to the paper upon launch.
    [SerializeField]
    private float spinSpeed;


    // When this projectile is created, spawn it at the players hand.
    private void Start()
    {
        // Get the rigidbody component on this object.
        body = transform.GetComponent<Rigidbody2D>();

        // transform.position = Player Position + offset

        // Apply the forces for this object to move.
        body.AddForce(Vector2.up * launchSpeed);
        body.AddTorque(spinSpeed);
    }

    // Called when the paper hits a customer.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Removes this paper object from the screen.
        Destroy(gameObject);
    }
}