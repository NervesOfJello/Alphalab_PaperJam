using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LivesLost : MonoBehaviour {
    [SerializeField]
    private string TagNameForEnemies = "enemyexit";
    public static int Lives = 3;
    [SerializeField]
    private int livesToTake = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToLower() == TagNameForEnemies)
        {
            TakeAwayLife();
        }
        Debug.Log("Lives: "+Lives);
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
