using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the creation of projectiles from user input.
public class ShootFunctionality : MonoBehaviour {

    // The delay in seconds, between firing shots.
    [SerializeField]
    private float shootDelay;

    // Records the last time that a projectile was fired.
    private float lastShootTime = 0;

	// Update is called once per frame
	void Update ()
    {
        // TODO Replace with GetButtonDown.
		if (Input.GetKeyDown(KeyCode.D))
        {
            // Has enough time passed to shoot again?
            if (Time.time - lastShootTime > shootDelay)
            {
                // Instantiate a new projectile from the one that is offscreen.
                // TODO reference the player position when instantiating this object.
                GameObject newProjectile = Instantiate(ProjectileBehaviour.projectilePrefab, Vector3.zero, Quaternion.identity);

                // Update the last shoot time.
                lastShootTime = Time.time;
            }
        }
	}
}