using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletDown : MonoBehaviour
{
    public float EnemyBulletDamage = 1;
    public float Speed = 5f;

    private void Start()
    {
        StartCoroutine(BossBulletDestroy());
    }
    void Update()
    {
        // 1. 이동할 방향을 구한다. (예: 위로)
        Vector2 dir = Vector2.down;

        // 2. 이동한다. 
        transform.position += (Vector3)(dir * Speed) * Time.deltaTime;
    }

    IEnumerator BossBulletDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
