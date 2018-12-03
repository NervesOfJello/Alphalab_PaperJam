using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Manages the loading of different stages.
public class StageManager : MonoBehaviour
{
    // The locations that enemies can be spawned at.
    [SerializeField]
    public List<Transform> allLocations = new List<Transform>();

    // Enemy prefabs.
    [SerializeField]
    public GameObject smallEnemyPrefab;

    [SerializeField]
    public GameObject mediumEnemyPrefab;

    [SerializeField]
    public GameObject largeEnemyPrefab;

    // Store the stages that the game will cycle between.
    [SerializeField]
    private List<GameObject> normalStages = new List<GameObject>();

    [SerializeField]
    private List<GameObject> endlessStages = new List<GameObject>();

    // Static reference for the stage manager(this).
    public static StageManager manager;

    // Start at stage 0.
    private int currentStage = 0;

    // Tracks whether the player is currently in normal or endless stages.
    private bool inNormalStages = true;

    // Call this method when starting the game.
    /// <summary>Instructs the stage manager to start the game at stage 0</summary>
    public void StartGame()
    {
        // Add the waves component to the first stage object.
        // This starts the first wave.
        Waves newWaves = normalStages[0].AddComponent<Waves>();
    }

    private void Start()
    {
        manager = this;
        StartGame();
    }

    /// <summary>Moves onto the next stage, and deletes the old stage elements</summary>
    /// <param name="sender">The object that sent this request</param>
    public void UpdateStage(Waves sender)
    {
        // Remove the previous waves object so it cant spawn more waves.
        Destroy(sender);

        // Update the stage number:
        currentStage++;

        // Is the player currently playing normal(sequential) stages?
        if (inNormalStages)
        {
            // Ran out of normal stages?
            if (currentStage > normalStages.Count() - 1)
            {
                // Transition into endless mode.
                inNormalStages = false;
                // Start the first endless stage.
                Waves newWaves = endlessStages[0].AddComponent<Waves>();
            }
            else
            {
                // Start the waves of the next normal stage.
                Waves newWaves = normalStages[currentStage].AddComponent<Waves>();
            }
        }
        else
        {
            // Choose a random stage from the pool of endliss stages.
            int randomIndex = Random.Range(0, endlessStages.Count);

            // Load the waves of this endless stage.
            Waves newWaves = endlessStages[randomIndex].AddComponent<Waves>();
        }
    }
}
