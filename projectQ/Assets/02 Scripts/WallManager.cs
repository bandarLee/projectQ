using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public enum WallType
    {
        Default,
        Left,
        Right,
        Top,
        Bot
    }
    public  WallType walltype;
    void Start()
    {
    }

    void Update()
    {
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.CompareTag("Bullet"))
        {

            Destroy(collision.collider.gameObject);
        }

    }
}
