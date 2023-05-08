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
    public const float Speed = 2.0f;
    /// <summary>
    /// 회전 속도
    /// </summary>
    public const float RotationSpeed = 300.0F;
    
    /// <summary>
    /// 게임오버 주체
    /// </summary>
    private GameOverSubject _gameOverSubject = new GameOverSubject();

    private void Start()
    {
        life = _maxLife;
    }
    
    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            _gameOverSubject.NotifyObservers();
        }
    }

    public void AddObserver(IGameOverObserver observer)
    {
        _gameOverSubject.AddObserver(observer);
    }

    public void RemoveObserver(IGameOverObserver observer)
    {
        _gameOverSubject.RemoveObserver(observer);
    }
}
