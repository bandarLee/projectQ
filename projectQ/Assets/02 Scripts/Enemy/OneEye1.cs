using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneEye1 : MonoBehaviour // follow 타입
{
    public float aboveY = 1f; // enemy가 player 위에 떠다닐 y축 거리
    public float Health = 2;


    public ItemSpawner itemspawner;
    public bool replacesuccess = false;
    // 플레이어를 따라가는 속도
    public float Movespeed;

    // 위아래로 흔들리는 속도 
    public float Movespeed2;

    // 총알 생성 지연 여부
    public bool isMonsterDelay;

    // 위아래 흔들림 주기
    public float swingtime = 0.6f;

    // 위아래 흔들림 상태 변경까지 남은 시간
    public float time2;

    [Header("총알 프리팹")]
    public GameObject MonsterBullet;

    [Header("총구들")]
    public GameObject[] Muzzles;

    public int bulletCount = 10; // 원하는 총알의 수

    [Header("타이머")]
    public float Timer = 0f;
    public const float COOL_TIME = 0.1f;
    private void Awake()
    {
    }

    void Update()
    {
        // 위로 이동하는 방향
        Vector2 dir1 = new Vector2(0, 0.1f);

        // 아래로 이동하는 방향
        Vector2 dir2 = new Vector2(0, -0.1f);

        // player의 위치를 기반으로 'enemy의 위치'를 업데이트한다. // 플레이어 머리 위에 떠다니게 하도록
        Vector2 dir3 = new Vector2((Player.Instance.transform.position.x - this.transform.position.x), (Player.Instance.transform.position.y + aboveY - this.transform.position.y));

        // 플레이어를 향해 이동
        dir3.Normalize();
        transform.position += (Vector3)(dir3 * Movespeed * Time.deltaTime);


        if (isMonsterDelay)
        {
            Timer += Time.deltaTime;
            if( Timer >= COOL_TIME)
            {
                Timer = 0.0f;
                isMonsterDelay = false;
            }
        }
        if(!isMonsterDelay)
        {
                Fire();
            isMonsterDelay = true;
        }

            // 위아래 흔들림 주기를 계산
        time2 += Time.deltaTime;

        if (time2 >= swingtime)
        {
            time2 = 0.0f;
        }

        //위아래 흔들림
        if (time2 < 0.6f) //위로 이동
        {
            transform.position += (Vector3)(dir1 * Movespeed2 * Time.deltaTime);

        }
        if (time2 > 0.6f) //아래로 이동
        {
            transform.position += (Vector3)(dir2 * Movespeed2 * Time.deltaTime);

        }
    }

    private void Fire()
    {
        for (int i = 0; i < Mathf.Min(bulletCount, Muzzles.Length); i++)
        {
        // 총구의 위치에서 총알 오브젝트를 생성한다.
        GameObject bullet = Instantiate(MonsterBullet, Muzzles[i].transform.position, Quaternion.identity);
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
                int a = Random.Range(0, 2);
                if (a == 0)
                {
                    itemspawner.SpawnItem(this.transform.position);

                }

                gameObject.SetActive(false);
            }    
        }
    }

   

}



