using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * (BulletModel.Speed * Time.deltaTime));
    }
}

public class BulletModel : MonoBehaviour
{
    public const float Speed = 10;
}
