using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerModel : MonoBehaviour
{
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
}
