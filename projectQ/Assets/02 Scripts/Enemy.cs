using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType // 적 타입 '열거형'
{
    Basic, // EnemyType.Basic 타입: 아래로 이동,
    Target,  // EnemyType.Target 타입: '처음' 태어났을 때 플레이어가 있는 방향으로 이동
    Follow  // EnemyType.Follow 타입: 계속 플레이어가 있는 방향으로 이동
}

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
