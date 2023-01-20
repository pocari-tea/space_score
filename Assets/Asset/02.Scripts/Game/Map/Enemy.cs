using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public GameObject nonDeleteWall;
    
    void Update()
    {
        transform.Translate(Vector2.up * (EnemyModel.Speed * Time.deltaTime));
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (nonDeleteWall != other.gameObject)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerBullet") || other.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
    }
}

public class EnemyModel : MonoBehaviour
{
    public const float Speed = 5f;
}