using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public float Health = 10;
    public float aboveY = 1f; // enemy가 player 위에 떠다닐 y축 거리
    // 플레이어를 따라가는 속도
    public float Movespeed;
    // 위아래로 흔들리는 속도 
    public float Movespeed2;

    // 잔상 프리팹
    public GameObject shadowPrefab; //프리팹 OneEyeMon(clone) 쓰임: OneEyeMon 스크립트 가져다 씀.

    // 잔상 생성 지연 여부
    public bool isDelay;

    // 잔상 생성 주기
    public float Respawntime = 0.1f;

    // 위아래 흔들림 주기
    public float swingtime = 0.6f;

    // 잔상 생성까지 남은 시간
    public float time;

    // 위아래 흔들림 상태 변경까지 남은 시간
    public float time2;

    public bool enemyspawn = true;

    private Vector3 initialPosition;
    public enum BossNumber
    {
        A,
        B,
        C,
        D

    }
    public BossNumber bossNumber = BossNumber.A;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어의 공격을 받았을 때 죽는다
        if (collision.collider.CompareTag("Bullet")) //enemy와 총알이 부딪혔을 때 
        {

            Health -= Player.Instance.BulletPower;


            // 총알 삭제
            collision.collider.gameObject.SetActive(false);

            // 적의 체력이 끝
            if (Health <= 0)
            {
                BossRoom2Manager.Instance.OnBossDestroyed();
                Destroy(this.gameObject);

            }
        }
    }
    void Update()
    {
        Vector2 dir1 = new Vector2(0.2f, 0);

        // 아래로 이동하는 방향
        Vector2 dir2 = new Vector2(-0.2f, 0);
        if (isDelay)
        {
            time += Time.deltaTime;
            if (time >= Respawntime)
            {
                time = 0.0f;
                isDelay = false;
            }
        }
        time2 += Time.deltaTime;

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
        if (time2 < 0.5f) //위로 이동
        {
            transform.position += (Vector3)(dir1 * Movespeed2 * Time.deltaTime);

        }
        if (time2 > 0.5f) //아래로 이동
        {
            transform.position += (Vector3)(dir2 * Movespeed2 * Time.deltaTime);
        }
        
        if (enemyspawn)
        {
            switch (bossNumber)
            {
                case BossNumber.A:
                    BasicEnemy[] basicEnemy = BossRoom2Manager.Instance.basicEnemy;
                    foreach (BasicEnemy basicenemies in basicEnemy)
                    {
                        basicenemies.gameObject.SetActive(true);
                    }
                    break;
                case BossNumber.B:
                    OneEye[] oneeyes = BossRoom2Manager.Instance.oneeyes;
                    foreach (OneEye oneeye in oneeyes)
                    {
                        oneeye.gameObject.SetActive(true);
                    }
                    break;
                case BossNumber.C:
                    Snake[] snake = BossRoom2Manager.Instance.snake;
                    foreach (Snake snakes in snake)
                    {
                        snakes.gameObject.SetActive(true);
                    }
                    break;
                case BossNumber.D:
                    Virus[] virus = BossRoom2Manager.Instance.virus;
                    foreach (Virus viruses in virus)
                    {
                        viruses.gameObject.SetActive(true);
                    }
                    break;
            }
            enemyspawn = false;
            StartCoroutine(EnemySpawnCoroutine());

        }
    }



        IEnumerator EnemySpawnCoroutine()
            {
   
                yield return new WaitForSeconds(10f);

                enemyspawn = true;


            }
}
