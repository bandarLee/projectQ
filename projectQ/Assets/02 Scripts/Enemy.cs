using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour // Basic타입
{

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

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        if (collision.collider.CompareTag("Wall_Top"))
        {
            _dir = Vector2.left;
        }
        if (collision.collider.CompareTag("Wall_Bottom"))
        {
            _dir = Vector2.right;
        }
        if (collision.collider.CompareTag("Wall_Left"))
        {
            _dir = Vector2.down;
        }
        if (collision.collider.CompareTag("Wall_Right"))
        {
            _dir = Vector2.up;
        }

    }

}
