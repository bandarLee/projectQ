using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeg : MonoBehaviour
{
    private float rotateSpeed = 20f;
    private float acceleration = 1.01f; // 가속도

    private float currentAngle = 0f;
    private int rotateDirection = 1;

    private float moveSpeed = 2.5f;
    private float moveDistance = 1.5f; // 이동 거리

    private float currentDistance = 0f;
    private int moveDirection = -1; 

    void Start()
    {
        Rotate();
        //Move();
    }


    void Update()
    {
        Rotate();
        //Move();
    }
   /* void Move()
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
   */
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
            rotateDirection *= -1;
        }

        transform.rotation = Quaternion.Euler(0, 180, currentAngle);
    }
    IEnumerator AccelerateRightarm()
    {
        yield return new WaitForSeconds(0.1f);
        rotateSpeed *= acceleration;
    }
}
