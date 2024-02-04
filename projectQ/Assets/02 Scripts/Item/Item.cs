using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Basic,
        FireItem,     // Epic
        KnifeItem,    // Rare
        BloodItem,    // Unique
        CoinItem,     // Noraml
        HeartItem     // Normal

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



        if (collision.CompareTag("Player"))
        {
      

            // 파이어볼, 데미지 3, 광역, 연사속도 +0.5,사거리 5(레어)
            if (IType == ItemType.FireItem)
            {
                Player.Instance.weapon = PlayerWeapon.FireItem;

                Player.Instance.NormalBulletSpeed = 4.5f;
                Player.Instance.maxDistance = 7f;

            }
            // 수리검, 데미지 0.8, 연사속도 +2, 사거리 1.3(커몬)
            else if (IType == ItemType.KnifeItem)
            {
                //Debug.Log("표창");

                Player.Instance.weapon = PlayerWeapon.KnifeItem;

                Player.Instance.NormalBulletSpeed = 6f;
                Player.Instance.maxDistance = 4.5f;
            }
            else if (IType == ItemType.BloodItem)
            {
                //Debug.Log("피");
                Player.Instance.weapon = PlayerWeapon.BloodItem;

                Player.Instance.NormalBulletSpeed = 5.5f;
                Player.Instance.maxDistance = 5.5f;
            }

            else if (IType == ItemType.CoinItem)
            {
                Player.Instance.CoinCount += 1;
            }

            else if (IType == ItemType.HeartItem)
            {
                Player.Instance.PlayerHealth += 0.5f;
            }

            else
            {
                Player.Instance.weapon = PlayerWeapon.Basic;
            }

            Destroy(this.gameObject);

        }

    }


}

