using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BossCameraMove : MonoBehaviour
{
    private float Movespeed = 15f; // 이동 속도 : 초당 3만큼 이동하겠다.
    public static BossCameraMove Instance;
    public bool LeftMove = false;
    public bool RightMove = false;
    public bool UpMove = false;
    public bool DownMove = false;

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

        if (LeftMove)
        {
            Vector3 dir = new Vector3(1.05f, 0f);
            if (this.transform.position.x > (dir.x))
            {
                Vector3 newPosition = (transform.position - (Vector3)(dir.normalized * Movespeed * Time.deltaTime));
                newPosition.z = -10;
                transform.position = newPosition;
                Player.Instance.IsPlayerMove = true;

            }
            else
            {
                LeftMove = false;
                Player.Instance.IsPlayerMove = false;
            }


        }
        if (RightMove)
        {
            Vector3 dir = new Vector3(17.14f, 0f);
            if (this.transform.position.x < ( dir.x))
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir.normalized * Movespeed * Time.deltaTime));
                newPosition.z = -10;
                transform.position = newPosition;
                Player.Instance.IsPlayerMove = true;

            }
            else
            {
                RightMove = false;
                Player.Instance.IsPlayerMove = false;

            }

        }
        if (UpMove)
        {
            Vector3 dir = new Vector3(0f, 5.66f);
            if (this.transform.position.y < (dir.y))
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir.normalized * Movespeed * Time.deltaTime));
                newPosition.z = -10;
                transform.position = newPosition;
                Player.Instance.IsPlayerMove = true;

            }
            else
            {
                UpMove = false;
                Player.Instance.IsPlayerMove = false;

            }

        }
        if (DownMove)
        {
            Vector3 dir = new Vector3(0f, -2.57f);
            if (this.transform.position.y > (dir.y))
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir.normalized * Movespeed * Time.deltaTime));
                newPosition.z = -10;
                transform.position = newPosition;
                Player.Instance.IsPlayerMove = true;


            }
            else
            {
                DownMove = false;
                Player.Instance.IsPlayerMove = false;

            }

        }

    }
}
