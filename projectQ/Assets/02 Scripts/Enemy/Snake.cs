using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;

public class Snake : MonoBehaviour// " Basic 타입 "
{

    public float Health = 1;

    public GameObject ItemPrefab_Health; // DropItem
    public GameObject ItemPrefab_Speed;
    public GameObject ItemPrefab_Money; // 상점에 꼭 필요
    public GameObject ItemPrefab_CardKey; // 다음 층으로 넘어갈 수 있는 카드키


    public BulletType BType; // Normal 타입

    // 목표: 적을 벽 안에서 부딪힐 때까지 상하좌우로 이동시키고 싶다.
    // 속성:
    // - 속력
    public float Speed = 3f; // 이동 속도: 초당 1unit만큼 이동하겠다.
    // - 방향
    public Vector2 _dir;

    public Animator MyAnimator;

    // 시작할 때
    void Start()
    {
        _dir = Vector2.down;
    }

    void Update()
    {

        //구현 순서
        // 2. 이동한다. 
        // 새로운 위치 = 현재 위치 + 속도 * 시간
        transform.position += (Vector3)(_dir * Speed) * Time.deltaTime;
        _dir.Normalize();


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        // snake(Basic 타입) 움직임
        WallManager roomManager = collision.collider.GetComponent<WallManager>();
        if (roomManager.walltype == WallManager.WallType.Bot)
        {
            _dir = Vector2.up;

            // 1. 각도를 구한다. 
            float radian = Mathf.Atan2(_dir.y, _dir.x); // '호'도법 -> 라디안 값
            float degree = radian * Mathf.Rad2Deg;
            //Debug.Log(degree);

            // 2. 각도에 맞게 회전한다.
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree + 90)); //이미지 리소스를 따라 90도 더해줌

            if (Speed < 7)
            {
                AddSpeed(1);
            }
        }

        if (roomManager.walltype == WallManager.WallType.Top)
        {
            _dir = Vector2.down;

            // 1. 각도를 구한다.
            float radian = Mathf.Atan2(_dir.y, _dir.x);
            float degree = radian * Mathf.Rad2Deg;

            // 2. 각도에 맞게 회전한다.
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree + 90));

            if(Speed < 7)
            {
                AddSpeed(1);
            }
            
        }



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
                  Health -= 2;
              }


              // 총알 삭제
              collision.collider.gameObject.SetActive(false);

              // 적의 체력이 끝
              if (Health <= 0)
              {
                  //gameObject.SetActive(false);
                  Destroy(gameObject);
                  MakeItem();
              }
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

    public void AddSpeed(float amount)
    {
        Speed += amount;
        //Debug.Log($"플레이어 속도: {Speed}");
    }
}

