using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    public enum BombBulletType
    {
        None,
        Bomb,  
        Laser
    }

    public BombBulletType Bomb_Type;

    // 폭탄 터지는 타이머
    public float bombBoomTimer = 0f;
    

    // 폭탄 궁극기가 터질 때 발동하는 Animator
    public Animator BombAnimator;
    public GameObject VfxExplosion;
    public GameObject VfxLaser;

    void Start()
    {
        BombAnimator = GetComponent<Animator>();
        BombAnimator.SetFloat("Bombtime", (float)bombBoomTimer);
    }

    private void Awake()
    {
        bombBoomTimer = 0f;

        if (Bomb_Type == BombBulletType.Bomb )
        {
            BombAnimator.Play("BombAnimation");
        }
        else if (Bomb_Type == BombBulletType.Laser)
        {
            
        }

    }

    void Update()
    {

        bombBoomTimer += Time.deltaTime;

        if (bombBoomTimer >= 2.5f)
        {
            Instantiate(VfxExplosion, this.transform.position, Quaternion.identity);
            
            Destroy(this.gameObject);
        }

    }
}
