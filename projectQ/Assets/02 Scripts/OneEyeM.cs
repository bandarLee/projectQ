using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneEyeMon : MonoBehaviour
{
    public float time;
    public float Destroytime = 0.01f;

    void Start()
    {

    }

    void Update()
    {

        time += Time.deltaTime;
        if (time >= Destroytime)
        {
            Destroy(this.gameObject);
        }

    }
}
