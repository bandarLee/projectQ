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
    // 목표: 총알이 방향키를 누름에 따라 앞으로 나아가도록

    void Start()
    {
        
    }

    void Update()
    {
        float MoveH = Input.GetAxis("Horizontal");
        float MoveV = Input.GetAxis("Vertical");

        //Vector2 dir = new 
    }
}
