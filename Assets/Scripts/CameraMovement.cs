using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    private Transform playerTransform; //the transform component of the player
    [SerializeField]
    private float xOffset; //horizontal camera offset from player position
    [SerializeField]
    private float yOffset; //vertical camera offset from player position
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    void setCameraPositionWithOffset()
    {
        transform.position = new Vector2(playerTransform.position.x + xOffset, playerTransform.position.y + yOffset);
    }
}
