using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BossCameraMove : MonoBehaviour
{
    private float Movespeed = 2f; // 이동 속도 : 초당 3만큼 이동하겠다.
    public static BossCameraMove Instance;
    public bool LeftMove = false;
    public bool RightMove = false;
    public bool UpMove = false;
    public bool DownMove = false;
    public Vector3 intiatePosition;

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
        Vector3 intiateRoomPosition = this.transform.position;
        intiatePosition = intiateRoomPosition;

    }

    void Update()
    {
        if (LeftMove)
        {
            Vector3 dir = new Vector3(-18.46f, 0f);
            if (this.transform.position.x > (intiatePosition.x + dir.x))
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
                newPosition.z = -10;
                transform.position = newPosition;
                Player.Instance.IsPlayerMove = true;

            }
            else
            {
                LeftMove = false;
                intiatePosition = this.transform.position;
                Player.Instance.IsPlayerMove = false;
            }


        }
        if (RightMove)
        {
            Vector3 dir = new Vector3(18.46f, 0f);
            if (this.transform.position.x < (intiatePosition.x + dir.x))
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
                newPosition.z = -10;
                transform.position = newPosition;
                Player.Instance.IsPlayerMove = true;

            }
            else
            {
                RightMove = false;
                intiatePosition = this.transform.position;
                Player.Instance.IsPlayerMove = false;

            }

        }
        if (UpMove)
        {
            Vector3 dir = new Vector3(0f, 10.25f);
            if (this.transform.position.y < (intiatePosition.y + dir.y))
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
                newPosition.z = -10;
                transform.position = newPosition;
                Player.Instance.IsPlayerMove = true;

            }
            else
            {
                UpMove = false;
                intiatePosition = this.transform.position;
                Player.Instance.IsPlayerMove = false;

            }

        }
        if (DownMove)
        {
            Vector3 dir = new Vector3(0f, -10.25f);
            if (this.transform.position.y > (intiatePosition.y + dir.y))
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
                newPosition.z = -10;
                transform.position = newPosition;
                Player.Instance.IsPlayerMove = true;


            }
            else
            {
                DownMove = false;
                intiatePosition = this.transform.position;
                Player.Instance.IsPlayerMove = false;

            }

        }

    }
}
