using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedEnemy_Anim : MonoBehaviour {

    private EnemyInfo enemyInfo; //enemy info script component
    private Animator enemyAnimator; //enemy animator component

    // Use this for initialization
    void Start()
    {
        enemyInfo = GetComponent<EnemyInfo>(); //initializes the enemy info script component to access health Left
        enemyAnimator = GetComponent<Animator>(); //initializes the animator component
    }

    // Update is called once per frame
    void Update()
    {
        updateAnimatorVariables();
    }

    //updates animator variables
    void updateAnimatorVariables()
    {
        enemyAnimator.SetInteger("HealthLeft", enemyInfo.hitsToDefeat);
        Debug.Log("hitstoDefeat" + enemyInfo.hitsToDefeat);
    }
}
