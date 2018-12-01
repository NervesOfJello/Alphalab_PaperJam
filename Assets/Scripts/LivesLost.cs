using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum LivesStatus { Idle, Reset }
[RequireComponent(typeof(BoxCollider2D))]
public class LivesLost : MonoBehaviour {
    public static LivesStatus state = LivesStatus.Idle;
    public Image[] Lives = new Image[3]; 
    
    [SerializeField]
    private string TagNameForEnemies = "enemyexit";
    private void Start()
    {
        
    }
    private void Update()
    {
        if (state == LivesStatus.Reset)
        {
            for (int i = 0; i < Lives.Length; i++)
            {
                Lives[i].gameObject.SetActive(true);
            }
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
        for (int i = 0; i < Lives.Length; i++)
        {
            if (Lives[i].gameObject.activeInHierarchy)
            {
                Lives[i].gameObject.SetActive(false);
                break;
            }
        }
        
    }
}
