using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour // rotation Y좌표: 0도 했다가 180도 돌리면 고개 돌아감
{

    public float Health = 10;
    public ItemSpawner itemspawner;

    // - 속력
    public float Speed = 1f;
    // - 방향
    public Vector2 dir;

    [Header("총알 프리팹")]
    public GameObject MonsterBullet;

    [Header("총구들")]
    public GameObject[] Muzzles;
    private float rotateSpeed = 100f;

    public void SetDirection(Vector2 direction)
    {
        this.dir = direction;
    }
    void Start()
    {
    }
    void Update()
    {
        transform.position = (Vector2)transform.position + dir * Speed * Time.deltaTime;
        Rotate();
    }

    void Rotate()
    {
        // 게임 오브젝트를 Z축을 중심으로 회전.
        transform.Rotate(new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);

    }

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
                gameObject.SetActive(false);
            }
        }
    }
}
