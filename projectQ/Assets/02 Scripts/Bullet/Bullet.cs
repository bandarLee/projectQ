using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletType
    {
        Normal = 1,
        Fire = 2,   // 화염 아이템 얻으면 발동

    }

    public BulletType BType { get; internal set; }

    void Start()
    {

    }
    public float NormalBulletSpeed;
    private Vector2 dir;
    public void SetDirection(Vector2 direction)
    {
        this.dir = direction;
    }


   // 목표: 총알이 방향키를 누름에 따라 앞으로 나아가도록

    void Update()
    {

        transform.position = (Vector2)transform.position + dir * NormalBulletSpeed * Time.deltaTime;

    }

    

}
