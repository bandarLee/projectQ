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

    public float PlayerHealth = 5f;
    public float maxDistance = 5.5f;   // 총알 사거리
    public float NormalBulletSpeed = 4.5f;   // 총알의 속도
    public float BulletPower = 0.5f;         // 총알의 데미지

    public bool PlayerDamageDelay = false;
    public float time;
    public float PlayerDamageNuckbackTime = 1f;
    public bool IsPlayerMove = false;

    public bool HasPlayerCard = false;



    public int CoinCount = 0;

    public enum PlayerWeapon
    {
        Basic,
        FireItem,
        KnifeItem,
        BloodItem,
    }

    public enum PlayerBomb
    {
        None,
        Bomb,
        Laser,
    }

    public enum PlayerPassive
    {
        None,
        BulletUP,
    }

    
    public PlayerWeapon weapon = PlayerWeapon.Basic;
    public PlayerBomb bomb = PlayerBomb.None;
    public PlayerPassive passive = PlayerPassive.None;

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

        DontDestroyOnLoad(this.gameObject);


    }
    void Start()
    {

    }

    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!PlayerDamageDelay)
        {
            if (collision.collider.CompareTag("OneEyeEnemy"))
            {
                PlayerHealth -= 0.5f;
                UIManager.Instance.DamageScreen.SetActive(true);
                PlayerDamageDelay = true;

                StartCoroutine(DamageDelayCoroutine());
            }
            if (collision.collider.CompareTag("EnemyBullet"))
            {
                PlayerHealth -= 0.5f;
                UIManager.Instance.DamageScreen.SetActive(true);
                PlayerDamageDelay = true;
                StartCoroutine(DamageDelayCoroutine());
            }
            if (collision.collider.CompareTag("Enemy"))
            {
                PlayerHealth -= 0.5f;
                UIManager.Instance.DamageScreen.SetActive(true);
                PlayerDamageDelay = true;
                StartCoroutine(DamageDelayCoroutine());
            }


            //PlayerDamageDelay = true;
        }
    }
    IEnumerator DamageDelayCoroutine()
    {
        yield return new WaitForSeconds(1f);
        UIManager.Instance.DamageScreen.SetActive(false);
        PlayerDamageDelay = false;
    }


}
