using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletType
    {
        Normal = 1,

    }
    public float NormalBulletSpeed;
    private Vector2 dir;
    public void SetDirection(Vector2 direction)
    {
        this.dir = direction;
    }


   // 목표: 총알이 방향키를 누름에 따라 앞으로 나아가도록

    void Start()
    {
        
    }

    void Update()
    {

        transform.position = (Vector2)transform.position + dir * NormalBulletSpeed * Time.deltaTime;

    }

}
