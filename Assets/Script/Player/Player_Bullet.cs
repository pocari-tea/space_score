using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "L_Wall" || other.gameObject.tag == "R_Wall" || other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
