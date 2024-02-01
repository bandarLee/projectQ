using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Rooms;
    public float RoomX = 18.46f;
    public float RoomY = 10.25f;
    void Awake()
    {
        Instantiate(Rooms[1], new Vector3(RoomX, 0), Quaternion.identity);
        Instantiate(Rooms[3], new Vector3(RoomX * 2, 0), Quaternion.identity);
        Instantiate(Rooms[15], new Vector3( RoomX * 2, - RoomY), Quaternion.identity);
        Instantiate(Rooms[16], new Vector3(RoomX * 2, - (2 * RoomY)), Quaternion.identity);
        Instantiate(Rooms[8], new Vector3(RoomX * 3, -(2 * RoomY)), Quaternion.identity);
        Instantiate(Rooms[13], new Vector3(RoomX * 2, -(3 * RoomY)), Quaternion.identity);

        Instantiate(Rooms[10], new Vector3(-RoomX, 0), Quaternion.identity);


    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
