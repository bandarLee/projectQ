using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShyGuy : MonoBehaviour // 'usual'Mode 프리팹
{
    public float Health = 2;
    public ItemSpawner itemspawner;
    public bool replacesuccess = false;

    // 위아래로 흔들리는 속도 
    public float Movespeed2;
    // 위아래 흔들림 주기
    public float swingtime = 0.6f;
    // 위아래 흔들림 상태 변경까지 남은 시간
    public float time2;

    /*// 몬스터 등장 이후 누적 시간
    public float progressTime = 0;
    public float replaceTime = 3f;*/
    public GameObject UpgradePrefab;

    [Header("총알 프리팹")]
    public GameObject MonsterBullet;

    [Header("총구들")]
    public GameObject[] Muzzles;

    [Header("타이머")]
    public float Timer = 0f;
    public const float COOL_TIME = 0.6f;

    void Start()
    {
    }
    private void OnEnable()
    {
        Health = 2;
        replacesuccess = false;
        time2 = 0;
    }

    void Update()
    {
        // 위로 이동하는 방향
        Vector2 dir1 = new Vector2(0, 0.1f);
        // 아래로 이동하는 방향
        Vector2 dir2 = new Vector2(0, -0.1f);
        // usualMode 움직임: 하루의 대부분을 시설의 동쪽 벽 주변을 돌아다니며 보냄


        // 위아래 흔들림 주기를 계산
        time2 += Time.deltaTime;
        Timer -= Time.deltaTime;
    }

   /* public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //StartCoroutine(InfectWithY909(collision.gameObject.GetComponent<Player>()));
            Instantiate(DamageEffect, collision.transform.position, Quaternion.identity);

        }
        if (collision.gameObject.tag == "Environment")
        {

            WallManager roomManager = collision.collider.GetComponent<WallManager>();
            if (roomManager.walltype == WallManager.WallType.Bot)
            {
                _dir = Vector2.up;
                RotateSnake(_dir);

                if (Speed < 7) AddSpeed(1);

            }
            else if (roomManager.walltype == WallManager.WallType.Top)
            {
                _dir = Vector2.down;
                RotateSnake(_dir);


                if (Speed < 7) AddSpeed(1);
            }
            else if (roomManager.walltype == WallManager.WallType.Left)
            {
                _dir = Vector2.right;
                RotateSnake(_dir);


                if (Speed < 7) AddSpeed(1);
            }
            else if (roomManager.walltype == WallManager.WallType.Right)
            {
                _dir = Vector2.left;
                RotateSnake(_dir);


                if (Speed < 7) AddSpeed(1);
            }
        }
    }*/
}
