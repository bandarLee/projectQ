using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour // Basic타입
{
    public enum WallType
    {
        Left,
        Right,
        Top,
        Bot
    }
    public WallType walltype;


    // 목표: 적을 벽 안에서 부딪힐 때까지 상하좌우로 이동시키고 싶다.
    // 속성:
    // - 속력
    public float Speed = 0.05f; // 이동 속도: 초당 1unit만큼 이동하겠다.
    // - 방향
    public Vector2 _dir;
  

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
        if(walltype == WallType.Bot)
        {
            _dir = Vector2.up;

            // 1. 각도를 구한다. 
            //tanθ = y/x    ->  θ = y/x * atan(탄젠트의 역함수)
            float radian = Mathf.Atan2(_dir.y, _dir.x); // '호'도법 -> 라디안 값
            float degree = radian * Mathf.Rad2Deg;
            //Debug.Log(degree);

            // 2. 각도에 맞게 회전한다.
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree + 90)); //이미지 리소스를 따라 90도 더해줌
        }
        

    }

}
