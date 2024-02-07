using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : MonoBehaviour
{
    public BossBullet bossBullet;

    public float Health = 5;

    public ItemSpawner itemspawner;

    private float rotateSpeed = 30f;
    private float acceleration = 1.01f; // 가속도

    private float currentAngle = 0f;
    private int rotateDirection = -1; // 초기 회전 방향 반대

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

    }


    void Update()
    {
        Rotate();

    }
    void Rotate()
    {

        // 현재 각도가 -20도 이상이고, 방향이 내려가는 방향일 때 가속도를 적용
        if (currentAngle >= -45f && rotateDirection == 1)
        {
            StartCoroutine(AccelerateLeftarm());

        }

        currentAngle += rotateSpeed * Time.deltaTime * rotateDirection;
        currentAngle = Mathf.Clamp(currentAngle, -100f, 0f); // 회전 범위를 반대로 설정

        if (currentAngle <= -100f || currentAngle >= 0f)
        {
            rotateSpeed = 30f;
            if (rotateDirection == -1 || rotateDirection == 1)
            {
                StartCoroutine(Attack());
            }
            rotateDirection *= -1;
        }

        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
    }
     IEnumerator AccelerateLeftarm()
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
