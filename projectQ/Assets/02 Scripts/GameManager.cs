using UnityEngine;
using UnityEngine.UIElements;
using static Lever1ManagerTrigger;

public class GameManager : MonoBehaviour
{
    public GameObject[] Rooms;
    public GameObject[] BossDoors;
    public float RoomX = 18.46f;
    public float RoomY = 10.25f;
    public GameObject Player;
    public OneEye[] oneeyes;
    public OneEye_Clone[] oneeyesClone;
    public OneEye1[] oneeyesred;
    public BasicEnemy[] basicEnemy;
    public Virus[] virus;
    public Snake[] snake;


    public static GameManager Instance;
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
                (new Vector3(1, -3), 1),
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
                (new Vector3(-1, 2), 12),
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
                (new Vector3(0, 2), 2), 
                (new Vector3(0, 3), 3), 

                (new Vector3(0, -2), 3),
                (new Vector3(-1, 3), 12), 
                (new Vector3(-1, -1), 4), 
                (new Vector3(-1, -2), 16), 
                (new Vector3(-1, 0), 16), 
                (new Vector3(-1, 1), 15), 
                (new Vector3(-1, 2), 6), 
                (new Vector3(-2, 2), 10), 
                (new Vector3(-2, -1), 10), 
                (new Vector3(-1, -3), 14),
                (new Vector3(0, -3), 2),

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
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        int DecideRoomPattern = Random.Range(0, roomPatterns.Length);
        roomInfos = roomPatterns[DecideRoomPattern];
        Instantiate(Player, this.gameObject.transform.position, Quaternion.identity);
        switch (DecideRoomPattern)
        {
            case 0:
                Instantiate(BossDoors[0], new Vector3(-37.54f, 0.15f, 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(BossDoors[2], new Vector3(18.52f, 20.69f, 0), Quaternion.identity);

                break;
            case 2:
                Instantiate(BossDoors[2], new Vector3(0.04f, 20.728f, 0), Quaternion.identity);

                break;
            case 3:
                Instantiate(BossDoors[3], new Vector3(-1.37f, -32.27f, 0), Quaternion.identity);

                break;
            case 4:
                Instantiate(BossDoors[0], new Vector3(-0.64f, 30.91f, 0), Quaternion.identity);

                break;
            case 5:
                Instantiate(BossDoors[1], new Vector3(37.559f, 0.158f, 0), Quaternion.identity);

                break;
            case 6:
                Instantiate(BossDoors[1], new Vector3(-54.61f, -20.33f, 0), Quaternion.identity);


                break;
            case 7:
                Instantiate(BossDoors[3], new Vector3(-1.363f, -32.318f, 0), Quaternion.identity);



                break;
            case 8:
                Instantiate(BossDoors[1], new Vector3(56.049f, 20.658f, 0), Quaternion.identity);


                break;
            case 9:
                Instantiate(BossDoors[1], new Vector3(-36.275f, 20.693f, 0), Quaternion.identity);

                break;                                     
        }
        foreach (var (position, roomType) in roomInfos)
        {
            Instantiate(Rooms[roomType], new Vector3(position.x * RoomX, position.y * RoomY, 0), Quaternion.identity);
        }

    }
    private  void Start()
    {
        oneeyes = GameObject.FindObjectsOfType<OneEye>();
        oneeyesClone = GameObject.FindObjectsOfType<OneEye_Clone>();
        oneeyesred = GameObject.FindObjectsOfType<OneEye1>();
        basicEnemy = GameObject.FindObjectsOfType<BasicEnemy>();
        virus = GameObject.FindObjectsOfType<Virus>();
        snake = GameObject.FindObjectsOfType<Snake>();

        foreach (OneEye oneeye in oneeyes)
        {
            oneeye.gameObject.SetActive(false);
        }
        foreach (OneEye_Clone oneeyes in oneeyesClone)
        {
            oneeyes.gameObject.SetActive(false);
        }
        foreach (OneEye1 oneeyes in oneeyesred)
        {
            oneeyes.gameObject.SetActive(false);
        }
        foreach (BasicEnemy basicenemies in basicEnemy)
        {
            basicenemies.gameObject.SetActive(false);
        }
        foreach (Virus viruses in virus)
        {
            viruses.gameObject.SetActive(false);
        }
        foreach (Snake snakes in snake)
        {
            snakes.gameObject.SetActive(false);
        }


    }
}
