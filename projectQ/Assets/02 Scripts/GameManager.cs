using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject[] Rooms;
    public float RoomX = 18.46f;
    public float RoomY = 10.25f;
    public GameObject Player;
    // 각 패턴의 방 위치와 타입을 저장하는 배열
    private (Vector3 position, int roomType)[][] roomPatterns =
    {
        new (Vector3 position, int roomType)[]
            {
                (new Vector3(1, 0), 1),
                (new Vector3(2, 0), 3),
                (new Vector3(2, -1), 15),
                (new Vector3(2, -2), 16),
                (new Vector3(3, -2), 8),
                (new Vector3(2, -3), 2),

                (new Vector3(-1, 0), 6),
                (new Vector3(-1, -1), 15),
                (new Vector3(-1, -2), 15),
                (new Vector3(-1, -3), 14),
                (new Vector3(-1, 1), 15),
                (new Vector3(-1, 2), 11),
                (new Vector3(-2, 0), 10),
                (new Vector3(0, -3), 1),
                (new Vector3(1, -3), 1)
            },
        new (Vector3 position, int roomType)[]
            {
                (new Vector3(1, 0), 6),
                (new Vector3(1, 1), 15),
                (new Vector3(1, 2), 11),
                (new Vector3(1, -1), 13),
                (new Vector3(2, 0), 1),
                (new Vector3(3, 0), 8),

                (new Vector3(-1, 0), 6),
                (new Vector3(-1, -1), 13),
                (new Vector3(-1, 1), 15),
                (new Vector3(-1, 2), 3),
                (new Vector3(-2, 2), 1),
                (new Vector3(-2, 0), 1),
                (new Vector3(-3, 0), 14),
                (new Vector3(-3, 1), 15),
                (new Vector3(-3, 2), 12)
            },
        new (Vector3 position, int roomType)[]
            {
                (new Vector3(1, 0), 4), 
                (new Vector3(1, 1), 15), 
                (new Vector3(1, 2), 3),
                (new Vector3(0, 2), 1),
                (new Vector3(-1, 2), 12), 
                (new Vector3(-1, 1), 15),

                (new Vector3(-1, 0), 16), 
                (new Vector3(-1, -1), 4), 
                (new Vector3(-1, -2), 14), 
                (new Vector3(-2, -1), 10), 
                (new Vector3(0, -2), 7),
                (new Vector3(0, -3), 13), 
                (new Vector3(1, -2), 2), 
                (new Vector3(1, -1), 16), 
                (new Vector3(2, -1), 8) 
             },
        new (Vector3 position, int roomType)[]
             {
                (new Vector3(1, 0), 1), 
                (new Vector3(2, 0), 3), 
                (new Vector3(2, -1), 15), 
                (new Vector3(2, -2), 2), 
                (new Vector3(1, -2), 12), 
                (new Vector3(1, -3), 2), 

                (new Vector3(0, -3), 1),
                (new Vector3(-1, -3), 14),
                (new Vector3(-1, -2), 15), 
                (new Vector3(-1, -1), 15), 
                (new Vector3(-1, 0), 16), 
                (new Vector3(-1, 1), 15), 
                (new Vector3(-1, 2), 7),
                (new Vector3(0, 2), 8), 
             },
        new (Vector3 position, int roomType)[]
             {
                (new Vector3(1, 0), 7), 
                (new Vector3(2, 1), 11), 
                (new Vector3(2, 0), 6), 
                (new Vector3(2, -1), 6), 
                (new Vector3(2, -2), 5),
                (new Vector3(1, -2), 14), 

                (new Vector3(1, -1), 16), 
                (new Vector3(3, 0), 3), 
                (new Vector3(3, -1), 4), 
                (new Vector3(3, -2), 2),
                (new Vector3(-1, 0), 14),
                (new Vector3(-1, 1), 15), 
                (new Vector3(-1, 2), 12), 
                (new Vector3(0, 2), 2), 
                (new Vector3(0, 3), 11) 
             },
        new (Vector3 position, int roomType)[]
             {
    
                (new Vector3(1, 0), 1),
                (new Vector3(2, 0), 8), 
                (new Vector3(0, 1), 4), 
                (new Vector3(0, 2), 4), 
                (new Vector3(0, 3), 3), 
                (new Vector3(0, -1), 4), 

                (new Vector3(0, -2), 2),
                (new Vector3(-1, 3), 12), 
                (new Vector3(-1, -1), 6), 
                (new Vector3(-1, -2), 14), 
                (new Vector3(-1, 0), 16), 
                (new Vector3(-1, 1), 16), 
                (new Vector3(-1, 2), 6), 
                (new Vector3(-2, 2), 10), 
                (new Vector3(-2, -1), 10) 
            },
        new (Vector3 position, int roomType)[]
            {
    
                (new Vector3(1, 0), 6), 
                (new Vector3(2, 0), 3), 
                (new Vector3(2, -1), 2), 
                (new Vector3(1, -1), 14), 
                (new Vector3(1, 1), 11), 
                (new Vector3(-1, 0), 1), 

                (new Vector3(-2, 0), 5), 
                (new Vector3(-2, 1), 11), 
                (new Vector3(-3, 0), 12), 
                (new Vector3(-3, -1), 4), 
                (new Vector3(-3, -2), 4), 
                (new Vector3(-3, -3), 13), 
                (new Vector3(-4, -1), 7), 
                (new Vector3(-4, -2), 14), 
                (new Vector3(-5, -1), 10) 
    },
        new (Vector3 position, int roomType)[]
            {
                (new Vector3(1, 0), 6), 
                (new Vector3(2, 0), 1),
                (new Vector3(3, 0), 8), 
                (new Vector3(1, 2), 11), 
                (new Vector3(1, 1), 15), 
                (new Vector3(1, -1), 15), 

                (new Vector3(1, -2), 15), 
                (new Vector3(1, -3), 2), 
                (new Vector3(0, -3), 1), 
                (new Vector3(-1, -3), 14), 
                (new Vector3(-1, -2), 15),
                (new Vector3(-1, -1), 15), 
                (new Vector3(-1, 0), 6), 
                (new Vector3(-1, 1), 11), 
                (new Vector3(-2, 0), 10) 
         },
        new (Vector3 position, int roomType)[]
            {
                (new Vector3(1, 0), 4),
                (new Vector3(1, 1), 16),
                (new Vector3(1, 2), 15), 
                (new Vector3(1, 3), 12),
                (new Vector3(2, 3), 1), 
                (new Vector3(3, 3), 3), 

                (new Vector3(3, 2), 15), 
                (new Vector3(3, 1), 2), 
                (new Vector3(2, 1), 1), 
                (new Vector3(1, -1), 15), 
                (new Vector3(1, -2), 2), 
                (new Vector3(0, -2), 1), 
                (new Vector3(-1, -2), 14), 
                (new Vector3(-1, -1), 15),
                (new Vector3(-1, 0), 12) 
         },
        new (Vector3 position, int roomType)[]
            {
                (new Vector3(1, 0), 1), 
                (new Vector3(2, 0), 6), 
                (new Vector3(3, 0), 8), 
                (new Vector3(2, 1), 15), 
                (new Vector3(2, 2), 11), 

                (new Vector3(2, -1), 15), 
                (new Vector3(2, -2), 13), 
                (new Vector3(-1, 0), 1), 
                (new Vector3(-2, 0), 6),
                (new Vector3(-2, 1), 15), 
                (new Vector3(-2, 2), 3),
                (new Vector3(-3, 0), 10), 
                (new Vector3(-2, -1), 15),
                (new Vector3(-2, -2), 13), 
                (new Vector3(-3, 2), 10)
             }
    };




    private (Vector3 position, int roomType)[] roomInfos;

    void Awake()
    {
        roomInfos = roomPatterns[Random.Range(0, roomPatterns.Length)];

        foreach (var (position, roomType) in roomInfos)
        {
            Instantiate(Rooms[roomType], new Vector3(position.x * RoomX, position.y * RoomY, 0), Quaternion.identity);
        }

        Instantiate(Player, this.gameObject.transform.position, Quaternion.identity);
    }
}
