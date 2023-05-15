using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Object/Enemy Data", order = int.MaxValue)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private string enemyName;
    public string EnemyName
    {
        get { return enemyName; }
    }
    
    [SerializeField] private int score;
    public int Score
    {
        get { return score; }
    }
    
    [SerializeField] private float sightRange;
    public float SightRange
    {
        get { return sightRange; }
    }

    [SerializeField] private float moveSpeed;
    public float MoveSpeed
    {
        get { return moveSpeed; }
    }
    
    [SerializeField] private AudioClip destroyAudioClip;
    public AudioClip DestroyAudioClip
    {
        get { return destroyAudioClip; }
    }
}
