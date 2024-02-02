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

    public GameObject FireVFX;


    void Start()
    {
        // 만약 총알 타입이 knife이면, 
   

    }
    public float NormalBulletSpeed;
    private Vector2 dir;
    public void SetDirection(Vector2 direction)
    {
        this.dir = direction;
    }

    public void Awake()
    {
    

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

    }
    public void GetBullettype(string bullettype)
    {

    }

    void Rotate()
    {
        // 게임 오브젝트를 Y축을 중심으로 회전.
        transform.Rotate(new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);;

    }
}
