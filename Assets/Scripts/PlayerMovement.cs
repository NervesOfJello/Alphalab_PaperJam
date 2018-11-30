using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //fields
    [SerializeField]
    private float moveSpeed;
    
    //private variables
    private float horizontalInput;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    void GetInput()
    {
        Input.GetAxis("Horizontal");
    }
}
