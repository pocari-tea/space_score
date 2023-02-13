using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [Header("스크립트")] 
    [SerializeField] private PlayerModel playerModel;
    
    [Header("레이저 프리팹")]
    [SerializeField] public GameObject prefabLaser;
    
    [Header("레이저 생성 위치")] 
    [SerializeField] private Transform laserGenerationLocation;
    
    private Vector2 _direction; 
    private bool _isAttackCooltime = true;

    // Update is called once per frame
    private void Update()
    {
        AutoMove();
        
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");
        MoveController(inputY, inputX);

        if (Input.GetKey(KeyCode.J))
        {
            AttackLaser();
        }
    }

    /// <summary>
    /// 라이프 다운
    /// </summary>
    private void LifeDown()
    {
        playerModel.life -= 1;
    }

    /// <summary>
    /// 자동 전진
    /// </summary>
    private void AutoMove()
    {
        var distanceY = Time.deltaTime * 5.0f;
        gameObject.transform.Translate(0, distanceY, 0);
    }

    /// <summary>
    /// 플레이어 조작
    /// </summary>
    /// <param name="x">좌우 이동</param>
    /// <param name="y">속도 가속 </param>
    public void MoveController(float x, float y)
    {
        //아까 지정한 Axes를 통해 키의 방향을 판단하고 속도와 프레임 판정을 곱해 이동량을 정해줍니다.
        var distanceY = x * Time.deltaTime * PlayerModel.Speed;
        var distanceX = y * PlayerModel.RotationSpeed * Time.deltaTime;
        
        //이동량만큼 실제로 이동을 반영합니다.
        gameObject.transform.Translate(0, distanceY, 0);
        gameObject.transform.Rotate(0, 0, -distanceX);
    }
    
    /// <summary>
    /// 공격
    /// </summary>
    public void AttackLaser()
    {
        if (_isAttackCooltime)
        {
            _isAttackCooltime = false;

            var effectZ = transform.rotation.eulerAngles.z + transform.localScale.x;
            var laserGameobject = Instantiate(prefabLaser, laserGenerationLocation.position,Quaternion.Euler(0, 0, effectZ));
            
            Transform playerTransform = laserGameobject.transform;
            playerTransform.localScale = Vector3.one;
            var position = playerTransform.position;
            position = new Vector3(position.x, position.y, 1);
            playerTransform.position = position;
            
            StartCoroutine(CoolTime(0.5f));
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            LifeDown();
        }
    }
}
