using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletType
    {
        Normal,
        Fire,     // 화염 아이템 얻으면 발동
        Knife     // Knife 아이템 얻으면

    }

    public BulletType Btype;

    private float rotateSpeed = 300f;
    public float maxDistance = 3.5f;   // 총알 사거리
    public float NormalBulletSpeed;   // 총알의 속도
    public float BulletPower;         // 총알의 데미지



    private Vector2 startPos;   // 총알이 발사된 시작 위치
    private Vector2 dir;        // 임의의 방향


    public GameObject FireVFX;


    void Start()
    {
        // 처음 시작하면 총알 발사
        BulletPower = 1;

    }
    public void SetDirection(Vector2 direction)
    {
        this.dir = direction;
    }

    public void Awake()
    {
        // 총알의 시작 위치를 저장
        startPos = transform.position;

        // 
        if (Btype == BulletType.Knife)
        {
            BulletPower = 0.8f;
        }
        else if (Btype == BulletType.Fire)
        {
            BulletPower = 3f;
        }
        else if (Btype == BulletType.Normal)
        {
            BulletPower = 0.5f;
        }
    }
    // 목표: 총알이 방향키를 누름에 따라 앞으로 나아가도록

    void Update()
    {
        transform.position = (Vector2)transform.position + dir * NormalBulletSpeed * Time.deltaTime;
        if (Btype == BulletType.Knife)
        {
            //Debug.Log("회전");
            Rotate();
        }

        if (Vector2.Distance(startPos, transform.position) >= maxDistance)
        {
            Destroy(this.gameObject);
        }

    }
    public void GetBullettype(string bullettype)
    {

    }

    void Rotate()
    {
        // 게임 오브젝트를 Z축을 중심으로 회전.
        transform.Rotate(new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("OneEyeEnemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
