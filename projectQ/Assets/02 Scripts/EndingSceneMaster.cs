using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndingSceneMaster : MonoBehaviour
{
    private float Movespeed = 2f; // 이동 속도 : 초당 3만큼 이동하겠다.
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 dir = new Vector3(0, 120);
        if (transform.position.y < 1290)
        {
            Vector3 newPosition = (this.transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
            this.transform.position = newPosition;
        }
    }
}
