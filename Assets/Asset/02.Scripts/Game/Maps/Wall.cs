using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public enum EnemyType
{
    Meteor,
    SpaceShip
}

public class Wall : MonoBehaviour
{
    [SerializeField] private List<EnemyData> enemyDatas;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private GameObject[] wall;
    [SerializeField] private GameObject dangerMarkPrefab;

    private bool _isCooltime = true;
    
    void Update()
    {
        if (_isCooltime)
        {
            EnemyCreate();
        }
    }

    /// <summary>
    /// 적 생성 위치 정하기
    /// </summary>
    private void EnemyCreate()
    {
        var randomWall = Random.Range(0, 4);
        var createAngle = 0;
        var createPosition = Vector3.zero;
        
        Transform createWall = wall[randomWall].transform;
        
        switch (randomWall)
        {
            case 0:
                createAngle = 0;
                createPosition = new Vector3(Random.Range(wall[1].transform.position.x - 0.7f, wall[3].transform.position.x + 0.7f), createWall.position.y + 0.4f, 0);
                break;
            case 1:
                createAngle = 90;
                createPosition = new Vector3(createWall.position.x - 0.4f, Random.Range(wall[0].transform.position.y + 0.7f, wall[2].transform.position.y - 0.7f), 0);
                break;
            case 2:
                createAngle = 180;
                createPosition = new Vector3(Random.Range(wall[1].transform.position.x - 0.7f, wall[3].transform.position.x + 0.7f), createWall.position.y - 0.4f, 0);
                break;
            case 3:
                createAngle = 270;
                createPosition = new Vector3(createWall.position.x + 0.4f, Random.Range(wall[0].transform.position.y + 0.7f, wall[2].transform.position.y - 0.7f), 0);
                break;
        }
        _isCooltime = false;

        StartCoroutine(CreateMarkEnemy(createWall, createAngle, createPosition));

        StartCoroutine(CoolTime(1));   
    }
    
    /// <summary>
    /// 위험 마크 생성
    /// </summary>
    /// <param name="createWall"> 생성 벽 </param>
    /// <param name="createAngle"> 생성 각도 </param>
    /// <param name="createPosition"> 생성 위치 </param>
    IEnumerator CreateMarkEnemy(Transform createWall, int createAngle, Vector3 createPosition)
    {
        GameObject dangerMark = Instantiate(dangerMarkPrefab, createPosition, Quaternion.Euler(0, 0, createAngle));
        
        yield return new WaitForSeconds(2f);
        Destroy(dangerMark);

        CreateEnemy(createWall, createAngle, createPosition);
    }

    /// <summary>
    /// 위험 마크에 적 생성
    /// </summary>
    /// <param name="createWall"> 생성 벽 </param>
    /// <param name="createAngle"> 생성 각도 </param>
    /// <param name="createPosition"> 생성 위치 </param>
    private void CreateEnemy(Transform createWall, int createAngle, Vector3 createPosition)
    {
        var enemyType= Random.Range(0, enemyDatas.Count);
        var enemy = Instantiate(enemyPrefabs[enemyType], createPosition, Quaternion.Euler(0, 0, createAngle)).GetComponent<Enemy>();
        enemy.enemyData = enemyDatas[enemyType];
        enemy.nonDeleteWall = createWall.gameObject;
            
        Transform enemyCreateTrans = enemy.transform;
        enemyCreateTrans.position = createPosition;
    }
    
    IEnumerator CoolTime(float time)
    {
        while (time > 0f)
        {
            time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        _isCooltime = true;
    }
}