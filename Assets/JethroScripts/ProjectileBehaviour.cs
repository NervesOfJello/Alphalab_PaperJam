using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This goes on each instance of the paper projectile created.
public class ProjectileBehaviour : MonoBehaviour
{
    // A reference to the first projectile object spawned from the prefab.
    public static GameObject projectilePrefab;

    // The rigidbody on this object.
    private Rigidbody2D body;

    // The speed at which the paper is launched forward.
    [SerializeField]
    private float launchSpeed;

    // The torque added to the paper upon launch.
    [SerializeField]
    private float spinSpeed;


    // When a projectile is instantiated:
    private void Start()
    {
        // Is this the first instance of the object?
        if (FindObjectsOfType<ProjectileBehaviour>().Length == 1)
        {
            // If so, set it as the prefab to instantiate from.
            projectilePrefab = gameObject;
        }
        else
        {
            // Else, apply the initial velocity values for the projectile.

            // Get the rigidbody component on this object.
            body = transform.GetComponent<Rigidbody2D>();

            // Apply the forces for this object to move.
            body.AddForce(Vector2.up * launchSpeed);
            body.AddTorque(spinSpeed);
        }
    }

    // Called when the paper hits a customer.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Removes this paper object from the screen.
        Destroy(gameObject);
    }
}