using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    public enum BombBulletType
    {
        None,
        Bomb,        
    }

    public BombBulletType Bomb_Type;

    // 폭탄 터지는 타이머
    private float bombBoomTimer = 4f;
    

    // 폭탄 궁극기가 터질 때 발동하는 Animator
    public Animator BombAnimator;

    void Start()
    {
        BombAnimator = GetComponent<Animator>();
    }

    private void Awake()
    {
        bombBoomTimer = 4f;

        if (Bomb_Type == BombBulletType.Bomb && bombBoomTimer <= 0)
        {
            BombAnimator.Play("BombAnimation");
            Destroy(this.gameObject);
        }

    }

    void Update()
    {
        bombBoomTimer -= Time.deltaTime;
    }
}
