using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Lever1ManagerTrigger;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;

    private float Movespeed = 3f; // 이동 속도 : 초당 3만큼 이동하겠다.
    public Animator MyAnimatior;

    public Vector2 intiatePosition;
    public Vector2 targetPosition; // 플레이어가 이동해야 할 위치
    public DoorType moveDirection; // 플레이어가 이동해야 할 방향

    private void Awake()
    {
        // 싱글톤 패턴 : 오직 한개의 클래스 인스턴스를 갖도록 보장
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
        Vector3 intiatePlayerPosition = this.transform.position;
        intiatePosition = intiatePlayerPosition;

    }

    void Update()
    {
        if (moveDirection == DoorType.Default)
        {
            // 플레이어가 레버를 작동시키지 않았을 때만 WASD 키 입력을 받음
            float h = Input.GetAxisRaw("Horizontal"); // -1.0f ~0f ~ +1.0f 수평값
            float v = Input.GetAxisRaw("Vertical"); // -1.0f ~0f ~ +1.0f 수직값

            Vector2 dir = new Vector2(h, v);
            dir = dir.normalized;

            MyAnimatior.SetInteger("h", (int)h);
            MyAnimatior.SetInteger("v", (int)v);

            Vector2 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
            transform.position = newPosition;
        }
        else
        {
            // 레버를 작동시킨 후에는 targetPosition으로 이동
            if (moveDirection == DoorType.Left)
            {
                targetPosition = new Vector2(transform.position.x - 5f, transform.position.y);
            }
            else if (moveDirection == DoorType.Right)
            {
                targetPosition = new Vector2(transform.position.x + 5f, transform.position.y);
            }
            else if (moveDirection == DoorType.Top)
            {
                targetPosition = new Vector2(transform.position.x, transform.position.y + 5f);
            }
            else if (moveDirection == DoorType.Bot)
            {
                targetPosition = new Vector2(transform.position.x, transform.position.y - 5f);
            }

            transform.position = targetPosition;
            // 플레이어가 targetPosition에 도달했으므로 이동을 멈춤
            moveDirection = DoorType.Default;
        }
    }

}
