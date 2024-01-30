using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemytest : MonoBehaviour
{
    // 잔상주는 코드 + 플레이어 따라가는 코드 + 위아래로 흔들리는 코드


    // 플레이어 따라가는 코드
    public float Movespeed;
    // 잔상주는 코드 
    public float Movespeed2;

    public GameObject _target;
    public GameObject shadowPrefab;
    public bool isDelay;
    public float Respawntime = 1f; //부활 시간
    public float swingtime = 0.6f;  // 회전 시간
    public float time;
    public float time2;

    void Update()
    {
        // 위아래로 흔들리는 코드
        Vector2 dir1 = new Vector2(0, 0.1f);
        Vector2 dir2 = new Vector2(0, -0.1f);

        //플레이어 따라가는 코드
        Vector2 dir3 = _target.transform.position - this.transform.position;


        if (isDelay) //
        {

            time += Time.deltaTime;
            if (time >= Respawntime) 
            {
                time = 0.0f;
                isDelay = false;
            }
        }
        time2 += Time.deltaTime;
        if (time2 >= swingtime)
        {
            time2 = 0.0f;
        }
        if (!isDelay && ((dir3.x * dir3.y) > 1 || (dir3.x * dir3.y) < -1)) // 
        {
            GameObject enemy = Instantiate(shadowPrefab);
            enemy.transform.position = this.transform.position;
            isDelay = true;
        }

        dir3.Normalize();

        transform.position += (Vector3)(dir3 * Movespeed * Time.deltaTime);


        //Debug.Log(dir3);
        if (time2 < 0.4f) //위
        {
            transform.position += (Vector3)(dir1 * Movespeed2 * Time.deltaTime);

        }
        if (time2 > 0.4f) //아래
        {
            transform.position += (Vector3)(dir2 * Movespeed2 * Time.deltaTime);

        }
        //Debug.Log(time2);


    }
}
