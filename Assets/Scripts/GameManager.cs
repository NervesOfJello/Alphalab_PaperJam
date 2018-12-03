using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    [HideInInspector]
    public static int Score;
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
        
        if (LivesLost.Lives == 0)
        {
            Score = 0;
            Panel.CurrentScreen = PanelScreen.Gameover;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void PlayKaChingSound()
    {
        cashAudioSource.Play();
    }
}
