using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LivesStatus { Idle, Reset }
[RequireComponent(typeof(BoxCollider2D))]
public class LivesLost : MonoBehaviour {
    public static LivesStatus state = LivesStatus.Idle;
    [SerializeField]
    private string TagNameForEnemies = "enemyexit";
    [SerializeField]
    private int livesToStartWith = 3;
    [HideInInspector]
    public static int Lives;
    [SerializeField]
    private int livesToTake = 1;
    private void Start()
    {
        Lives = livesToStartWith;
    }
    private void Update()
    {
        if (state == LivesStatus.Reset)
        {
            Lives = livesToStartWith;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToLower() == TagNameForEnemies)
        {
            TakeAwayLife();
        }
        Debug.Log("Lives: " + Lives);
    }
    private void TakeAwayLife()
    {
        Lives -= livesToTake;
        if (Lives < 0)
        {
            Lives = 0;
        }
        
    }
}
