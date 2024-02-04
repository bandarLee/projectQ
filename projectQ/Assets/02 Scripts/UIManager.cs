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

        Damage.text = $"{Player.Instance.BulletPower}";
        Range.text = $"{Player.Instance.maxDistance}";
        BulletSpeed.text = $"{Player.Instance.NormalBulletSpeed}";
        Coin.text = $"{Player.Instance.CoinCount}";
        



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
