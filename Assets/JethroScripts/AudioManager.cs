using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private GameObject AudioMenuClick;

    [SerializeField]
    private GameObject Lives2;
    [SerializeField]
    private GameObject Lives1;
    [SerializeField]
    private GameObject Lives0;

    AudioManager previousManager;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(AudioMenuClick);
        DontDestroyOnLoad(Lives2);
        DontDestroyOnLoad(Lives1);
        DontDestroyOnLoad(Lives0);

        AudioMenuClick.SetActive(false);
        Lives2.SetActive(false);
        Lives1.SetActive(false);
        Lives0.SetActive(false);

        if (previousManager != null)
        {
            Destroy(previousManager);
        }

        previousManager = this;
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Menu click
		if (Input.GetKeyDown(KeyCode.Q))
        {
            AudioMenuClick.SetActive(true);
        }
        // Menu click
        if (Input.GetKeyDown(KeyCode.W))
        {
            Lives2.SetActive(true);
        }
        // Menu click
        if (Input.GetKeyDown(KeyCode.E))
        {
            Lives1.SetActive(true);
        }
        // Menu click
        if (Input.GetKeyDown(KeyCode.S))
        {
            Lives0.SetActive(true);
        }
    }
}
