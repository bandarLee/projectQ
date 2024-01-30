using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemytest : MonoBehaviour
{

    public float Movespeed;
    public float Movespeed2;

    public GameObject _target;
    public GameObject octopusPrefab;
    public bool isDelay;
    public float Respawntime = 1f;
    public float swingtime = 0.6f;
    public float time;
    public float time2;





    void Update()
    {
        Vector2 dir1 = new Vector2(0, 0.1f);
        Vector2 dir2 = new Vector2(0, -0.1f);
        Vector2 dir3 = _target.transform.position - this.transform.position;
        if (isDelay)
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
        if (!isDelay && ((dir3.x * dir3.y) > 1 || (dir3.x * dir3.y) < -1))
        {
            GameObject enemy = Instantiate(octopusPrefab);
            enemy.transform.position = this.transform.position;
            isDelay = true;
        }

        dir3.Normalize();

        transform.position += (Vector3)(dir3 * Movespeed * Time.deltaTime);


        //Debug.Log(dir3);
        if (time2 < 0.4f)
        {
            transform.position += (Vector3)(dir1 * Movespeed2 * Time.deltaTime);

        }
        if (time2 > 0.4f)
        {
            transform.position += (Vector3)(dir2 * Movespeed2 * Time.deltaTime);

        }
        //Debug.Log(time2);


    }
}
