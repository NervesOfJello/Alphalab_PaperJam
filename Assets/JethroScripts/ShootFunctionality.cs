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
    [SerializeField]
    private Transform paperSpawn;

    // Records the last time that a projectile was fired.
    private float lastShootTime = 0;

    // Animator component
    private Animator playerAnimator;

    //Audio Component
    private AudioSource throwAudioSource;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>(); // initialize animator component
        throwAudioSource = GetComponent<AudioSource>(); // initialize audio source component
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
                throwAudioSource.Play(); // plays throw sound

                // Instantiate a new projectile from the one that is offscreen.
                // TODO reference the player position when instantiating this object.
                Instantiate(projectilePrefab.gameObject, paperSpawn.position, Quaternion.identity);

                // Update the last shoot time.
                lastShootTime = Time.time;
                //trigger exit time on the throwing animation
            }
        }
	}
}