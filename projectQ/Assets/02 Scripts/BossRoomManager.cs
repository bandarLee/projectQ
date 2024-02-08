using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossRoomManager : MonoBehaviour
{
    public static BossRoomManager Instance;

    public GameObject BossWallLeft;
    public GameObject BossWallRight;
    public GameObject BossWallTop;
    public GameObject BossWallBottom;
    public int totalBosses = 6;
    private int destroyedBosses = 0;



    private void Awake()
    {
        Player.Instance.transform.position = this.transform.position;

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
     
    }

    void Update()
    {
    }
    public void OnBossDestroyed()
    {
        destroyedBosses++;

        // 모든 보스 몹이 파괴되었는지 확인
        if (destroyedBosses >= totalBosses)
        {
            SceneManager.LoadScene("Level2");

        }
    }
}
