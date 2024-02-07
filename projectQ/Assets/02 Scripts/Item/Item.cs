using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class Item : MonoBehaviour
{
    // 아이템 종류
    // Normal, Rare, Epic, Legend 총 4가지 등급의 아이템들
    public enum ItemType
    {
        Basic,
        FireItem,     // Epic
        KnifeItem,    // Rare
        BloodItem,    // Rare
        CoinItem,     // Noraml
        HeartItem,    // Normal
        KeyCardItem,  
    }

    // 궁극기 종류
    public enum BombType
    {
        None,
        Bomb,         // Normal
        LaserItem     // Legend
        
    }

    public enum PassiveType
    {
        None,
        BulletUPItem,    // Normal 총구 개수 증가 
    }

    public ItemType IType;
    public BombType Bomb_Type;
    public PassiveType PType;

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
            if (Bomb_Type == BombType.Bomb)
            {
                //Debug.Log("플레이어무기 폭탄");
                Player.Instance.bomb = PlayerBomb.Bomb;

            }
            if (Bomb_Type == BombType.LaserItem)
            {
                Player.Instance.bomb = PlayerBomb.Laser;
            }
        }

        if (collision.CompareTag("Player"))
        {


            // 파이어볼, 데미지 3, 광역, 연사속도 +0.5,사거리 5(레어)
            if (IType == ItemType.FireItem)
            {
                Player.Instance.weapon = PlayerWeapon.FireItem;
                Player.Instance.BulletPower = 3f;

                Player.Instance.NormalBulletSpeed = 5.5f;
                Player.Instance.maxDistance = 7f;

            }
            // 수리검, 데미지 0.8, 연사속도 +2, 사거리 1.3(커몬)
            else if (IType == ItemType.KnifeItem)
            {
                //Debug.Log("표창");
                Player.Instance.BulletPower = 1f;

                Player.Instance.weapon = PlayerWeapon.KnifeItem;

                Player.Instance.NormalBulletSpeed = 7f;
                Player.Instance.maxDistance = 5.5f;
            }
            else if (IType == ItemType.BloodItem)
            {
                //Debug.Log("피");
                Player.Instance.weapon = PlayerWeapon.BloodItem;
                Player.Instance.BulletPower = 1.5f;

                Player.Instance.NormalBulletSpeed = 6f;
                Player.Instance.maxDistance = 6f;
            }

            else if (IType == ItemType.CoinItem)
            {
                Player.Instance.CoinCount += 1;
            }

            else if (IType == ItemType.HeartItem)
            {
                Player.Instance.PlayerHealth += 0.5f;

                if (Player.Instance.PlayerHealth >= 3)
                {
                    Player.Instance.PlayerHealth = 3;
                }
            }
            // 카드 아이템
            else if (IType == ItemType.KeyCardItem)
            {
                // 카드를 획득하면, true로 표시
                Player.Instance.HasPlayerCard = true;
            }


            Destroy(this.gameObject);
            {

            }
        }

    }


}

