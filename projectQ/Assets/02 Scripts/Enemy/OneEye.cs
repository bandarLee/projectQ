using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneEye : MonoBehaviour // follow 타입
{
    public float Health = 2;

    public GameObject ItemPrefab_Health; // DropItem
    public GameObject ItemPrefab_Speed;
    public GameObject ItemPrefab_Money; // 상점에 꼭 필요
    public GameObject ItemPrefab_CardKey; // 다음 층으로 넘어갈 수 있는 카드키

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

    // 몬스터 등장 이후 누적 시간
    public float progressTime = 0;
    public GameObject UpgradePrefab;


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

        progressTime += Time.deltaTime;
        if (progressTime > 10.0f)
        {
            /*GameObject enemy = Instantiate(UpgradePrefab);
            enemy.transform.position = this.transform.position;*/
            ReplacePrefab();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어는 적과 충돌하면 체력이 닳는다
        if (collision.collider.CompareTag("Player"))
        {
            Player player = collision.collider.GetComponent<Player>();
            //player.DecreaseHealth(1); //player 클래스에 체력 달아줘야 함
        }

        // 플레이어의 공격을 받았을 때 죽는다
        /*  else if (collision.collider.CompareTag("Bullet")) //enemy와 총알이 부딪혔을 때 //-> 아직 "tag:bullet" 없음
          {
              Bullet bullet = collision.collider.GetComponent<Bullet>();
              if (bullet.BType == BulletType.Normal) //enum
              {
                  Health -= 1;
              }


              // 총알 삭제
              collision.collider.gameObject.SetActive(false);

              // 적의 체력이 끝
              if (Health <= 0)
              {
                  //gameObject.SetActive(false);
                  Destroy(gameObject);
                  MakeItem();
              }*/
    }

    public void MakeItem()
        {
            // 목표: 20% 확률로 다음 층으로 넘어갈 수 있는 카드키, 80% 확률로 머니주는 아이템 (확률넣기)
            if (Random.Range(0, 10) == 0 || Random.Range(0, 10) == 1)
            {
                // -다음 층으로 넘어갈 수 있는 카드키 만들고
                GameObject item_CardKey = Instantiate(ItemPrefab_CardKey);
                // -위치를 나의 위치로 수정
                item_CardKey.transform.position = this.transform.position;
            }
            else
            {
                // -머니주는 아이템 만들고
                GameObject item_Money = Instantiate(ItemPrefab_Money);
                // -위치를 나의 위치로 수정
                item_Money.transform.position = this.transform.position;
            }
        }

    public void ReplacePrefab()
    {
        GameObject newObject = Instantiate(UpgradePrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}



