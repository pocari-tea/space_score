using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    
    public GameObject nonDeleteWall;
    
    [SerializeField] private Transform laserGenerationLocation;
    
    private bool _isAttackCooltime = false;

    private void Start()
    {
        StartCoroutine(CoolTime(1f));
    }

    void Update()
    {
        transform.Translate(Vector2.up * (enemyData.MoveSpeed * Time.deltaTime));

        if (enemyData.Bullet != null)
        {
            BulletAttack();
        }
    }

    private void BulletAttack()
    {
        if (_isAttackCooltime)
        {
            _isAttackCooltime = false;

            var effectZ = transform.rotation.eulerAngles.z + transform.localScale.x;
            var laserGameobject = Instantiate(enemyData.Bullet, laserGenerationLocation.position, Quaternion.Euler(0, 0, effectZ));

            Transform playerTransform = laserGameobject.transform;
            playerTransform.localScale = Vector3.one;
            var position = playerTransform.position;
            position = new Vector3(position.x, position.y, 1);
            playerTransform.position = position;
            
            StartCoroutine(CoolTime(4f));
        }
    }
    
    /// <summary>
    /// 공격 쿨타임
    /// </summary>
    /// <param name="time">쿨타임 시간</param>
    private IEnumerator CoolTime(float time)
    {
        while (time > 0f)
        {
            time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        _isAttackCooltime = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (nonDeleteWall != other.gameObject)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // 점수 추가
                GameManager.ScoreController.Score = enemyData.Score;
                GameManager.ScoreController.OnScore();
                
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("PlayerBullet"))
            {
                // 점수 추가
                GameManager.ScoreController.Score = enemyData.Score;
                GameManager.ScoreController.OnScore();
                
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
    }
}