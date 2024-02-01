using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    [Header("플레이어 공격 프리팹")]
    public GameObject NormalBulletPrefab;
    public float ShootTimer;
    public float Cool_Time = 4;

    [Header("일반 공격 총구")]
    public List<GameObject> Muzzles;

    public Animator playerAnimator;



    void Start()
    {
        ShootTimer = Cool_Time;
    }

    void Update()
    {
        ShootTimer += Time.deltaTime;
        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);

        if (ShootTimer >= Cool_Time && Input.GetMouseButtonDown(0))
        {

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                Debug.Log("대각선공격1");
                Shooting(new Vector2(1, 1));
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                Debug.Log("대각선공격");

                Shooting(new Vector2(-1, 1));
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                Debug.Log("대각선공격");

                Shooting(new Vector2(1, -1));
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                Debug.Log("대각선공격");

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
    





    }

    // 총알을 발사하는 코드 
    public void Shooting(Vector2 dir)
    {
        ShootTimer = 0;
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < Muzzles.Count; i++)
            {
                GameObject normalBullet = Instantiate(NormalBulletPrefab, transform.position, Quaternion.identity);
                normalBullet.transform.position = Muzzles[i].transform.position;
                normalBullet.GetComponent<Bullet>().SetDirection(dir);
            }

        }
    }
}
