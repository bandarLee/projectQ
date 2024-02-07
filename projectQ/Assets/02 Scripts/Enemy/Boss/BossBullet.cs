using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float EnemyBulletDamage = 1;
    public float Speed = 5f;
    //public float expandSpeed = 0.5f; // 확대 속도
    //public bool isExpanding = true; // 총알이 확장 중인지 여부
    private void Start()
    {
        StartCoroutine(BossBulletDestroy());
    }
    void Update()
    {
        // 1. 이동할 방향을 구한다. (예: 위로)
        Vector2 dir = Vector2.up;

        // 2. 이동한다. 
        transform.position += (Vector3)(dir * Speed) * Time.deltaTime;

       /* if (isExpanding)
        {
            transform.localScale += new Vector3(expandSpeed, expandSpeed, expandSpeed) * Time.deltaTime;
        }*/
    }

    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Environment") || collision.collider.CompareTag("Bullet"))
        {
            isExpanding = false; // 벽에 닿으면 확장을 멈춤
            StartCoroutine(BossBulletDestroy()); // 총알이 부딪히면 10초 후에 파괴되도록 코루틴을 시작

        }
    }*/
    IEnumerator BossBulletDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
