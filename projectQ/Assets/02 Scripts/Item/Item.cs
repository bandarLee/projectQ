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

       if (collision.CompareTag ( "Player"))
        {

            // 파이어볼, 데미지 3, 광역, 연사속도 0.5,사거리 1.5(레어)
            if (IType == ItemType.FireItem)
            {

            }
            // 
            else if (IType == ItemType.KnifeItem)
            {

            }

            Destroy(this.gameObject);

        }
    }
}
