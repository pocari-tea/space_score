﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        
        Destroy(gameObject, 4f);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        {
            if (other.gameObject.CompareTag("L_Wall"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}