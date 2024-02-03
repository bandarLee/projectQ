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



        switch (PlayerHealth)
        {
            case 0:
                foreach (GameObject heart in Health)
                {
                    heart.gameObject.SetActive(false);
                }
                break;
            case 0.5f:

                Health[1].SetActive(false);
                Health[2].SetActive(false);
                Health[3].SetActive(false);
                Health[4].SetActive(false);
                Health[5].SetActive(false);
                break;
            case 1f:

                Health[2].SetActive(false);
                Health[3].SetActive(false);
                Health[4].SetActive(false);
                Health[5].SetActive(false);

                break;
            case 1.5f:
                Health[3].SetActive(false);
                Health[4].SetActive(false);
                Health[5].SetActive(false);

                break;
            case 2f:
                Health[4].SetActive(false);
                Health[5].SetActive(false);

                break;
            case 2.5f:

                Health[5].SetActive(false);
                break;
            case 3f:

                foreach (GameObject heart in Health)
                {
                    heart.gameObject.SetActive(true);
                }
                break;

        }
    }
}
