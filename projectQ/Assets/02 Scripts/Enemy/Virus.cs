using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;

public class Virus : MonoBehaviour // " Follow 타입 "
{
    public float Health = 1;
    public ItemSpawner itemspawner;

    // 플레이어를 따라가는 속도
    public float Movespeed;
    // 위아래로 흔들리는 속도 
    public float Movespeed2;

    // 위아래 흔들림 주기
    public float swingtime = 0.6f;
    // 위아래 흔들림 상태 변경까지 남은 시간
    public float time2;
    private Vector3 initialPosition;


    // 자기 복제 프리팹 
    public GameObject shadowPrefab;
    // 자기 복제 생성 지연 여부
    public bool isCloneDelay;
    // 자기 복제 생성 주기
    public float Respawntime = 2f;
    // 자기 복제 생성까지 남은 시간
    public float time;
    public List<GameObject> clones = new List<GameObject>();
    private void Awake()
    {
        initialPosition = transform.position;

    }
    void Start()
    {
    }
    private void OnEnable()
    {
        Health = 1;
        transform.position = initialPosition;

    }

    void Update()
    {
        // 위로 이동하는 방향
        Vector2 dir1 = new Vector2(0, 0.1f);

        // 아래로 이동하는 방향
        Vector2 dir2 = new Vector2(0, -0.1f);

        //플레이어를 향하는 방향
        Vector2 dir3 = (Player.Instance.transform.position - this.transform.position).normalized;

        // 자기 복제 생성 주기를 계산
        if (isCloneDelay)
        {
            time += Time.deltaTime;
            if (time >= Respawntime)
            {
                time = 0.0f;
                isCloneDelay = false;
            }
        }

        // 위아래 흔들림 주기를 계산
        time2 += Time.deltaTime;
        if (time2 >= swingtime)
        {
            time2 = 0.0f;
        }

        float angle = Mathf.Atan2(dir3.y, dir3.x) * Mathf.Rad2Deg;
        angle += 90f;  // 몬스터가 플레이어를 둘러싸도록 각도를 조절
        dir3 = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        transform.position += (Vector3)(dir3 * Movespeed * Time.deltaTime);

        // 플레이어를 향해 이동
        Vector2 dir4 = new Vector2((Player.Instance.transform.position.x - this.transform.position.x), (Player.Instance.transform.position.y  - this.transform.position.y));
        dir4.Normalize();
        transform.position += (Vector3)(dir4 * Movespeed * Time.deltaTime);

        //위아래 흔들림
        if (time2 < 0.3f) //위로 이동
        {
            transform.position += (Vector3)(dir1 * Movespeed2 * Time.deltaTime);

        }
        if (time2 > 0.3f) //아래로 이동
        {
            transform.position += (Vector3)(dir2 * Movespeed2 * Time.deltaTime);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어와 충돌했는지 확인
        if (collision.collider.CompareTag("Player"))
        {

            // 복제 생성 여부
            if (!isCloneDelay)
            {
                isCloneDelay = true;

                // 복제물 생성 코루틴 시작
                StartCoroutine(CreateClones());
            }

        }

        // 플레이어의 공격을 받았을 때 죽는다
        if (collision.collider.CompareTag("Bullet")) //enemy와 총알이 부딪혔을 때 
        {
   
                Health -= Player.Instance.BulletPower;
            

            // 적의 체력이 끝
            if (Health <= 0)
            {
                itemspawner.SpawnItem(this.transform.position);
                foreach (GameObject clone in clones)
                {
                    Destroy(clone);
                }
                clones.Clear();
                gameObject.SetActive(false);

            }
        }
    }

    private IEnumerator CreateClones()
    {
        int cloneCount = 5; // 생성할 복제물의 수
        float radius = 1f; // 복제가 생성될 반경 설정
        Vector2 playerPos = Player.Instance.transform.position; // 플레이어 위치 가져오기

        // 원형으로 복제물 배치
        for (int i = 0; i < cloneCount; i++)
        {
            // 원형 내에서 복제물의 위치를 결정
            float angle = i * Mathf.PI * 2f / cloneCount; // 복제물 간의 각도 차이 계산
            Vector2 newPos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius; // 원형 내 위치 계산

            // 복제물 생성
            GameObject enemy = Instantiate(shadowPrefab);
            enemy.transform.position = playerPos + newPos; // 복제물 위치 설정
            clones.Add(enemy);
            // 1초 대기
            yield return new WaitForSeconds(1f);
        }
    }
}
