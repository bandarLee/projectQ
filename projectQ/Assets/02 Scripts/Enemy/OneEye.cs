using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneEye : MonoBehaviour // follow 타입
{
    public float aboveY = 1f; // enemy가 player 위에 떠다닐 y축 거리
    public float Health = 2;
    public ItemSpawner itemspawner;
    public bool replacesuccess = false;
    // 플레이어를 따라가는 속도
    public float Movespeed;

    // 위아래로 흔들리는 속도 
    public float Movespeed2;

    // 잔상 프리팹
    public GameObject shadowPrefab; //프리팹 OneEyeMon(clone) 쓰임: OneEyeMon 스크립트 가져다 씀.

    // 잔상 생성 지연 여부
    public bool isDelay;

    // 잔상 생성 주기
    public float Respawntime = 1f;

    // 위아래 흔들림 주기
    public float swingtime = 0.6f;

    // 잔상 생성까지 남은 시간
    public float time;

    // 위아래 흔들림 상태 변경까지 남은 시간
    public float time2;

    private Vector3 initialPosition;

    // 몬스터 등장 이후 누적 시간
    public float progressTime = 0;
    public float replaceTime = 3f;
    public GameObject UpgradePrefab;

    [Header("총알 프리팹")]
    public GameObject MonsterBullet;

    [Header("총구들")]
    public GameObject[] Muzzles;

    [Header("타이머")]
    public float Timer = 5.6f;
    public const float COOL_TIME = 0.6f;

    private void Awake()
    {
        initialPosition = transform.position;

    }
    private void OnEnable()
      {
        Health = 2;
        replacesuccess = false;
        time = 0; 
        progressTime = 0;
        time2 = 0;
        transform.position = initialPosition;


    }
    void Update()
    {
        // 위로 이동하는 방향
        Vector2 dir1 = new Vector2(0, 0.1f);

        // 아래로 이동하는 방향
        Vector2 dir2 = new Vector2(0, -0.1f);

      
        Vector2 dir3 = new Vector2((Player.Instance.transform.position.x - this.transform.position.x), (Player.Instance.transform.position.y + aboveY - this.transform.position.y));

        // 플레이어를 향해 이동
        dir3.Normalize();
            transform.position += (Vector3)(dir3 * Movespeed * Time.deltaTime);
        

        // 잔상 생성 주기를 계산
        if (isDelay)
        {
            time += Time.deltaTime;
            if (time >= Respawntime)
            {
                time = 0.0f;
                isDelay = false;
            }
        }


        // 위아래 흔들림 주기를 계산
        time2 += Time.deltaTime;
        Timer -= Time.deltaTime;

        if (time2 >= swingtime)
        {
            time2 = 0.0f;
        }

        // 플레이어를 향하는 방향으로 이동하면서 잔상 생성
        if (!isDelay)
        {
            GameObject enemy = Instantiate(shadowPrefab);
            enemy.transform.position = this.transform.position;
            isDelay = true;
        }

        //위아래 흔들림
        if (time2 < 0.4f) //위로 이동
        {
            transform.position += (Vector3)(dir1 * Movespeed2 * Time.deltaTime);

        }
        if (time2 > 0.4f) //아래로 이동
        {
            transform.position += (Vector3)(dir2 * Movespeed2 * Time.deltaTime);
        }
        if (!replacesuccess)
        {
            progressTime += Time.deltaTime;
        }
        if (progressTime > replaceTime)
        {
            ReplacePrefab();
            replacesuccess = true;

            progressTime = 0.0f;
            // 타이머 계산

            Fire();
        }
    }

    private void Fire()
    {
        Timer = COOL_TIME;

        if (Timer <= 0)
        {
            // 타이머 초기화

            for (int i = 0; i < Muzzles.Length; i++)
            {
                // 1. 총알을 만들고
               GameObject bullet = Instantiate(MonsterBullet);

                // 2. 위치를 설정한다.
                bullet.transform.position = Muzzles[i].transform.position;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        // 플레이어의 공격을 받았을 때 죽는다
        if (collision.collider.CompareTag("Bullet")) //enemy와 총알이 부딪혔을 때 
        {
            Health -= Player.Instance.BulletPower;

            // 적의 체력이 끝
            if (Health <= 0)
            {

                gameObject.SetActive(false);
            }
        }
    }



    public void ReplacePrefab()
    {
        GameObject newObject = Instantiate(UpgradePrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        gameObject.SetActive(false);
    }
}



