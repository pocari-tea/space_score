using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 5.0f;
    [SerializeField] private GameObject DIED;
    private float rotationSpeed = 300.0F;
    private Vector2 direction; 
    private bool cooltime = true;
    
    [SerializeField] private GameObject LaserPrefab;

    private void Start()
    {
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 메소드 호출
        GetInput();
        Move();
        Laser();
    }

    // 움직이는 기능을 하는 메소드
    private void Move()
    {
        float distanceY = Time.deltaTime * 5.0f;
        this.gameObject.transform.Translate(0, distanceY, 0);
    }

    private void GetInput()
    {
        float distanceY = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        //아까 지정한 Axes를 통해 키의 방향을 판단하고 속도와 프레임 판정을 곱해 이동량을 정해줍니다.
        this.gameObject.transform.Translate(0, distanceY, 0);
        //이동량만큼 실제로 이동을 반영합니다.

        float distanceX = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        this.gameObject.transform.Rotate(0, 0, -distanceX);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        {
            if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("L_Wall") || other.gameObject.CompareTag("R_Wall") || other.gameObject.CompareTag("Enemy"))
            {
                DIED.SetActive(true);
                Time.timeScale = 0;

                Destroy(this.gameObject);
            }
        }
    }

    private void Laser()
    {
        if (Input.GetKey(KeyCode.J) && cooltime == true)
        {
            float effect_z = transform.rotation.eulerAngles.z + transform.localScale.x;

            GameObject laser = Instantiate(LaserPrefab,
                transform.position,
                Quaternion.Euler(0, 0, effect_z));

            Transform player = laser.GetComponent<Transform>();
            player.localScale = new Vector3(1, 1, 1);
            player.position = new Vector3(player.position.x, player.position.y, 1);

            cooltime = false;
            
            StartCoroutine(CoolTime(0.5f));
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
