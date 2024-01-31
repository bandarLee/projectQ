using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Target : MonoBehaviour // target타입
{
    // 플레이어를 따라가는 속도
    public float Movespeed;

    // 위아래로 흔들리는 속도 
    public float Movespeed2;

    // 플레이어 객체
    public GameObject _target;

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


    void Update()
    {
        // 위로 이동하는 방향
        Vector2 dir1 = new Vector2(0, 0.1f);

        // 아래로 이동하는 방향
        Vector2 dir2 = new Vector2(0, -0.1f);

        //플레이어를 향하는 방향
        Vector2 dir3 = _target.transform.position - this.transform.position;

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
        if (time2 >= swingtime)
        {
            time2 = 0.0f;
        }

        // 플레이어를 향하는 방향으로 이동하면서 잔상 생성
        if (!isDelay && ((dir3.x * dir3.y) > 1 || (dir3.x * dir3.y) < -1))
        {
            GameObject enemy = Instantiate(shadowPrefab);
            enemy.transform.position = this.transform.position;
            isDelay = true;
        }


        // 플레이어를 향해 이동
        dir3.Normalize();
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
}
