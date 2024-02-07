using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Body : MonoBehaviour
{
    public float Health = 10;
    public ItemSpawner itemspawner;

    public void OnCollisionEnter2D(Collision2D collision) 
    { 
    // 플레이어의 공격을 받았을 때 죽는다
        if (collision.collider.CompareTag("Bullet")) //enemy와 총알이 부딪혔을 때 
        {

            Health -= Player.Instance.BulletPower;


            // 총알 삭제
            collision.collider.gameObject.SetActive(false);

            // 적의 체력이 끝
            if (Health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
