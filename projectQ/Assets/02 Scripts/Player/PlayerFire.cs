using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Item;
using static UnityEditorInternal.ReorderableList;

public class PlayerFire : MonoBehaviour
{
    public enum GetFireButton
    {
        Default,
        Left,
        Up,
        Down,
        Right

    }
    public GetFireButton getfirebutton = GetFireButton.Default;
    [Header("플레이어 기본 공격 프리팹")]
    public GameObject NormalBulletPrefab;
    public GameObject FireBulletPrefab;
    public GameObject KnifeBulletPrefab;
    public GameObject BloodBulletPrefab;

    [Header("플레이어 궁극기 공격 프리팹")]
    public GameObject BombBulletPrefab;

    // 공격 쿨타임과 쿨타임을 재는 타이머
    [Header("기본 총알 타이머 & 쿨타임")]
    public float ShootTimer;
    public float Cool_Time = 4f;

    // 궁극기 폭탄 쿨타임 설정
    [Header("궁극기 타이머 & 쿨타임")]
    private float BombTimer = 0f;
    private float Bomb_Cool_Time = 7f;


    [Header("일반 공격 총구")]
    public List<GameObject> NormalMuzzles;

    [Header("두배 공격 총구")]
    public List<GameObject> DoubleMuzzle;

    public Vector3 bulletVector;
    public Animator playerAnimator;



    void Start()
    {
        ShootTimer = Cool_Time;
        BombTimer = Bomb_Cool_Time;
    }

    void Update()
    {
        ShootTimer += Time.deltaTime;
        BombTimer += Time.deltaTime;
        GetArrowKey();
        // 쿨타임이 다 찼고, 마우스 버튼이 눌렸다면 공격 실행
        if (ShootTimer >= Cool_Time && (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space)))
            {
                BulletAxisShoot();
            }
        if (ShootTimer >= Cool_Time && (getfirebutton != GetFireButton.Default))
            {
                BulletArrowKeyShoot();
            }
        // 폭탄 쿨타임 
        if (BombTimer >= Bomb_Cool_Time && Input.GetKeyDown(KeyCode.F))
        {
            BombShoot();
        }

    }

    // 총알을 발사하는 메서드
    public void Shooting(Vector2 dir)
    {
        // 공격이 실행되면 쿨타임 타이머를 0으로 초기화하고 총알 생성
        ShootTimer = 0;
                 for (int i = 0; i < NormalMuzzles.Count; i++)
            {
                if (Player.Instance.weapon == Player.PlayerWeapon.Basic)
                {
                    GameObject normalBullet = Instantiate(NormalBulletPrefab, transform.position, Quaternion.Euler(bulletVector));
                    normalBullet.transform.position = NormalMuzzles[i].transform.position;
                    normalBullet.GetComponent<Bullet>().SetDirection(dir.normalized);
                }
                else if (Player.Instance.weapon == Player.PlayerWeapon.FireItem)
                {
                    GameObject fireBullet = Instantiate(FireBulletPrefab, transform.position, Quaternion.Euler(bulletVector));
                    fireBullet.transform.position = NormalMuzzles[i].transform.position;
                    fireBullet.GetComponent<Bullet>().SetDirection(dir.normalized);
                }

                else if (Player.Instance.weapon == Player.PlayerWeapon.KnifeItem)
                {
                    GameObject knifeBullet = Instantiate(KnifeBulletPrefab, transform.position, Quaternion.Euler(bulletVector));
                    knifeBullet.transform.position = NormalMuzzles[i].transform.position;
                    knifeBullet.GetComponent<Bullet>().SetDirection(dir.normalized);
                }
                else if (Player.Instance.weapon == Player.PlayerWeapon.BloodItem)
                {
                    GameObject bloodBullet = Instantiate(BloodBulletPrefab, transform.position, Quaternion.Euler(bulletVector));
                    bloodBullet.transform.position = NormalMuzzles[i].transform.position;
                    bloodBullet.GetComponent<Bullet>().SetDirection(dir.normalized);
                }


          

        }

    }
    public void Shooting2(Vector2 dir)
    {
        // 공격이 실행되면 쿨타임 타이머를 0으로 초기화하고 총알 생성
        ShootTimer = 0;
        getfirebutton = GetFireButton.Default;


        for (int i = 0; i < NormalMuzzles.Count; i++)
        {
            if (Player.Instance.weapon == Player.PlayerWeapon.Basic)
            {
                GameObject normalBullet = Instantiate(NormalBulletPrefab, transform.position, Quaternion.Euler(bulletVector));
                normalBullet.transform.position = NormalMuzzles[i].transform.position;
                normalBullet.GetComponent<Bullet>().SetDirection(dir.normalized);
            }
            else if (Player.Instance.weapon == Player.PlayerWeapon.FireItem)
            {
                GameObject fireBullet = Instantiate(FireBulletPrefab, transform.position, Quaternion.Euler(bulletVector));
                fireBullet.transform.position = NormalMuzzles[i].transform.position;
                fireBullet.GetComponent<Bullet>().SetDirection(dir.normalized);
            }

            else if (Player.Instance.weapon == Player.PlayerWeapon.KnifeItem)
            {
                GameObject knifeBullet = Instantiate(KnifeBulletPrefab, transform.position, Quaternion.Euler(bulletVector));
                knifeBullet.transform.position = NormalMuzzles[i].transform.position;
                knifeBullet.GetComponent<Bullet>().SetDirection(dir.normalized);
            }
            else if (Player.Instance.weapon == Player.PlayerWeapon.BloodItem)
            {
                GameObject bloodBullet = Instantiate(BloodBulletPrefab, transform.position, Quaternion.Euler(bulletVector));
                bloodBullet.transform.position = NormalMuzzles[i].transform.position;
                bloodBullet.GetComponent<Bullet>().SetDirection(dir.normalized);
            }




        }

    }

    private void BulletAxisShoot()
    {

        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            bulletVector = new Vector3(0, 0, 145);

            Shooting(new Vector2(1, 1));
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {

           bulletVector = new Vector3(0, 0, -125);
           Shooting(new Vector2(-1, 1));
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {

            bulletVector = new Vector3(0, 0, 55);

            Shooting(new Vector2(1, -1));
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            bulletVector = new Vector3(0, 0, -35);

            //Debug.Log("대각선공격");
            Shooting(new Vector2(-1, -1));
        }
        else if (Input.GetKey(KeyCode.W) || stateInfo.IsName("Back_Idle"))
        {
            bulletVector = new Vector3(0, 0, 180);

            Shooting(new Vector2(0, 1));

        }
        else if (Input.GetKey(KeyCode.S) || stateInfo.IsName("Front_Idle"))
        {
            bulletVector = new Vector3(0, 0, 0);

            Shooting(new Vector2(0, -1));

        }
        else if (Input.GetKey(KeyCode.A) || stateInfo.IsName("Left_Idle"))
        {
            bulletVector = new Vector3(0, 0, -90);

            Shooting(new Vector2(-1, 0));

        }
        else if (Input.GetKey(KeyCode.D) || stateInfo.IsName("Right_Idle"))
        {
            bulletVector = new Vector3(0, 0, 90);

            Shooting(new Vector2(1, 0));

        }
    }
    private void BulletArrowKeyShoot()
    {
        switch(getfirebutton)
        {
            case GetFireButton.Left:
                Shooting2(new Vector2(-1, 0));

                break;
            case GetFireButton.Right:
                Shooting2(new Vector2(1, 0));

                break; 
            case GetFireButton.Up:
                Shooting2(new Vector2(0, 1));

                break; 
            case GetFireButton.Down:
                Shooting2(new Vector2(0, -1));

                break;
        }
    }

    // F키를 누르면 궁극기 발동 - 폭탄
    private void BombShoot()
    {
        BombTimer = 0;

        if (Player.Instance.bomb == Player.PlayerBomb.Bomb && Input.GetKeyDown(KeyCode.F))
        {
            GameObject bomb = Instantiate(BombBulletPrefab);
            bomb.transform.position = this.transform.position;
        }
    }
    private void GetArrowKey()
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    getfirebutton = GetFireButton.Up;
                }
            if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    getfirebutton = GetFireButton.Down;
                }
            if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    getfirebutton = GetFireButton.Right;
                }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    getfirebutton = GetFireButton.Left;
                }

    }

}
