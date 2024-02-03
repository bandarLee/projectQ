using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Item;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Vector2 PlayerPosition;

    public float PlayerHealth = 3f;
    public float maxDistance = 3.5f;   // 총알 사거리
    public float NormalBulletSpeed;   // 총알의 속도
    public float BulletPower;         // 총알의 데미지

    public bool PlayerDamageDelay = false;
    public float time;
    public float PlayerDamageNuckbackTime = 1f;

    public enum PlayerWeapon
    {
        Basic,
        FireItem,
        KnifeItem,
        BloodItem

    }

    public PlayerWeapon weapon = PlayerWeapon.Basic;
    private void Awake()
    {
        // 싱글톤 패턴 : 오직 한개의 클래스 인스턴스를 갖도록 보장
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    void Start()
    {

    }

    void Update()
    {
        if (PlayerDamageDelay)
        {
            time += Time.deltaTime;
            if (time >= PlayerDamageNuckbackTime)
            {
                Debug.Log("넉백");
                time = 0.0f;
                PlayerDamageDelay = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!PlayerDamageDelay)
        {
            if (collision.collider.CompareTag("OneEyeEnemy"))
            {
                PlayerHealth -= 0.5f;
            }
            PlayerDamageDelay = true;

        }

    }
    /*private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("OneEyeEnemy"))
        {
            PlayerHealth -= 0.1f * Time.deltaTime;
        }

    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();

        if (item.IType == ItemType.FireItem)
        {
            weapon = PlayerWeapon.FireItem;
        }
        else if (item.IType == ItemType.KnifeItem)
        {
            weapon = PlayerWeapon.KnifeItem;
        }
        else if (item.IType == ItemType.BloodItem)
        {
            weapon = PlayerWeapon.BloodItem;
        }



    }

}
