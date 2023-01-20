using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerView : MonoBehaviour
{
    [Header("스크립트")] 
    [SerializeField] private PlayerController playerController;
    
    [Header("레이저 프리팹")]
    [SerializeField] public GameObject prefabLaser;

    private void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");
        Move(new Vector2(inputY, inputX));

        if (Input.GetKey(KeyCode.J))
        {
            Attack();
        }
    }
    
    /// <summary>
    /// 조작
    /// </summary>
    private void Move(Vector2 movement)
    {
        playerController.MoveController(movement.x, movement.y);
    }
    
    /// <summary>
    /// 공격
    /// </summary>
    private void Attack()
    {
        playerController.AttackLaser();
    }
}
