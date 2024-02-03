using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using static Item;

public class PlayerFire : MonoBehaviour
{

    [Header("플레이어 공격 프리팹")]
    public GameObject NormalBulletPrefab;
    public GameObject FireBulletPrefab;
    public GameObject KnifeBulletPrefab;
    public float ShootTimer;
    public float Cool_Time = 4;

    [Header("일반 공격 총구")]
    public List<GameObject> NormalMuzzles;

    [Header("화염 공격 총구")]
    public List<GameObject> FireMuzzles;


    public Animator playerAnimator;



    void Start()
    {
        ShootTimer = Cool_Time;
    }

    void Update()
    {
        ShootTimer += Time.deltaTime;

        if (ShootTimer >= Cool_Time && Input.GetMouseButtonDown(0))
        {
            BulletAxisShoot();
        }

        

    }

    // 총알을 발사하는 메서드
    public void Shooting(Vector2 dir)
    {
        ShootTimer = 0;
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < NormalMuzzles.Count; i++)
            {
                GameObject normalBullet = Instantiate(NormalBulletPrefab, transform.position, Quaternion.identity);
                normalBullet.transform.position = NormalMuzzles[i].transform.position;
                normalBullet.GetComponent<Bullet>().SetDirection(dir);
            }

        }
    }
    

    // 방향키에 따라 총알이 나가도록 하는 메서드
    private void BulletAxisShoot()
    {
        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            //Debug.Log("대각선공격1");
            Shooting(new Vector2(1, 1));
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            //Debug.Log("대각선공격");

            Shooting(new Vector2(-1, 1));
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            //Debug.Log("대각선공격");

            Shooting(new Vector2(1, -1));
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            //Debug.Log("대각선공격");

            Shooting(new Vector2(-1, -1));
        }
        else if (Input.GetKey(KeyCode.W) || stateInfo.IsName("Back_Idle"))
        {
            Shooting(new Vector2(0, 1));
        }
        else if (Input.GetKey(KeyCode.S) || stateInfo.IsName("Front_Idle"))
        {
            Shooting(new Vector2(0, -1));
        }
        else if (Input.GetKey(KeyCode.A) || stateInfo.IsName("Left_Idle"))
        {
            Shooting(new Vector2(-1, 0));
        }
        else if (Input.GetKey(KeyCode.D) || stateInfo.IsName("Right_Idle"))
        {
            Shooting(new Vector2(1, 0));
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();

        if (item.IType == ItemType.FireItem)
        {

        }
    }


}
