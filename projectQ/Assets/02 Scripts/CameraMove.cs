using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    private float Movespeed = 2f; // 이동 속도 : 초당 3만큼 이동하겠다.
    public GameObject RoomC;
    public static CameraMove Instance;
    public bool Level1Move = false;

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

    void Update()
    {
        if (Level1Move)
        {
            Vector3 dir = RoomC.transform.position;
            if (transform.position.x > RoomC.transform.position.x)
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
                newPosition.z = -10;
                transform.position = newPosition;

            }
        }

    }

}
