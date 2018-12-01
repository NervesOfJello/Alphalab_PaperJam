using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores values for a wave.
public class Wave : MonoBehaviour
{
    // When will this wave spawn?
    [SerializeField]
    public int waveNumber;

    [Header("X = Number of enemies")]
    [Header("Y = Spawn region")]

    // The enemy groups of the wave.
    [SerializeField]
    public Vector2[] smallEnemyGroups;

    [SerializeField]
    public Vector2[] mediumEnemyGroups;

    [SerializeField]
    public Vector2[] largeEnemyGroups;
}