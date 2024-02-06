using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MiniMapCameraMove : MonoBehaviour
{
    private Vector3 intiatePosition;
    private float Movespeed = 2f;
    public float transparency = 0.1f;
    private void Awake()
    {
       



        Vector3 intiateRoomPosition = this.transform.position;
          intiatePosition = intiateRoomPosition;

        
    }
    private void Start()
    {
        TilemapRenderer[] tilemapRenderers = FindObjectsOfType<TilemapRenderer>();

        foreach (TilemapRenderer tilemapRenderer in tilemapRenderers)
        {
            Material material = new Material(tilemapRenderer.material);
            Color color = material.color;
            color.a = transparency;
            material.color = color;
            tilemapRenderer.material = material;
        }

    }
    void Update()
    {
        if (CameraMove.Instance.LeftMove)
        {
            Vector3 dir = new Vector3(-18.46f, 0f);
            if (this.transform.position.x > (intiatePosition.x + dir.x))
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
                newPosition.z = -30;
                transform.position = newPosition;

            }
            else
            {
                intiatePosition = this.transform.position;
            }


        }
        if (CameraMove.Instance.RightMove)
        {
            Vector3 dir = new Vector3(18.46f, 0f);
            if (this.transform.position.x < (intiatePosition.x + dir.x))
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
                newPosition.z = -30;
                transform.position = newPosition;

            }
            else
            {
                intiatePosition = this.transform.position;

            }

        }
        if (CameraMove.Instance.UpMove)
        {
            Vector3 dir = new Vector3(0f, 10.25f);
            if (this.transform.position.y < (intiatePosition.y + dir.y))
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
                newPosition.z = -30;
                transform.position = newPosition;

            }
            else
            {
                intiatePosition = this.transform.position;

            }

        }
        if (CameraMove.Instance.DownMove)
        {
            Vector3 dir = new Vector3(0f, -10.25f);
            if (this.transform.position.y > (intiatePosition.y + dir.y))
            {
                Vector3 newPosition = (transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
                newPosition.z = -30;
                transform.position = newPosition;


            }
            else
            {
                intiatePosition = this.transform.position;

            }

        }

    
}
}
