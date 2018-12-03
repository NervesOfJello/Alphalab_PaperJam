using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {
    public static int ScoreMoney = 0;
    public string textToDisplayBeforeScore;
    public Text ScoreText;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
	}
    private void OnGUI()
    {
        ScoreText.text = textToDisplayBeforeScore + " $" + ScoreMoney;
    }
}
