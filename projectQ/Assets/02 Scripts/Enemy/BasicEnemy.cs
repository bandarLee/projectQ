using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Snake;

public class BasicEnemy : MonoBehaviour  // "Basic형"
{ 
    public float Health = 1;

    public ItemSpawner itemspawner;

    // 위아래로 흔들리는 속도 
    public float Movespeed2;

    // 위아래 흔들림 주기
    public float swingtime = 2f;
    // 위아래 흔들림 상태 변경까지 남은 시간
    public float time2;

    private Vector3 initialPosition;

    // - 속력
    public float Speed = 2f; 
    // - 방향
    public Vector2 _dir;


    [Header("총알 프리팹")]
    public GameObject MonsterBullet;

    [Header("총구들")]
    public GameObject[] Muzzles;

    [Header("타이머")]
    public float Timer = 0f;
    public const float COOL_TIME = 2f;
    private void OnEnable()
    {
        Health = 1;
        transform.position = initialPosition;

    }
    private void Awake()
    {
        initialPosition = transform.position;

    }
    void Start()
    {
    }

    void Update()
    {
        // 타이머 계산
        Timer -= Time.deltaTime;
        if (Timer <= 0)
            Fire();

        // 위로 이동하는 방향
        Vector2 dir1 = new Vector2(0, 1f);

        // 아래로 이동하는 방향
        Vector2 dir2 = new Vector2(0, -1f);

        // 위아래 흔들림 주기를 계산
        time2 += Time.deltaTime;
        if (time2 >= swingtime)
        {
            time2 = 0.0f;
        }

        //위아래 흔들림
        if (time2 < 1f) //위로 이동
        {
            transform.position += (Vector3)(dir1 * Movespeed2 * Time.deltaTime);

        }
        if (time2 > 1f) //아래로 이동
        {
            transform.position += (Vector3)(dir2 * Movespeed2 * Time.deltaTime);
        }

        // 2. 이동한다. 
        // 새로운 위치 = 현재 위치 + 속도 * 시간
        /*transform.position += (Vector3)(_dir * Speed) * Time.deltaTime;
        _dir.Normalize();*/
    }

    private void Fire()
    {
        Timer = COOL_TIME;

            for (int i = 0; i < Muzzles.Length; i++)
            {
                // 1. 총알을 만들고
                GameObject bullet = Instantiate(MonsterBullet);

                // 2. 위치를 설정한다.
                bullet.transform.position = Muzzles[i].transform.position;
            }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Environment")
        {

            WallManager roomManager = collision.collider.GetComponent<WallManager>();
            if (roomManager.walltype == WallManager.WallType.Bot)
            {
                _dir = Vector2.up;
            }
            else if (roomManager.walltype == WallManager.WallType.Top)
            {
                _dir = Vector2.down;
            }
            else if (roomManager.walltype == WallManager.WallType.Left)
            {
                _dir = Vector2.right;
            }
            else if (roomManager.walltype == WallManager.WallType.Right)
            {
                _dir = Vector2.left;
            }
        }

        // 플레이어의 공격을 받았을 때 죽는다
        if (collision.collider.CompareTag("Bullet")) //enemy와 총알이 부딪혔을 때 
        {

            Health -= Player.Instance.BulletPower;


            // 총알 삭제
            collision.collider.gameObject.SetActive(false);

            // 적의 체력이 끝
            if (Health <= 0)
            {
                gameObject.SetActive(false);
                itemspawner.SpawnItem(this.transform.position);
            }
        }
    }
}
