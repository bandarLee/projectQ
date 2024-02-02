using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;

public class EnemyFire : MonoBehaviour
{
    [Header("총알 프리팹")]
    public GameObject BulletPrefab;

    // - 풀 사이즈
    public int PoolSize = 20;
    // - 오브젝트(총알) 풀 
    private List<Bullet> _bulletPool = null;

    // 1. 태어날 때: Awake
    private void Awake()
    {
        // 2. 오브젝트 풀 할당해주고..
        _bulletPool = new List<Bullet>();

        // 3. 총알 프리팹으로부터 총알을 풀 사이즈만큼 생성해준다.
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab);
            bullet.SetActive(false); // 끈다.

            // 4. 생성한 총알을 풀에다가 넣는다. 
            _bulletPool.Add(bullet.GetComponent<Bullet>());
        }
    }

    [Header("총구들")]
    public List<GameObject> Muzzles; 

    [Header("타이머")]
    public float Timer = 10f;
    public const float COOL_TIME = 0.6f;

    void Update()
    {
        // 타이머 계산
        Timer -= Time.deltaTime;

        Fire();
    }

    private void Fire()
    {
        if (Timer <= 0)
        {
            // 타이머 초기화
            Timer = COOL_TIME;

            for (int i = 0; i < Muzzles.Count; i++) // 총알
            {
                // 1. 꺼져 있는 총알을 꺼낸다.
                Bullet bullet = null;

                foreach (Bullet b in _bulletPool)
                {
                    // 만약에 꺼져(비활성화되어) 있다면
                    if (b.gameObject.activeInHierarchy == false )
                    {
                        bullet = b;
                        break; // 찾았기 때문에 그 뒤까지 찾을 필요가 없다.
                    }
                }

                // 2. 꺼낸 총알의 위치를 총구의 위치로 바꾼다.
                bullet.transform.position = Muzzles[i].transform.position;

                // 3. 총알을 킨다. (발사한다)
                bullet.gameObject.SetActive(true);
            }
        }
    }

}
