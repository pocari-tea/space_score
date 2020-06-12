using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Score score = GameObject.Find("GameManager").GetComponent<Score>();

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player_Bullet")
        {
            score.Score_Add();
            
            Destroy(gameObject);
        }
    }
}
