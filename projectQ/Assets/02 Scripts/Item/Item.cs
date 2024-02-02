using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   　public enum ItemType
    {
        FireItem,
        KnifeItem,

    }

    public ItemType IType;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerFire playerFire = collision.GetComponent<PlayerFire>();
        Bullet bullet = gameObject.GetComponent<Bullet>();

       if (collision.CompareTag ( "Player"))
        {

            // 파이어볼, 데미지 3, 광역, 연사속도 +0.5,사거리 5(레어)
            if (IType == ItemType.FireItem)
            {
                bullet.NormalBulletSpeed = bullet.NormalBulletSpeed + 0.5f;
                bullet.maxDistance = 5f;
                
            }
            // 수리검, 데미지 0.8, 연사속도 +2, 사거리 1.3(커몬)
            else if (IType == ItemType.KnifeItem)
            {
                bullet.NormalBulletSpeed = bullet.NormalBulletSpeed + 2f;
                bullet.maxDistance = 3.5f;
            }

            Destroy(this.gameObject);

        }
    }
}
