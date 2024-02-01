using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneEye_Clone : MonoBehaviour //프리팹 OneEyeMon(clone)에다가 삽입 // 삭제하는 것
{
    public GameObject OneEye;
    public float time = 0;
    public float Destroytime = 0.8f;

    void Start()
    {

    }

    void Update()
    {

        time += Time.deltaTime;
        if (time >= Destroytime)
        {
            time = 0;
            GameObject afterImage = Instantiate(OneEye, OneEye.transform.position, OneEye.transform.rotation);
            Destroy(afterImage, Destroytime);
        }

    }
}
