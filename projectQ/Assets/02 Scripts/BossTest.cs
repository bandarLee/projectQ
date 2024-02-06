using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTest : MonoBehaviour
{
    private float rotateSpeed = 30f;

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
        currentAngle += rotateSpeed * Time.deltaTime * rotateDirection;
        currentAngle = Mathf.Clamp(currentAngle, 0f, 40f);

        if (currentAngle >= 40f || currentAngle <= 0f)
        {
            if (currentAngle >= 20f || currentAngle <= 0f)
            {

            }
                rotateDirection *= -1;
        }

        transform.rotation = Quaternion.Euler(0, 0, currentAngle);

    }
}
