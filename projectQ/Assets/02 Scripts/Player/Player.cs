using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Vector2 PlayerPosition;

    public float PlayerHealth = 3f;
    public float maxDistance = 3.5f;   // 총알 사거리
    public float NormalBulletSpeed;   // 총알의 속도
    public float BulletPower;         // 총알의 데미지


    private void Awake()
    {
        // 싱글톤 패턴 : 오직 한개의 클래스 인스턴스를 갖도록 보장
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("OneEyeEnemy"))
        {
            PlayerHealth = PlayerHealth - 0.3f;
        } 

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("OneEyeEnemy"))
        {
            PlayerHealth -= 0.1f * Time.deltaTime;
        }

    }

}
