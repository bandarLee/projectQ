using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Clone : MonoBehaviour
{
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
            Destroy(this.gameObject);
        }

    }
}
