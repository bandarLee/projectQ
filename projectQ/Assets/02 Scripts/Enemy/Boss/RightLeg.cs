using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeg : MonoBehaviour
{
    public BossBullet bossBullet;

    public float Health = 5;
    public ItemSpawner itemspawner;

    private float rotateSpeed = 20f;
    private float acceleration = 1.01f; // 가속도

    private float currentAngle = 0f;
    private int rotateDirection = 1;

    private float moveSpeed = 2.5f;
    private float moveDistance = 1.5f; // 이동 거리

    private float currentDistance = 0f;
    private int moveDirection = -1;

    // - 속력
    public float Speed = 2f;
    // - 방향
    public Vector2 _dir;

    [Header("총알 프리팹")]
    public GameObject MonsterBullet;

    [Header("총구들")]
    public GameObject[] Muzzles;

    void Start()
    {
        Rotate();
        Move();
    }


    void Update()
    {
        Rotate();
        Move();
    }
    void Move()
    {
        currentDistance += moveSpeed * Time.deltaTime * moveDirection;
        currentDistance = Mathf.Clamp(currentDistance, -moveDistance, 0f); // 이동 범위를 설정

        if (currentDistance <= -moveDistance || currentDistance >= 0f)
        {
            moveDirection *= -1;
        }

        // Y축을 기준으로 이동
        transform.position = new Vector3(transform.position.x, currentDistance, transform.position.z);
    }
   
    void Rotate()
    {
        // 현재 각도가 -15도 이상이고, 방향이 내려가는 방향일 때 가속도를 적용
        if (currentAngle >= -15f && rotateDirection == 1)
        {
            StartCoroutine(AccelerateRightarm());

        }

        currentAngle += rotateSpeed * Time.deltaTime * rotateDirection;
        currentAngle = Mathf.Clamp(currentAngle, -30f, 0f); // 회전 범위를 반대로 설정

        if (currentAngle <= -30f || currentAngle >= 0f)
        {
            rotateSpeed = 30f;
            if (rotateDirection == -1 || rotateDirection == 1)
            {
                StartCoroutine(Attack());
            }
            rotateDirection *= -1;
        }

        transform.rotation = Quaternion.Euler(0, 180, currentAngle);
    }
    IEnumerator AccelerateRightarm()
    {
        yield return new WaitForSeconds(0.1f);
        rotateSpeed *= acceleration;
    }

    IEnumerator Attack()
    {
        for (int i = 0; i < Muzzles.Length; i++)
        {
            // 1. 총알을 만들고
            GameObject bullet = Instantiate(MonsterBullet);

            // 2. 위치를 설정한다.
            bullet.transform.position = Muzzles[i].transform.position;
        }

        yield return null;
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
