using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus_Clone : MonoBehaviour
{
    // 위아래 흔들림
    public float swingtime = 0.6f;
    public float time2;
    // 플레이어를 따라가는 속도
    public float Movespeed;
    // 위아래로 흔들리는 속도 
    public float Movespeed2;

    void Start()
    {
        
    }

    void Update()
    {
        // 위로 이동하는 방향
        Vector2 dir1 = new Vector2(0, 0.1f);

            // 아래로 이동하는 방향
            Vector2 dir2 = new Vector2(0, -0.1f);

            //플레이어를 향하는 방향
            Vector2 dir3 = (Player.Instance.transform.position - this.transform.position).normalized;


            // 위아래 흔들림 주기를 계산
            time2 += Time.deltaTime;
            if (time2 >= swingtime)
            {
                time2 = 0.0f;
            }

        float angle = Mathf.Atan2(dir3.y, dir3.x) * Mathf.Rad2Deg;
        angle += 90f;  // 몬스터가 플레이어를 둘러싸도록 각도를 조절
        dir3 = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        transform.position += (Vector3)(dir3 * Movespeed * Time.deltaTime);

        // 플레이어를 향해 이동
        Vector2 dir4 = new Vector2((Player.Instance.transform.position.x - this.transform.position.x), (Player.Instance.transform.position.y - this.transform.position.y));
        dir4.Normalize();
        transform.position += (Vector3)(dir4 * Movespeed * Time.deltaTime);

        //위아래 흔들림
        if (time2 < 0.3f) //위로 이동
        {
            transform.position += (Vector3)(dir1 * Movespeed2 * Time.deltaTime);

        }
        if (time2 > 0.3f) //아래로 이동
        {
            transform.position += (Vector3)(dir2 * Movespeed2 * Time.deltaTime);

        }
    }
}
