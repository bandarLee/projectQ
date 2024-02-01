using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
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


        if (collision.collider.tag == "Bullet")
        {

            Destroy(collision.collider.gameObject);
        }

    }
}
