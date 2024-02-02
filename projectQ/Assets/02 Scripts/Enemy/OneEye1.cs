using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneEye1 : MonoBehaviour // follow 타입
{
    public float Health = 2;

    public GameObject ItemPrefab_Health; // DropItem
    public GameObject ItemPrefab_Speed;
    public GameObject ItemPrefab_Money; // 상점에 꼭 필요
    public GameObject ItemPrefab_CardKey; // 다음 층으로 넘어갈 수 있는 카드키
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

    [Header("타이머")]
    public float Timer = 0f;
    public const float COOL_TIME = 3f;
    private void Awake()
    {
    }

    void Update()
    {
        // 위로 이동하는 방향
        Vector2 dir1 = new Vector2(0, 0.1f);

        // 아래로 이동하는 방향
        Vector2 dir2 = new Vector2(0, -0.1f);

        //플레이어를 향하는 방향
        Vector2 dir3 = Player.Instance.transform.position - this.transform.position;

        // 새로운 위치 = 현재 위치 + 속도 * 시간
        dir3.Normalize();
        transform.position += (Vector3)(dir3 * Movespeed) * Time.deltaTime;
        

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
        // 플레이어는 적과 충돌하면 체력이 닳는다
        if (collision.collider.CompareTag("Player"))
        {
            Player player = collision.collider.GetComponent<Player>();
            player.PlayerHealth--; 
        }

        // 플레이어의 공격을 받았을 때 죽는다
         else if (collision.collider.CompareTag("Bullet")) //enemy와 총알이 부딪혔을 때 
          {
              Bullet bullet = collision.collider.GetComponent<Bullet>();
              if (bullet.Btype == Bullet.BulletType.Normal) //enum
              {
                  Health -= 1;
              }

            // 적의 체력이 끝
            if (Health <= 0)
            {
                Destroy(gameObject);
                MakeItem();
            }    
        }
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

}



