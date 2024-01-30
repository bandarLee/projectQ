using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float Movespeed = 3f; // �̵� �ӵ� : �ʴ� 3��ŭ �̵��ϰڴ�.
    public Animator MyAnimatior;

    void Start()
    {

    }

    void Update()
    {


        float h = Input.GetAxisRaw("Horizontal"); // -1.0f ~0f ~ +1.0f ����
        float v = Input.GetAxisRaw("Vertical"); // -1.0f ~0f ~ +1.0f ������


        //Vector2 dir = Vector2.right * h + Vector2.up * v;
        Vector2 dir = new Vector2(h, v);
        dir = dir.normalized;

        MyAnimatior.SetInteger("h", (int)h);
        MyAnimatior.SetInteger("v", (int)v);

        Vector2 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
        transform.position = newPosition;

    }
}
