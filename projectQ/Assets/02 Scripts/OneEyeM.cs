using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneEyeMon : MonoBehaviour //프리팹 OneEyeMon(clone)에다가 삽입
{
<<<<<<< HEAD
    public float time = 0;
=======
    public float time;
>>>>>>> 3dfc860f4fb64b249a571a39ee7d4c2867fc2a3d
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
