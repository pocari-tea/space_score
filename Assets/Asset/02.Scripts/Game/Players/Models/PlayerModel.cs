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
    private int _maxLife;
    /// <summary>
    /// 라이프
    /// </summary>
    public int life;
    /// <summary>
    /// 이동속도
    /// </summary>
    public const float Speed = 1.3f;
    /// <summary>
    /// 회전 속도
    /// </summary>
    public const float RotationSpeed = 230.0F;  

    private void Start()
    {
        _maxLife = PlayerPrefs.GetInt("HpLevel", 1);
        
        life = _maxLife;
    }
}
