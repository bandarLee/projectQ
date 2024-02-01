using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;

public class GasMan : MonoBehaviour // " Basic 타입 " 
{
    public float Health = 1;

    public BulletType BType; // Normal 타입
    // - 속력
    public float Speed = 3f; // 이동 속도: 초당 1unit만큼 이동하겠다.
    // - 방향
    public Vector2 _dir;

    public Animator MyAnimator;

    void Start()
    {
        _dir = Vector2.right;
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

        // GasMan(Basic 타입) 움직임
        RoomManager roomManager = collision.collider.GetComponent<RoomManager>();
        if (roomManager.walltype == RoomManager.WallType.Right)
        {
            _dir = Vector2.down;

            
        }

        if (roomManager.walltype == RoomManager.WallType.Bot)
        {
            _dir = Vector2.left;

        }

        if (roomManager.walltype == RoomManager.WallType.Left)
        {
            _dir = Vector2.up;

        }

        if (roomManager.walltype == RoomManager.WallType.Top)
        {
            _dir = Vector2.right;

        }

        // 1. 각도를 구한다. 
        float radian = Mathf.Atan2(_dir.y, _dir.x); // '호'도법 -> 라디안 값
        float degree = radian * Mathf.Rad2Deg;
        //Debug.Log(degree);

        // 2. 각도에 맞게 회전한다.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree + 90)); //이미지 리소스를 따라 90도 더해줌


        // 플레이어는 적과 충돌하면 체력이 닳는다
        if (collision.collider.CompareTag("Player"))
        {
            Player player = collision.collider.GetComponent<Player>();
            //player.DecreaseHealth(1); //player 클래스에 체력 달아줘야 함
        }

        
    }
   
}


