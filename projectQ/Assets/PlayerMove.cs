using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float Movespeed = 3f; // 이동 속도 : 초당 3만큼 이동하겠다.
    public Animator MyAnimatior;

    void Start()
    {

    }

    void Update()
    {


        float h = Input.GetAxisRaw("Horizontal"); // -1.0f ~0f ~ +1.0f 수평값
        float v = Input.GetAxisRaw("Vertical"); // -1.0f ~0f ~ +1.0f 수직값


        //Vector2 dir = Vector2.right * h + Vector2.up * v;
        Vector2 dir = new Vector2(h, v);
        dir = dir.normalized;

        MyAnimatior.SetInteger("h", (int)h);
        MyAnimatior.SetInteger("v", (int)v);

        Vector2 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
        transform.position = newPosition;

    }
}
