using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;
using static Snake;

public class Snake : MonoBehaviour// " Basic 타입 "
{
    public enum SnakeType
    {
        Left,
        Right,
        Top,
        Bot
    }
    public SnakeType snakeType;
    public float Health = 1;
    public ItemSpawner itemspawner;

    public GameObject DamageEffect;

    // 목표: 적을 벽 안에서 부딪힐 때까지 상하좌우로 이동시키고 싶다.
    // 속성:
    // - 속력
    public float Speed = 3f; // 이동 속도: 초당 1unit만큼 이동하겠다.
    // - 방향
    public Vector2 _dir;

    // 시작할 때
    void Start()
    {
        switch (snakeType)
        {
            case SnakeType.Left: 
                _dir = Vector2.right;
                break;
            case SnakeType.Right:
                _dir = Vector2.left;
                break;
            case SnakeType.Top:
                _dir = Vector2.down;
                break;
            case SnakeType.Bot:
                _dir = Vector2.up;
                break;

        }
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
            else if(roomManager.walltype == WallManager.WallType.Top)
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

        // 플레이어의 공격을 받았을 때 죽는다
         else if (collision.collider.CompareTag("Bullet")) //enemy와 총알이 부딪혔을 때 
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

    private void RotateSnake(Vector2 direction)
    {
        float radian = Mathf.Atan2(direction.y, direction.x);
        float degree = radian * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree + 90));
    }

  /*  IEnumerator InfectWithY909(Player player)
    {
        // 독의 효과가 2초간 지속되도록 설정합니다.
        for (int i = 0; i < 2; i++)
        {
            // 매 초마다 플레이어 체력을 0.05씩 감소시킵니다.
            player.PlayerHealth -= 0.05f;
            yield return new WaitForSeconds(1f);
        }
    }*/

    public void AddSpeed(float amount)
    {
        Speed += amount;
    }
}

