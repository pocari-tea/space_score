using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Data", menuName = "Scriptable Object/Bullet Data", order = int.MaxValue)]
public class BulletData : ScriptableObject
{
    [SerializeField] private bool playerThing;
    public bool PlayerThing
    {
        get { return playerThing; }
    }
    
    [SerializeField] private float moveSpeed;
    public float MoveSpeed
    {
        get { return moveSpeed; }
    }
}

