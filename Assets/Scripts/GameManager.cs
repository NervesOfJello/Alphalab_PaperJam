using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    public int Score;

    private AudioSource cashAudioSource;
    [SerializeField]
    private Text scoreText;

	// Use this for initialization
	void Start () 
	{
        cashAudioSource = GetComponent<AudioSource>();
	}

    private void Update()
    {
        scoreText.text = Score.ToString();
    }

    public void PlayKaChingSound()
    {
        cashAudioSource.Play();
    }
}
