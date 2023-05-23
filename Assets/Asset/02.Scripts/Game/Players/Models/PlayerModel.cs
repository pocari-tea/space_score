using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerModel : MonoBehaviour
{
    /// <summary>
    ///  최대 체력
    /// </summary>
    private int _maxLife = 2;
    /// <summary>
    /// 라이프
    /// </summary>
    public int life = 1;
    /// <summary>
    /// 이동속도
    /// </summary>
    public const float Speed = 1.2f;
    /// <summary>
    /// 회전 속도
    /// </summary>
    public const float RotationSpeed = 200.0F;  

    private void Start()
    {
        life = _maxLife;
    }
}
