using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom2Manager : MonoBehaviour
{
    public static BossRoom2Manager Instance;

    public OneEye[] oneeyes;
    public OneEye_Clone[] oneeyesClone;
    public OneEye1[] oneeyesred;
    public BasicEnemy[] basicEnemy;
    public Virus[] virus;
    public Snake[] snake;
    public Boss2[] boss;
    public int totalBosses = 4;

    // 현재 파괴된 보스 몹의 수
    private int destroyedBosses = 0;
    void Awake()
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
    public enum RoomNumber
    {
        A,
        B,
        C,
        D

    }
    RoomNumber roomNumber = RoomNumber.A;
    void Start()
    {
        {
            boss = GameObject.FindObjectsOfType<Boss2>();
            oneeyes = GameObject.FindObjectsOfType<OneEye>();
            oneeyesClone = GameObject.FindObjectsOfType<OneEye_Clone>();
            oneeyesred = GameObject.FindObjectsOfType<OneEye1>();
            basicEnemy = GameObject.FindObjectsOfType<BasicEnemy>();
            virus = GameObject.FindObjectsOfType<Virus>();
            snake = GameObject.FindObjectsOfType<Snake>();
            foreach (Boss2 boss2 in boss)
            {
                boss2.gameObject.SetActive(false);
            }
            foreach (OneEye oneeye in oneeyes)
            {
                oneeye.gameObject.SetActive(false);
            }
            foreach (OneEye_Clone oneeyes in oneeyesClone)
            {
                oneeyes.gameObject.SetActive(false);
            }
            foreach (OneEye1 oneeyes in oneeyesred)
            {
                oneeyes.gameObject.SetActive(false);
            }
            foreach (BasicEnemy basicenemies in basicEnemy)
            {
                basicenemies.gameObject.SetActive(false);
            }
            foreach (Virus viruses in virus)
            {
                viruses.gameObject.SetActive(false);
            }
            foreach (Snake snakes in snake)
            {
                snakes.gameObject.SetActive(false);
            }

            boss[0].gameObject.SetActive(true);
        }

    }
    public void OnBossDestroyed()
    {
        destroyedBosses++;

        // 모든 보스 몹이 파괴되었는지 확인
        if (destroyedBosses >= totalBosses)
        {
            // 여기서 씬 로드 로직을 구현합니다.
            // 예를 들어, SceneManager.LoadScene 메서드를 사용하여 씬을 로드할 수 있습니다.
            // SceneManager.LoadScene("NextScene");
        }
    }
    void Update()
    {
        if ((BossCamera2Move.Instance.transform.position.y > 1.5))
        {
            if ((BossCamera2Move.Instance.transform.position.x > 9.5))
            {
                SetActiveBoss(3);
            }
            if ((BossCamera2Move.Instance.transform.position.x < 9.5))
            {
                SetActiveBoss(0);
            }
        }
        if ((BossCamera2Move.Instance.transform.position.y <= 1.5))
        {
            if ((BossCamera2Move.Instance.transform.position.x > 9.5))
            {
                SetActiveBoss(1);
            }
            if ((BossCamera2Move.Instance.transform.position.x < 9.5))
            {
                SetActiveBoss(2);
            }
        }
    }

    void SetActiveBoss(int bossIndex)
    {
        if (boss[bossIndex] != null && !boss[bossIndex].gameObject.activeSelf)
        {
            for (int i = 0; i < boss.Length; i++)
            {
                if (boss[i] != null)
                {
                    boss[i].gameObject.SetActive(i == bossIndex);
                }
            }
        }
    }
}
