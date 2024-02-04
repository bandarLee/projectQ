using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using static Bullet;

public enum EnemyBulletType
{
    Blood,
    SnakePoison,
    Skeleton,

}

public class EnemyBullet : MonoBehaviour
{
    public EnemyBulletType EnemyBType;
    public float EnemyBulletDamage = 1;

    // 목표 : 총알이 어디(방향)으로 이동하고 싶다.
    // 속성:
    // - 속력
    // 구현 순서
    // 1. 이동할 방향을 구한다.
    // 2. 이동한다. 

    public float Speed = 5f;

    // 플레이어를 향한 초기 방향을 저장할 변수
    private Vector2 initialDirection;

    void Start()
    {
        if (EnemyBType == EnemyBulletType.Skeleton) //target형 - 처음 위치 따라가기
        {
            // 플레이어를 향한 초기 방향을 계산
            initialDirection = (Player.Instance.transform.position - this.transform.position).normalized;
        }
    }

    void Update()
    {
        if (EnemyBType == EnemyBulletType.Skeleton)
        {
            // 초기 방향으로 이동함
            transform.position += (Vector3)(initialDirection * Speed) * Time.deltaTime;
        }

        if (EnemyBType == EnemyBulletType.Blood)
        {
            // 1. 이동할 방향을 구한다.
            Vector2 dir = Vector2.down; // 핏방울 아래로

            // 2. 이동한다. 
            //transform.Translate(dir * Speed * Time.deltaTime);
            // 새로운 위치 = 현재 위치 + 속도 * 시간
            transform.position += (Vector3)(dir * Speed) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Environment")) 
        {
            Destroy(this.gameObject);
        }
    }
}
