 using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private BulletData bulletData;

    private Rigidbody2D myRigidBody;

    private void Update()
    {
        transform.Translate(Vector2.up * (bulletData.MoveSpeed * Time.deltaTime));
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player") && !bulletData.PlayerThing)
        {
            Destroy(gameObject);
        }
    }
}