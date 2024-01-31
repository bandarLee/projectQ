using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneEyeMon : MonoBehaviour //프리팹 OneEyeMon(clone)에다가 삽입
{
<<<<<<< HEAD

    public float time = 0;



=======
    public float time = 0;
>>>>>>> 26ede41d18f99a6c593434d5bcdb61f5f4f0083a
    public float Destroytime = 0.8f;

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
