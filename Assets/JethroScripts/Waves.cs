using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class takes in all of the waves for the game.
// Then based on passed time, it spawns the waves
public class Waves : MonoBehaviour
{
    // Prefabs used to instantiate the enemies.
    [SerializeField]
    private GameObject smallEnemyPrefab;
    [SerializeField]
    private GameObject mediumEnemyPrefab;
    [SerializeField]
    private GameObject largeEnemyPrefab;

    // The locations that enemies can be spawned at.
    [SerializeField]
    private List<Transform> spawnLocations = new List<Transform>();

    // The waves for the current game.
    private List<Wave> gameWaves = new List<Wave>();

    // Tracks the current wave that the game is on.
    private int currentWave = 0;

    private List<GameObject> currentEnemies = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        // Parse all of the waves on this object.
		foreach(Wave wave in gameObject.GetComponents<Wave>())
        {
            // Figure out where this wave will fall in the order based on spawn order.
            int indexToPlaceAt = 0;
            foreach(Wave currentWave in gameWaves)
            {
                // Is the wave sooner than the next position? Place it here if so.
                if (currentWave.waveNumber > wave.waveNumber)
                {
                    break;
                }
                indexToPlaceAt++;
            }

            // Insert the wave at the appropriate position.
            gameWaves.Insert(indexToPlaceAt, wave);
        }
	}

    // Debug in the following section allows for testing kills with "k".
    // DEBUG ONLY
    int debugCounter = 0;

    // Update is called once per frame
    void Update ()
    {
        // DEBUG ONLY
        if (Input.GetKeyDown(KeyCode.K))
        {
            Destroy(currentEnemies[debugCounter]);
            Debug.Log("Current wave contains enemies: " + currentEnemies.Count);
            debugCounter++;
        }

        // Should the next wave be spawned?
        bool spawnNextWave = true;
        foreach (GameObject enemy in currentEnemies)
        {
            // If any enemy currently spawned is non-null,
            // do not spawn the next wave.
            if (enemy != null)
            {
                spawnNextWave = false;
            }
        }

        // Are there no enemies on screen? (Spawn the next wave).
        if (spawnNextWave)
        {
            // DEBUG ONLY
            debugCounter = 0;

            // Clear the current enemies list:
            currentEnemies.Clear();

            // Spawn the small enemies for the next wave.
            foreach (Vector2 group in gameWaves[currentWave].smallEnemyGroups)
            {
                // Get the group size as an int.
                int groupSize = Mathf.Abs((int)group.x);

                // Get the spawn position as an int.
                int spawnPosition = Mathf.Abs((int)group.y);

                for (int i = 0; i < groupSize; i++)
                {
                    currentEnemies.Add(Instantiate(smallEnemyPrefab, spawnLocations[spawnPosition].position, Quaternion.identity));
                }
            }

            // Spawn the medium enemies for the next wave.
            foreach (Vector2 group in gameWaves[currentWave].mediumEnemyGroups)
            {
                // Get the group size as an int.
                int groupSize = Mathf.Abs((int)group.x);

                // Get the spawn position as an int.
                int spawnPosition = Mathf.Abs((int)group.y);

                for (int i = 0; i < groupSize; i++)
                {
                    currentEnemies.Add(Instantiate(mediumEnemyPrefab, spawnLocations[spawnPosition].position, Quaternion.identity));
                }
            }

            // Spawn the large enemies for the next wave.
            foreach (Vector2 group in gameWaves[currentWave].largeEnemyGroups)
            {
                // Get the group size as an int.
                int groupSize = Mathf.Abs((int)group.x);

                // Get the spawn position as an int.
                int spawnPosition = Mathf.Abs((int)group.y);

                for (int i = 0; i < groupSize; i++)
                {
                    currentEnemies.Add(Instantiate(largeEnemyPrefab, spawnLocations[spawnPosition].position, Quaternion.identity));
                }
            }

            // Increment the current wave.
            currentWave++;
        }
	}
}