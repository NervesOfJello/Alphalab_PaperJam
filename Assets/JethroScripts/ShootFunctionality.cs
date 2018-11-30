using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the creation of projectiles from user input.
public class ShootFunctionality : MonoBehaviour {

    // The delay in seconds, between firing shots.
    [SerializeField]
    private float shootDelay;

    [SerializeField]
    private ProjectileBehaviour projectilePrefab;

    // Records the last time that a projectile was fired.
    private float lastShootTime = 0;

    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        // TODO Replace with GetButtonDown.
		if (Input.GetButtonDown("Fire1"))
        {
            // Has enough time passed to shoot again?
            if (Time.time - lastShootTime > shootDelay)
            {
                //start the throwing animation
                playerAnimator.SetTrigger("Throw");

                // Instantiate a new projectile from the one that is offscreen.
                // TODO reference the player position when instantiating this object.
                Instantiate(projectilePrefab.gameObject, transform.position, Quaternion.identity);

                // Update the last shoot time.
                lastShootTime = Time.time;
                //trigger exit time on the throwing animation
            }
        }
	}
}