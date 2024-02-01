using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;

public class Virus : MonoBehaviour // " Follow 타입 "
{
    public float Health = 1;

    public GameObject ItemPrefab_Health; // DropItem
    public GameObject ItemPrefab_Speed;
    public GameObject ItemPrefab_Money;
    public GameObject ItemPrefab_CardKey;

    public BulletType BType; // Normal 타입 등등

    // 플레이어를 따라가는 속도
    public float Movespeed;
    // 위아래로 흔들리는 속도 
    public float Movespeed2;
    // 플레이어 객체
    public GameObject _target;

    // 자기 복제 프리팹 // -> 잔상말고 똑같은 아이 자가복제 할 것임
    public GameObject shadowPrefab;
    // 자기 복제 생성 지연 여부
    public bool isCloneDelay;
    // 자기 복제 생성 주기
    public float Respawntime = 2f;

    // 위아래 흔들림 주기
    public float swingtime = 0.6f;

    // 자기 복제 생성까지 남은 시간
    public float time;

    // 위아래 흔들림 상태 변경까지 남은 시간
    public float time2;


    void Start()
    {

    }

    void Update()
    {
        // 위로 이동하는 방향
        Vector2 dir1 = new Vector2(0, 0.1f);

        // 아래로 이동하는 방향
        Vector2 dir2 = new Vector2(0, -0.1f);

        //플레이어를 향하는 방향
        Vector2 dir3 = (_target.transform.position - this.transform.position).normalized;

        // 자기 복제 생성 주기를 계산
        if (isCloneDelay)
        {

            time += Time.deltaTime;
            if (time >= Respawntime)
            {
                time = 0.0f;
                isCloneDelay = false;
            }
        }

        // 위아래 흔들림 주기를 계산
        time2 += Time.deltaTime;
        if (time2 >= swingtime)
        {
            time2 = 0.0f;
        }


        float angle = Mathf.Atan2(dir3.y, dir3.x) * Mathf.Rad2Deg;
        angle += 90f;  // 몬스터가 플레이어를 둘러싸도록 각도를 조절
        dir3 = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        transform.position += (Vector3)(dir3 * Movespeed * Time.deltaTime);


        //위아래 흔들림
        if (time2 < 0.4f) //위로 이동
        {
            transform.position += (Vector3)(dir1 * Movespeed2 * Time.deltaTime);

        }
        if (time2 > 0.4f) //아래로 이동
        {
            transform.position += (Vector3)(dir2 * Movespeed2 * Time.deltaTime);

        }


    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // 플레이어와 충돌했는지 확인
        if (collision.gameObject == _target)
        {
            //Debug.Log("충돌!");

            // 복제 생성 여부와 현재 복제 개수를 확인
            if (!isCloneDelay)
            {
                // 복제를 생성하고 현재 복제 개수를 증가
                GameObject enemy = Instantiate(shadowPrefab);
                enemy.transform.position = this.transform.position;
                isCloneDelay = true;
            }
        }
    }
}
