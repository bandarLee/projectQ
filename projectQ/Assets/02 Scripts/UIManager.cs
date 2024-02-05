using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public float PlayerHealth;
    public GameObject[] Health;

    public TMP_Text Damage;
    public TMP_Text Range;
    public TMP_Text BulletSpeed;
    public TMP_Text Coin;

    [Header("아이템 상태바")]
    public GameObject FireItem;
    public GameObject BloodItem;
    public GameObject KnifeItem;

    [Header("궁극기 상태바")]
    public GameObject BombItem;




    private void Awake()
    {
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
        foreach (GameObject heart in Health)
        {
            heart.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        PlayerHealth = Player.Instance.PlayerHealth;

        Damage.text = $"공격력 {Player.Instance.BulletPower}";
        Range.text = $"사거리 {Player.Instance.maxDistance}";
        BulletSpeed.text = $"탄속도 {Player.Instance.NormalBulletSpeed}";
        Coin.text = $"{Player.Instance.CoinCount} Coin";




        switch (PlayerHealth)
        {
            case 0:
                SetPlayerHealthUI();
                break;
            case 0.5f:
                SetPlayerHealthUI();
                break;
            case 1f:
                SetPlayerHealthUI();

                break;
            case 1.5f:
                SetPlayerHealthUI();

                break;
            case 2f:
                SetPlayerHealthUI();

                break;
            case 2.5f:
                SetPlayerHealthUI();
                break;
            case 3f:
                SetPlayerHealthUI();
                break;

        }


        if (Player.Instance.weapon == Player.PlayerWeapon.FireItem)
        {
            FireItem.SetActive(true);
            BloodItem.SetActive(false);
            KnifeItem.SetActive(false);

        }
        else if (Player.Instance.weapon == Player.PlayerWeapon.BloodItem)
        {
            BloodItem.SetActive(true);
            FireItem.SetActive(false);
            KnifeItem.SetActive(false);

        }
        else if (Player.Instance.weapon == Player.PlayerWeapon.KnifeItem)
        {
            KnifeItem.SetActive(true);
            BloodItem.SetActive(false);
            FireItem.SetActive(false);

        }

        // 궁극기 아이콘 나타나도록 
        if (Player.Instance.bomb == Player.PlayerBomb.Bomb)
        {
            BombItem.SetActive(true);
        }
    }
    void SetPlayerHealthUI()
    {
        for (float i = 0; i < PlayerHealth * 2; i++)
        {
            Health[(int)i].SetActive(true);
        }
        for (float i = PlayerHealth * 2; i < Health.Length; i++)
        {
            Health[(int)i].SetActive(false);

        }
    }
}
