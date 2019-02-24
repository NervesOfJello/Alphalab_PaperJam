using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum LivesStatus { Idle, Reset }
[RequireComponent(typeof(BoxCollider2D))]
public class LivesLost : MonoBehaviour {
    public static LivesStatus state = LivesStatus.Idle;
    private static int lives;
    public static int Lives
    {
        get
        {
            return lives;
        }
    }
    [SerializeField]
    private Image[] LivesImage = new Image[3]; 
    
    [SerializeField]
    private string TagNameForEnemies = "enemyexit";
    private void Start()
    {

        for (int i = 0; i < LivesImage.Length; i++)
        {
            LivesImage[i] = LivesImage[i].GetComponent<Image>();
            lives += 1;
        }
        //Debug.Log(LivesImage[0]);
    }
    private void OnGUI()
    {
        if (state == LivesStatus.Reset)
        {
            for (int i = 0; i < LivesImage.Length; i++)
            {
                LivesImage[i].gameObject.SetActive(true);
                lives += 1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagNameForEnemies)
        {
            TakeAwayLife();
            Destroy(collision.gameObject);
        }
    }
    private void TakeAwayLife()
    {
        for (int i = 0; i < LivesImage.Length; i++)
        {
            if (LivesImage[i].gameObject.activeInHierarchy)
            {
                LivesImage[i].gameObject.SetActive(false);
                lives -= 1;
                if (lives < 0)
                {
                    lives = 0;
                }
                break;
            }
        }
        
    }
}
