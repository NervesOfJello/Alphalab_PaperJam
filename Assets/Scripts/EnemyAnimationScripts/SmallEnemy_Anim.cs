using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy_Anim : MonoBehaviour {

    private EnemyInfo enemyInfo; //enemy info script component

	// Use this for initialization
	void Start () 
	{
        enemyInfo = GetComponent<EnemyInfo>(); //initializes the enemy info script component to access health Left
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
