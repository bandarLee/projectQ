using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    [Header("플레이어 공격 프리팹")]
    public GameObject NormalBulletPrefab;
    public float ShootTimer;
    public float Cool_Time = 4;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void Shooting()
    {
        ShootTimer = Cool_Time;


    }
}
