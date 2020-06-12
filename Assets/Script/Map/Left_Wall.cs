using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Left_Wall : MonoBehaviour
{
    private bool cooltime = true;
    private float Rand;
    [SerializeField] private GameObject EnemyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        Rand = 4;
        
        Debug.Log(Rand);
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Create();
    }

    private void Enemy_Create()
    {
        if (cooltime == true)
        {
            GameObject Enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.Euler(0, 0, 90));

            Transform Wall = Enemy.GetComponent<Transform>();
            Wall.localScale = new Vector3(1, 1, 1);
            Wall.position = new Vector3(Wall.position.x + 1, Random.Range(-Rand, Rand), 1);

            cooltime = false;
    
            StartCoroutine(CoolTime(Random.Range(1, 4)));   
        }
    }
    
    IEnumerator CoolTime(float time)
    {
        while (time > 0f)
        {
            time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        cooltime = true;
    }
}
