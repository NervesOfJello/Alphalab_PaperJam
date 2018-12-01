using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public int Score;

    private AudioSource cashAudioSource;
	// Use this for initialization
	void Start () 
	{
        cashAudioSource = GetComponent<AudioSource>();
	}

    public void PlayKaChingSound()
    {
        cashAudioSource.Play();
    }
}
