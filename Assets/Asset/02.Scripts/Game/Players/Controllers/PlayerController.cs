using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [Header("스크립트")] 
    [SerializeField] private PlayerModel playerModel;
    
    [Header("레이저 프리팹")]
    [SerializeField] public GameObject prefabLaser;
    
    [Header("레이저 생성 위치")] 
    [SerializeField] private Transform laserGenerationLocation;
    
    /// <summary>
    /// 게임오버 주체
    /// </summary>
    private GameOverSubject _gameOverSubject = new GameOverSubject();
    
    /// <summary>
    /// HP 주체
    /// </summary>
    private HPSubject _hpSubject = new HPSubject();

    private Vector2 _moveDirection; 
    private bool _isAttackCooltime = true;
    private bool _isAttackCheck = false;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip laserAudioClip;
    [SerializeField] private AudioClip hitAudioClip;

    private float _coolTime = 0.5f;

    private bool _isGhost = false;

    private SpriteRenderer _sr;
    private Color _halfA = new Color(1, 1, 1, 0.5f);
    private Color _fullA = new Color(1, 1, 1, 1);

    private void Start()
    {
        _sr = gameObject.GetComponent<SpriteRenderer>();
        
        _coolTime -= (PlayerPrefs.GetInt("AttackSpeedLevel", 1) - 1) * 0.05f;
    }

    // Update is called once per frame
    private void Update()
    {
        AutoMove();

        if (_moveDirection != Vector2.zero)
        {
            Move();
        }

        if (_isAttackCheck)
        {
            Attack();
        }
    }

    /// <summary>
    /// 자동 전진
    /// </summary>
    private void AutoMove()
    {
        var distanceY = Time.deltaTime * 3.5f;
        gameObject.transform.Translate(0, distanceY, 0);
    }

    /// <summary>
    /// 플레이어 이동키
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();

        _moveDirection = new Vector2(input.x, input.y);
    }
    
    /// <summary>
    /// 플레이어 이동
    /// </summary>
    public void Move()
    {
        //아까 지정한 Axes를 통해 키의 방향을 판단하고 속도와 프레임 판정을 곱해 이동량을 정해줍니다.
        var distanceX = _moveDirection.x * PlayerModel.RotationSpeed * Time.deltaTime;
        var distanceY = _moveDirection.y * Time.deltaTime * PlayerModel.Speed;
        
        //이동량만큼 실제로 이동을 반영합니다.
        gameObject.transform.Translate(0, distanceY, 0);
        gameObject.transform.Rotate(0, 0, -distanceX);
    }

    /// <summary>
    /// 공격키
    /// </summary>
    public void OnAttack(InputAction.CallbackContext context)
    {
        _isAttackCheck = context.performed;
    }
    
    /// <summary>
    /// 공격
    /// </summary>
    public void Attack()
    {
        if (_isAttackCooltime)
        {
            _isAttackCooltime = false;

            audioSource.PlayOneShot(laserAudioClip);

            var effectZ = transform.rotation.eulerAngles.z + transform.localScale.x;
            var laserGameobject = Instantiate(prefabLaser, laserGenerationLocation.position,Quaternion.Euler(0, 0, effectZ));
        
            Transform playerTransform = laserGameobject.transform;
            playerTransform.localScale = Vector3.one;
            var position = playerTransform.position;
            position = new Vector3(position.x, position.y, 1);
            playerTransform.position = position;
        
            StartCoroutine(CoolTime(_coolTime));
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
        if (other.gameObject.CompareTag("Wall"))
        {
            TakeDamage(99);
        }
        else if (!_isGhost)
        {
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
            {
                TakeDamage(1);
            }
        }
    }
    
    public void TakeDamage(int damage)
    {
        playerModel.life -= damage;
        
        if (playerModel.life <= 0)
        {
            _gameOverSubject.NotifyObservers();
        }
        else
        {
            StartCoroutine(nameof(GhostState));
            
            _hpSubject.NotifyObservers();
            
            audioSource.PlayOneShot(hitAudioClip);
        }
    }

    // Player layer ghost
    IEnumerator GhostState()
    {
        _isGhost = true;

        IEnumerator ghostCoolTime = GhostCoolTime(3.0f);
        StartCoroutine(ghostCoolTime);

        while (_isGhost)
        {
            yield return new WaitForSeconds(0.1f);
            _sr.color = _halfA;
            yield return new WaitForSeconds(0.1f);
            _sr.color = _fullA;
        }
        
        yield return 0;
    }
    
    /// <summary>
    /// 무적 쿨타임
    /// </summary>
    /// <param name="time">쿨타임 시간</param>
    private IEnumerator GhostCoolTime(float time)
    {
        while (time > 0f)
        {
            time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        
        _isGhost = false;
    }
    
    public void AddObserver(IGameOverObserver observer)
    {
        _gameOverSubject.AddObserver(observer);
    }

    public void RemoveObserver(IGameOverObserver observer)
    {
        _gameOverSubject.RemoveObserver(observer);
    }
    
    public void AddHPObserver(IHPObserver observer)
    {
        _hpSubject.AddObserver(observer);
    }

    public void RemoveHPObserver(IHPObserver observer)
    {
        _hpSubject.RemoveObserver(observer);
    }
}
