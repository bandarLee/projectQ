using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTest : MonoBehaviour
{
    private float rotateSpeed = 20f;
    private float acceleration = 1.01f; // 가속도

    private float currentAngle = 0f; 
    private int rotateDirection = 1; 

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
        if (currentAngle >= 20f && rotateDirection == -1)
        {
            StartCoroutine(AccelerateRightarm());
        }

        currentAngle += rotateSpeed * Time.deltaTime * rotateDirection;
        currentAngle = Mathf.Clamp(currentAngle, 0f, 40f);

        if (currentAngle >= 40f || currentAngle <= 0f)
        {
            rotateSpeed = 20f;
            rotateDirection *= -1;
        }

        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
    }
    IEnumerator AccelerateRightarm()
    {
        yield return new WaitForSeconds(0.1f);
        rotateSpeed *= acceleration;
    }
}
