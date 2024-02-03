using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public float PlayerHealth;
    public GameObject[] Health;

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

        switch(PlayerHealth)
        {
            case 0:
                Debug.Log("플레이어 체력 0");
                foreach (GameObject heart in Health)
                {
                    heart.gameObject.SetActive(false);
                }
                break;
            case 0.5f:
                Debug.Log("플레이어 체력 0.5");

                Health[1].SetActive(false);
                Health[2].SetActive(false);
                Health[3].SetActive(false);
                Health[4].SetActive(false);
                Health[5].SetActive(false);
                break;
            case 1f:
                Debug.Log("플레이어 체력 1");

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
                Debug.Log("플레이어 체력 2.5");

                Health[5].SetActive(false);
                break;
            case 3f:
                Debug.Log("플레이어 체력 3");

                foreach (GameObject heart in Health)
                {
                    heart.gameObject.SetActive(true);
                }
                break;

        }
    }
}
