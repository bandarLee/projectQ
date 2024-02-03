using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float amplitude = 0.08f; // 움직임의 범위를 설정. 이 값을 바꾸면 움직임의 범위가 바뀜.
    public float frequency = 3f; // 움직임의 속도를 설정. 이 값을 바꾸면 움직임의 속도가 바뀜.

    Vector3 startPos;


    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos + amplitude * Mathf.Sin(Time.time * frequency) * Vector3.up;
    }
}
