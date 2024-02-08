using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BossTest : MonoBehaviour
{
    private float rotateSpeed = 30f;
    private float acceleration = 1.01f; // 가속도

    private float currentAngle = 0f; 
    private int rotateDirection = 1;

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
        // 현재 각도가 20도 이상이고, 방향이 내려가는 방향일 때 가속도를 적용
        if (currentAngle >= 5f && rotateDirection == -1)
        {
            StartCoroutine(AccelerateRightarm());
        }

        currentAngle += rotateSpeed * Time.deltaTime * rotateDirection;
        currentAngle = Mathf.Clamp(currentAngle, 0f, 100f);

        if (currentAngle >= 30f || currentAngle <= 0f)
        {
            rotateSpeed = 20f;

            if (rotateDirection == -1 || rotateDirection == 1)
            {
                StartCoroutine(Attack());
            }

            rotateDirection *= -1; //해줄 때 탄막 생성 (빵) 

        }

        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
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

            /*// 3. 총알을 확대하는 코루틴을 시작
            //if (bossBullet.isExpanding)
            {
               // StartCoroutine(ExpandBullet(bullet));
            }*/
                
        }

        yield return null;
    }
    /*IEnumerator ExpandBullet(GameObject bullet)
    {
        //float expandSpeed = 1.0f; // 확대 속도
        //float maxSize = 10f; // 최대 크기
        yield return null;

        *//*while (bullet.transform.localScale.x < maxSize)
        {
            bullet.transform.localScale += new Vector3(expandSpeed, expandSpeed, expandSpeed) * Time.deltaTime;
        }*//*
    }*/

    

}
