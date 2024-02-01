using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus_Clone : MonoBehaviour
{
    public float time = 0;
    public float Destroytime = 0.8f;


    void Start()
    {

    }

    void Update()
    {

        time += Time.deltaTime;
        if (time >= Destroytime) // && Bullet이 본체를 공격하였을 때 추가
        {
            Destroy(this.gameObject);
        }



    }
}
